using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Seller;

namespace TetPee.Api.Controllers;

[ApiController]
[Route("[controller]")] // địa chỉ mà controller này lắng nghe - tạo đường dẫn URL
public class SellerController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _service;

    public SellerController(AppDbContext dbContext, IService service)
    {
        _dbContext = dbContext;
        _service = service;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetSellers([FromQuery] string? searchTerm, int pageSize = 10, int pageIndex = 1)//bỏ vào đây ta được là sau dấu chấm hỏi
    {
        
        var sellers = await _service.GetSellers(searchTerm, pageSize, pageIndex);
 
        // throw new Exception("Get Users Error");
        return Ok(sellers);
    }
    
    [HttpGet("{sellerId}")]
    public async Task<IActionResult> GetSellersByID([FromRoute]Guid sellerId)//bỏ vào đây ta được là sau dấu chấm hỏi
    {
        
        var sellers = await _service.GetSellersById(sellerId);
 
        // throw new Exception("Get Users Error");
        return Ok(sellers);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateSeller(Request.CreateSellerRequest request)
    {
        var result = await _service.CreateSeller(request);
        return Ok(result);
    }
    
}