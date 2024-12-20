using BlogApp.Client.Models;
using Riok.Mapperly.Abstractions;

namespace BlogApp.Client;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
internal partial class Mapper
{
    internal static readonly Mapper Instance = new();

    public partial Post Map(GetPostsResponse_Post post);
    public partial List<Post> Map(ICollection<GetPostsResponse_Post> posts);

    public partial Post Map(GetPostsByIdResponse post);
}
