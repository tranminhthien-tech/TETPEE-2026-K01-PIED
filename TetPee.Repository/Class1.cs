namespace TetPee.Repository;

    public class Class1
    {
        // ORM: Object-Relational Mapping
        
        // Code First và Database First
        
        // Thông thường để mà ở trên code mà để có thể làm việc với database
            // th mình cần có ánh sạ (mapping) các table từ database lên code để dễ quản lí và làm việc.
            
        // Database First:
        // - làm việc với database có sẵn, setup 1 Database
        // - vô tạo Create Table, Create Database, Setup Field, Set Các Relationship
        // - Sau đó ở trên code sử dụng các Driver hoặc ORM để kết nối xuống Database.
        // - Ở trên code sẽ tạo những class tương ứng các table trong database
        // - Thằng này sử dụng khi nào: khi mình có Database có sẵn và đã sử dụng trong rất nhiều năm rồi, những dự án Maintain
        
        // Code First:
        // - Mình sẽ không setup Database thủ công bằng các Query
        // - Không vô tạo Create Table, Create Database, Setup Field, Set các Relationship
        // - Mình design Database bằng những class trên code luôn, tre code setup các Entity, các Field, các Relationship
        // - Sau đó ánh sạ từ các class xuống các table trong Database
        // Vậy là sao để ánh sạ được, từ các class trên code xuống Database: ORM: Object-Relational Mapping
        // Thằng này sử dụng khi: Dự án mới, hiện đại, nhiều công cụ hỗ trợ
        
        //Tuyệt đỉnh ORM của .NET: Entity Framework. Ko biết sử dụng và thành thục thằng  này thì mất 90% sức mạnh .NET
    }
//3 tầng : tầng đầu Api: khai báo Api 
// tầng service: sử lí các logic nghiệp vụ của hệ thông
// tầng repository: tương tác với database thao tác truy vấn dữ liệu với dbs

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


