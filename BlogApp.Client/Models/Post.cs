namespace BlogApp.Client.Models;

public sealed class Post
{
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    #region Navigation Properties

    public User User { get; set; } = default!;
    public string UserId { get; set; } = default!;

    #endregion Navigation Properties
}