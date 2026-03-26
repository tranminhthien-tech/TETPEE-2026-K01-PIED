using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service: IService
{
    private readonly AppDbContext _dbcontext;
//ko inject DB
    public Service(AppDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    
    public async Task<List<Response.GetCateGoryResponse>> GetCategory()
    {
        var query = _dbcontext.Categories.Where(x => true);
        query = query.OrderBy(x => x.Name);
        
        var selectedQuery = query
            .Select(x => new Response.GetCateGoryResponse()
        {
            Id = x.Id,
            Name = x.Name,
        });

        var result = await selectedQuery.ToListAsync();
        return result;
    }

    public async Task<List<Response.GetCateGoryResponse>> GetCategoryByParentId(Guid parentId)
    {
        var query = _dbcontext.Categories
            .Where(x => x.ParentId == parentId);
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query
            .Select(x => new Response.GetCateGoryResponse()
        {
            Id = x.Id,
            Name = x.Name,
        });

        var result = await selectedQuery.ToListAsync();
        return result;
    }
}