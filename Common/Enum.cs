using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum StatusOder
    {

        Unknown = 0,

        received = 1,

        progress = 2,

        complete = 3

    }


    public enum EatingType
    {

        normally, 
        sideDish,
        VeganFood,
        Healthy,


    }

    public enum Notification
    {
        // 1xx Informational
        Continue = 100,                  // Tiếp tục
        SwitchingProtocols = 101,        // Đang chuyển giao giao thức

        // 2xx Success
        OK = 200,                        // Thành công
        Created = 201,                   // Tạo thành công
        Accepted = 202,                  // Đã chấp nhận
        NonAuthoritativeInformation = 203, // Thông tin không chính thức
        NoContent = 204,                 // Không có nội dung
        ResetContent = 205,              // Đặt lại nội dung
        PartialContent = 206,            // Nội dung phần tử

        // 3xx Redirection
        MultipleChoices = 300,           // Nhiều sự lựa chọn
        MovedPermanently = 301,          // Chuyển hướng vĩnh viễn
        Found = 302,                     // Đã tìm thấy
        SeeOther = 303,                  // Xem tài nguyên khác
        NotModified = 304,               // Không thay đổi
        UseProxy = 305,                  // Dùng Proxy
        TemporaryRedirect = 307,         // Chuyển hướng tạm thời

        // 4xx Client Errors
        BadRequest = 400,                // Yêu cầu không hợp lệ
        Unauthorized = 401,              // Không có quyền truy cập
        Forbidden = 402,                 // Cấm truy cập
        NotFound = 404,                  // Tài nguyên không tìm thấy
        MethodNotAllowed = 405,          // Phương thức không được phép
        NotAcceptable = 406,             // Không chấp nhận được
        ProxyAuthenticationRequired = 407, // Cần xác thực Proxy
        RequestTimeout = 408,            // Hết thời gian yêu cầu
        Conflict = 409,                  // Xung đột dữ liệu
        Gone = 410,                      // Tài nguyên đã biến mất
        LengthRequired = 411,            // Cần chiều dài
        PreconditionFailed = 412,        // Điều kiện tiền đề không thành công
        PayloadTooLarge = 413,           // Tải quá lớn
        URITooLong = 414,                // URI quá dài
        UnsupportedMediaType = 415,      // Loại phương tiện không hỗ trợ
        RangeNotSatisfiable = 416,       // Phạm vi không thể thỏa mãn
        ExpectationFailed = 417,         // Mong đợi không thành công

        // 5xx Server Errors
        InternalServerError = 500,       // Lỗi máy chủ nội bộ
        NotImplemented = 501,            // Chưa triển khai
        BadGateway = 502,                // Cổng xấu
        ServiceUnavailable = 503,        // Dịch vụ không sẵn sàng
        GatewayTimeout = 504,            // Thời gian chờ cổng
        HTTPVersionNotSupported = 505    // Phiên bản HTTP không được hỗ trợ
    }

}
