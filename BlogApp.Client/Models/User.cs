namespace BlogApp.Client.Models;

public sealed class User
{
    public string Email { get; set; } = default!;
    public string HashedPassword { get; set; } = default!;
    public string Id { get; set; } = default!;

    #region Navigation Properties

    public ICollection<Post> Posts { get; set; } = [];

    #endregion Navigation Properties
}