using blogapp.Data;

namespace blogapp.Repository;

public interface IPostRepository
{
    public List<Post> GetAll();
    public Post Get(Guid id);
    public bool Insert(Post post);
}