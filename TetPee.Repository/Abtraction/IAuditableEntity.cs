namespace TetPee.Repository.abtraction;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedAt { get; set; } // Dòng dữ liệu này được tạo ra khi nào
    public DateTimeOffset? UpdatedAt { get; set; } // Dòng dữ liệu này được ập nhật lần cuối khi nào
}