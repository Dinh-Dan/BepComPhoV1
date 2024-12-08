using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Model.RequestModel.Custom;
using Service;
using Service.IService;


namespace BepComPhoV1.Controllers
{
    public class TestCacheController : Controller
    {
        private readonly IEmloyeeService _emloyeeService;



        // Constructor sử dụng IMemoryCache
        public TestCacheController(IEmloyeeService emloyeeService)
        {
            _emloyeeService = emloyeeService;
        }

        /*        // Phương thức POST để thêm dữ liệu vào cache
                [HttpPost("adddata_inCache")]
                public IActionResult Input([FromBody] OrderDetaiRequest value, string key)
                {
                    // Lưu dữ liệu vào cache với key và thời gian hết hạn
                    _memoryCache.Set(key, value, TimeSpan.FromMinutes(1)); // Lưu trong cache 5 phút

                    return Ok(value);
                  }*/

        // Phương thức GET để lấy dữ liệu từ cache
        [HttpGet("testDataService")]

        public IActionResult GetOrder()
        {
            return Ok(_emloyeeService.GetAllOrder());
        }


    }
}
