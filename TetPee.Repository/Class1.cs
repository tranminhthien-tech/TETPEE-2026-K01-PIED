namespace TetPee.Repository;

public class Class1
{
}
//3 tầng : tầng đầu Api: khai báo Api 
// tầng service: sử lí các logic nghiệp vụ của hệ thông
// tầng repository: thng6 tác với database thao tác truy vấn dữ liệu với dbs

// API(Khai báo API và 1 vài setup):  Gọi đến Service
//       Và khai báo API
// Ví dụ: Khai báo GET mua-hang
//        Sau khi người dùng gọi api này, thì server gọi đến service mua hàng

// Service(Xử lí logic, nghiệp vụ) thì có thể gọi nhiều Repository
// Ví dụ: Service có 1 hàm: Mua hàng
//          - kiểm tra user này có tồn tại hay không (tương tác với User Repository)
//          - kiễm tra đơn hàng này có hàng hay không (tương tác với Producr Repository)
//          - Xuất hóa đơn (Order) (tương tác với Order Repository)
//          Không thể gọi APIs
// Repository(tương tác với Database):  Không thể gọi Service
//              Không thể gọi APIs
//              Trong 1 hệ thống thì có thể c nhiều Repository
//                  User Repository: Nơi truy vấn và thao tác dữ liệu chuyên biệt liên quan tới data user
//                  Product Repository: Nơi truy vấn và thao tác dữ liêệu chuyên biệt liên quan tới data product
//                  Order Repository: Nơi truy vấn và truy vấn ữ liệu chuyên biệt liên quan tới data order

// User: Khách hàng vào mua
// Người bán: Seller
// Sản phẩm: Product
// Đơn hàng: Order

//Vẽ ERD cho anh thiết kế database 