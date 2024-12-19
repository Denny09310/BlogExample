using BlogApp.Client.Models;
using BlogApp.Data;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Encoder = BCrypt.Net.BCrypt;

namespace Register;

internal sealed class Endpoint(ApplicationDbContext db) : Endpoint<Request, EmptyResponse, Mapper>
{
    private readonly ApplicationDbContext _db = db;

    public override void Configure()
    {
        Post("/authorization/register");
        AllowAnonymous();

        Description(d => d
            .WithName("Register")
            .WithSummary("Register a new user")
            .ProducesProblemDetails(StatusCodes.Status409Conflict));
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == r.Email, ct);
        if (user != null) ThrowError(r => r.Email, "Email already in use", StatusCodes.Status409Conflict);

        user = Map.ToEntity(r);

        await _db.Users.AddAsync(user, ct);
        await _db.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}

internal sealed class Request
{
    public string Email { get; set; }
    public string Password { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}

internal sealed class Mapper : RequestMapper<Request, User>
{
    public override User ToEntity(Request r) => new()
    {
        Email = r.Email,
        HashedPassword = Encoder.HashPassword(r.Password)
    };
}