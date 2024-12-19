using BlogApp.Client.Models;
using BlogApp.Data;
using FastEndpoints;
using FluentValidation;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Insert.Posts;

internal sealed class Endpoint(ApplicationDbContext db) : Endpoint<Request, Response, Mapper>
{
    private readonly ApplicationDbContext _db = db;

    public override void Configure()
    {
        Post("/posts");
        Description(d => d
            .WithName("InsertPost")
            .WithSummary("Insert a post")
            .ClearDefaultProduces(200)
            .Produces(StatusCodes.Status201Created));
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        var post = Map.ToEntity(r);
        post.Content = ContentSanitizer.Sanitize(post.Content);

        await _db.Posts.AddAsync(post, ct);
        await _db.SaveChangesAsync(ct);

        await SendCreatedAtAsync<Get.Posts.By.Id.Endpoint>(post.Id, Map.FromEntity(post), cancellation: ct);
    }
}

internal sealed class Mapper : Mapper<Request, Response, Post>
{
    public override Response FromEntity(Post e) => new()
    {
        Id = e.Id,
        Title = e.Title,
        Content = e.Content,
        CreatedAt = e.CreatedAt,
        UpdatedAt = e.UpdatedAt
    };

    public override Post ToEntity(Request r) => new()
    {
        UserId = r.UserId,
        Title = r.Title,
        Content = r.Content
    };
}

internal sealed class Request
{
    public string Content { get; set; }

    public string Title { get; set; }

    [FromClaim(ClaimTypes.NameIdentifier)]
    public string UserId { get; set; }
}

internal sealed class Response
{
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    public string Title { get; set; }
    public DateTime UpdatedAt { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
    }
}

public static partial class ContentSanitizer
{
    public static string Sanitize(string content)
    {
        if (string.IsNullOrEmpty(content))
            return content;

        // Remove script tags
        content = GetScriptRegex().Replace(content, string.Empty);

        content = content.Replace("<", "&lt;");
        content = content.Replace(">", "&gt;");

        // Encode special characters
        content = System.Net.WebUtility.HtmlEncode(content);

        return content;
    }

    [GeneratedRegex("<script.*?>.*?</script>", RegexOptions.IgnoreCase)]
    private static partial Regex GetScriptRegex();
}