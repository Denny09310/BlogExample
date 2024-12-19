using BlogApp.Client.Models;
using BlogApp.Data;
using FastEndpoints;
using FluentValidation;
using System.Security.Claims;

namespace Update.Posts;

internal sealed class Endpoint(ApplicationDbContext db) : Endpoint<Request, Response, Mapper>
{
    private readonly ApplicationDbContext _db = db;

    public override void Configure()
    {
        Put("/posts/{id}");
        Description(d => d
            .WithName("UpdatePost")
            .WithSummary("Update a post by its ID")
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status404NotFound));
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        var existing = await _db.Posts.FindAsync([r.Id], ct);
        if (existing == null) ThrowError(r => r.Id, "Post not found", StatusCodes.Status404NotFound);

        if (existing.UserId != r.UserId)
        {
            ThrowError(r => r.UserId, "You are not authorized to delete this post", StatusCodes.Status401Unauthorized);
        }

        var post = Map.ToEntity(r);

        if (!string.IsNullOrWhiteSpace(post.Title)) existing.Title = post.Title;
        if (!string.IsNullOrWhiteSpace(post.Content)) existing.Content = post.Content;
        existing.UpdatedAt = DateTime.Now;

        _db.Posts.Update(existing);
        await _db.SaveChangesAsync(ct);

        Response = Map.FromEntity(existing);
    }
}

internal sealed class Request
{
    public string Content { get; set; }

    public string Id { get; set; }

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
        RuleFor(x => x.Id).NotEmpty();
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
        Id = r.Id,
        Title = r.Title,
        Content = r.Content
    };
}