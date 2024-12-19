﻿using BlogApp.Client.Models;
using BlogApp.Data;
using FastEndpoints;
using FluentValidation;

namespace Get.Posts.By.Id;

internal sealed class Endpoint(ApplicationDbContext db) : Endpoint<Request, Response, Mapper>
{
    private readonly ApplicationDbContext _db = db;

    public override void Configure()
    {
        Get("/posts/{id}");
        AllowAnonymous();
        Description(d => d
            .WithName("GetPostById")
            .WithSummary("Get a post by its ID")
            .ProducesProblem(StatusCodes.Status404NotFound));
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        var post = await _db.Posts.FindAsync([r.Id], ct);
        if (post == null) ThrowError(r => r.Id, "Post not found", StatusCodes.Status404NotFound);

        Response = Map.FromEntity(post);
    }
}

internal sealed class Request
{
    public string Id { get; set; }
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

internal sealed class Mapper : ResponseMapper<Response, Post>
{
    public override Response FromEntity(Post e) => new()
    {
        Id = e.Id,
        Title = e.Title,
        Content = e.Content,
        CreatedAt = e.CreatedAt,
        UpdatedAt = e.UpdatedAt
    };
}