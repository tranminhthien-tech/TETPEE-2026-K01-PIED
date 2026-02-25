using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;

namespace TetPee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    //cái này nâng cao lúc sau sẽ giải thích
    public CategoryController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}