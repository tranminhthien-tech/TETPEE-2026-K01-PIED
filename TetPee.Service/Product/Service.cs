using Microsoft.EntityFrameworkCore;
using TetPee.Repository;
using TetPee.Repository.Entity;

namespace TetPee.Service.Product;

public class Service: IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateProduct(Request.CreateProductRequest request)
    {
        var existingProduct = _dbContext.Products
            .Where(x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim());
        bool isExistProduct = await existingProduct.AnyAsync();
        if (isExistProduct) throw new Exception("Product with the same name already exists");

        var existingSeller = _dbContext.Sellers.Where(x => x.Id == request.SellerId);
        bool isExistSeller = await existingSeller.AnyAsync();
        if (!isExistSeller) throw new Exception("Seller not exists");
        
        var product = new Repository.Entity.Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            // Quanity = request.Quantity
            SellerId = request.SellerId
        };
        _dbContext.Add(product);
        var resultProduct = await _dbContext.SaveChangesAsync();

        if (request.CategoryIds != null && request.CategoryIds.Count > 0)
        {
            var productCateList = request.CategoryIds.Select(id => new ProductCategory()
            {
                CategoryId = id,
                ProductId = product.Id
            });
            _dbContext.AddRange(productCateList);
            await _dbContext.SaveChangesAsync();
        }
        
        if (resultProduct > 0) return "Add Product Successfully";

        return "Add Product failed";

    }
}