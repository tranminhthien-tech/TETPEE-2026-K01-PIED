using TetPee.Repository.abtraction;

namespace TetPee.Repository.Entity;

public class Category: BaseEntity<Guid>, IAuditableEntity
{
    public required string Name { get; set; }
    
    public Guid? ParentId { get; set; } 
    // Nếu mà là null, thì nó là thằng cha cao nhất
    // Nếu mà có giá trị, thì nó là thằng con của ParentId
    public Category? Parent { get; set; }
    
    public ICollection<Category> Children { get; set; } =  new List<Category>();
    public ICollection<ProductCategory> ProductCatagories { get; set; } =  new List<ProductCategory>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}







































