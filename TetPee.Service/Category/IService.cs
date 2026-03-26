namespace TetPee.Service.Category;

public interface IService
{
    public Task<List<Response.GetCateGoryResponse>> GetCategory();
    public Task<List<Response.GetCateGoryResponse>> GetCategoryByParentId(Guid parentId);
}