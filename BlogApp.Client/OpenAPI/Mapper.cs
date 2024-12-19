using BlogApp.Client.Models;
using Riok.Mapperly.Abstractions;

namespace BlogApp.Client;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
internal static partial class Mapper
{
    public static partial Post Map(GetPostsResponse_Post post);
    public static partial List<Post> Map(ICollection<GetPostsResponse_Post> posts);
}
