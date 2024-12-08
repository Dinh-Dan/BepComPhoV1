using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entitys;
using Model.RequestModel.Custom;
using Service.IService;
using System.ComponentModel.DataAnnotations;

namespace BepComPhoV1.Controllers
{
    [ApiController]
    [Route("api/khachhang")]
    public class CustomControler : ControllerBase
    {
        private readonly ICustomService _customService;

        // Inject service qua constructor
        public CustomControler(ICustomService customService)
        {
            _customService = customService;
        }

        [HttpGet("MonAn")]
        public async Task<IActionResult> GetMenuDay([FromQuery] string date)
        {
            Console.WriteLine("test");

            var menu = await _customService.GetMenuDay(date);

          
            if (menu == null)
            {
                return NotFound("Menu for the given date not found.");
            }
            return Ok(menu);
        }




        [HttpPost("taoKhachHang")]
        public async Task<IActionResult> CreateCustomAsync([FromBody] CreateCustomer custom)
        {
            // Validate Name
            if (string.IsNullOrWhiteSpace(custom.name))
                return BadRequest("Tên không được để trống.");
            if (custom.name.Length > 50)
                return BadRequest("Tên không được dài quá 50 ký tự.");

            // Validate NumberPhone
            if (string.IsNullOrWhiteSpace(custom.numberPhone))
                return BadRequest("Số điện thoại không được để trống.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(custom.numberPhone, @"^\d{10,11}$"))
                return BadRequest("Số điện thoại phải có 10-11 chữ số.");

            // Validate Email
            if (string.IsNullOrWhiteSpace(custom.email))
                return BadRequest("Email không được để trống.");
            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(custom.email))
                return BadRequest("Email không hợp lệ.");

            // Validate Address
            if (!string.IsNullOrWhiteSpace(custom.address) && custom.address.Length > 100)
                return BadRequest("Địa chỉ không được dài quá 100 ký tự.");

            try
            {
                var result = await _customService.CreateCustomer(custom);

                if (result != Notification.Created)
                {
                    return StatusCode(500, "Có lỗi xảy ra khi tạo khách hàng.");
                }

                return StatusCode(201, "khách hàng được tạo thành công "
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpPost ("CreateOder")]

        public async Task<IActionResult> CreateOrder([FromBody] OrderRequet orderRequet )
        {
          var result =  await _customService.CreateOrderAsync( orderRequet);
            return StatusCode(201, result);
        }
    }
}
