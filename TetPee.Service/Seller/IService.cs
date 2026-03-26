namespace TetPee.Service.Seller;

public interface IService
{
    public Task<Base.Response.PageResult<Response.GetSellerResponse>> GetSellers(
        string? searchTerm,
        int pageSize,
        int pageIndex);
    
    public Task<Response.GetSellerDetailResponse?> GetSellersById(Guid sellerId);
    
    public Task<string> CreateSeller(Request.CreateSellerRequest request);
    
}