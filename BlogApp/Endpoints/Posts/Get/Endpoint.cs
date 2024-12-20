using BlogApp.Client.Models;
using BlogApp.Data;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Get.Posts;

internal sealed class Endpoint(ApplicationDbContext db) : Endpoint<Request, Response, Mapper>
{
    private readonly ApplicationDbContext _db = db;

    public override void Configure()
    {
        Get("/posts");
        AllowAnonymous();
        Description(d => d
            .WithName("GetPosts")
            .WithSummary("Get all posts"));
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        IQueryable<Post> query = _db.Posts.Include(x => x.User)
            .OrderBy(r.Order);

        if (!string.IsNullOrWhiteSpace(r.Filter))
        {
            query = query.Where(r.Filter);
        }

        var posts = await query
            .Skip(r.Offset)
            .Take(r.Limit)
            .ToListAsync(ct);

        Response = Map.FromEntity(posts);
        Response.TotalItems = await _db.Posts.CountAsync(ct);
    }
}

internal sealed class Request
{
    public string? Filter { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public string Order { get; set; } = nameof(Post.CreatedAt);
}

internal sealed class Response
{
    public IEnumerable<Post> Posts { get; set; }
    public int TotalItems { get; set; }

    public class Post
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string Email { get; set; }
        public string Id { get; set; }
    }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Limit).GreaterThan(0);
    }
}

internal sealed class Mapper : ResponseMapper<Response, IEnumerable<Post>>
{
    public override Response FromEntity(IEnumerable<Post> e) => new()
    {
        Posts = e.Select(x => new Response.Post
        {
            Id = x.Id,
            Title = x.Title,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
            User = new Response.User
            {
                Id = x.User.Id,
                Email = x.User.Email
            }
        })
    };
}