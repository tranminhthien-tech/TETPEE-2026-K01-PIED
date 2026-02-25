namespace TetPee.Repository.abtraction;

public abstract class BaseEntity<Tkey>
{
    public Tkey Id { get; set; }
    
    public bool IsDeleted { get; set; }
}