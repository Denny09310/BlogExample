using BlogApp.Client.Models;
using BlogApp.Data;
using FastEndpoints;
using FastEndpoints.Security;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Encoder = BCrypt.Net.BCrypt;

namespace Login;

sealed class Endpoint(ApplicationDbContext db) : Endpoint<Request, Response, Mapper>
{
    private readonly ApplicationDbContext _db = db;

    public override void Configure()
    {
        Post("/authorization/login");
        AllowAnonymous();
        Description(d => d
            .WithName("Login")
            .WithSummary("Login to the application")
            .ProducesProblemDetails(StatusCodes.Status401Unauthorized));
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == r.Email, ct);
        if (user == null || !Encoder.Verify(r.Password, user.HashedPassword))
        {
            ThrowError("Invalid email or password", StatusCodes.Status401Unauthorized);
        }

        Response = Map.FromEntity(user);
        Response.Token = JwtBearer.CreateToken(opt =>
        {
            opt.User.Claims.AddRange(
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "user"));

            opt.User.Roles.Add("user");
        });

        await SendAsync(Response, cancellation: ct);
    }
}

sealed class Request
{
    public string Email { get; set; }
    public string Password { get; set; }
}

sealed class Response
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}

sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}

sealed class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request r) => new()
    {
        Email = r.Email,
        HashedPassword = Encoder.HashPassword(r.Password)
    };

    public override Response FromEntity(User e) => new()
    {
        Id = e.Id,
        Email = e.Email,
    };
}
