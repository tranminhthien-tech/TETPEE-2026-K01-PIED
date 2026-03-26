using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Seller;

public class Service: IService 
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Base.Response.PageResult<Response.GetSellerResponse>> GetSellers(string? searchTerm, int pageSize, int pageIndex)
    {
        var query = _dbContext.Users.Where(x => x.Role == "User");
        if (searchTerm != null)
        {
            query = query.Where(x => x.FirstName.Contains(searchTerm));
        }
        query = query.OrderBy(x => x.FirstName);
        
        query = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        var selectedQuery = query
            .Select(x => new Response.GetSellerResponse()
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            ImageUrl = x.ImageUrl,
            TaxCode = x.Seller!.TaxCode,
            CompanyName = x.Seller.CompanyName,
        });

        var listResult = await selectedQuery.ToListAsync();
        var totalItems = listResult.Count;

        var result = new Base.Response.PageResult<Response.GetSellerResponse>()
        {
            Items = listResult,
            PageIndex =  pageIndex,
            PageSize = pageSize,
            TotalItems = totalItems,
        };
        return result;

    }

    public async Task<Response.GetSellerDetailResponse?> GetSellersById(Guid sellerId)
    {
        var query = _dbContext.Users.Where(x => x.Id == sellerId 
                                                            && x.Role == "User");
        var selectedQuery = query
            .Select(x => new Response.GetSellerDetailResponse()
        {
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName,
            ImageUrl = x.ImageUrl,
            PhoneNumber = x.PhoneNumber!,
            Address = x.Address,
            TaxCode =  x.Seller!.TaxCode,
            CompanyName = x.Seller.CompanyName,
            CompanyAddress = x.Seller.CompanyAddress,

        });

        var result = await selectedQuery.FirstOrDefaultAsync();
        return result;
    }

    public async Task<string> CreateSeller(Request.CreateSellerRequest request)
    {
        var existingUserQuery = _dbContext.Users.Where(x => x.Email == request.Email);
        bool isUserExist = await existingUserQuery.AnyAsync();
        if (isUserExist) throw new Exception(Message.UserExistWithMail);

        var user = new Repository.Entity.User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            HashedPassword = request.Password,
            Role = "Seller",
        };
        _dbContext.Add(user);
        var result = await _dbContext.SaveChangesAsync();

        if (result > 0)
        {
            var seller = new Repository.Entity.Seller()
            {
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                TaxCode = request.TaxCode,
                UserId = user.Id,
            };
            _dbContext.Add(seller);
            var result2 = await _dbContext.SaveChangesAsync();
            if (result2 > 0) return "Add Seller Successfully";
            
        }
        
        return Message.FailToAddSeller;
        
    }
}