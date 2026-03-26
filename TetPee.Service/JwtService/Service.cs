using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TetPee.Service.JwtService;

public class Service : IService
{
    private readonly JwtOptions _jwtOptions = new();

    public Service(IConfiguration configuration)
    {
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOptions);
        //ánh xa du lieu tu AppSettings vao object JWtOptions
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        // atao 1 key de ma hoa token, su dung secretKey tu jwtToken
        var signingCredentials =new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        // tao 1 doi tuong SigningCredentials de xac dinh thuat toan ma hoa va key su dung de ky token 
        var tokeOptions = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer, //Cai token nay duoc kí - tạo ra bởi ai tổ chuc nào
            audience: _jwtOptions.Audience, // Cai token này dành cho ai tổ chức nào
            claims: claims, //Thông tin mà bạn muốn lưu trữ trong token
            //thường là thông tin về người dùng như ID, email, vai trò ,v.v..
            //nam trong payload
            expires: DateTime.Now.AddMinutes(_jwtOptions.ExpireMinutes), //Token này hế hạng trong bao lêu
            signingCredentials: signingCredentials
        );
       
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //sau do goi JwtSecurityTokenHandler
        // de tao ra token dưới dạng chuỗi (string) tù các thông tin đã cung cấp ở trên
        return tokenString;
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}