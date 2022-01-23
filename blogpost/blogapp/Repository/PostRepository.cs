using blogapp.Data;

namespace blogapp.Repository;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _ctx;

    public PostRepository(AppDbContext context)
    {
        _ctx = context;
    }

    public Post Get(Guid id) => _ctx.Posts.FirstOrDefault(p => p.Id == id);

    public List<Post> GetAll() => _ctx.Posts.ToList<Post>();

    public bool Insert(Post post)
    {
        if(_ctx.Posts.Any(p => p.Id == post.Id))
        {
            return false;
        }

        try
        {
            _ctx.Posts.Add(post);
            _ctx.SaveChanges();
        }
        catch(Exception e)
        {
            return false;
        }

        return true;
    }
}