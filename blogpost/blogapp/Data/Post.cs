using System.ComponentModel.DataAnnotations;

namespace blogapp.Data;

public class Post
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Content { get; set; }
}