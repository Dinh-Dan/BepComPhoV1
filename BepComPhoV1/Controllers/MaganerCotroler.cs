using Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model.Entitys;
using Model.RequestModel.ImaganerService;
using Service.IService;
using Service.Service;

namespace BepComPhoV1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaganerController : ControllerBase
    {
        private readonly IMaganerService _maganerService;

        // Inject service qua constructor
        public MaganerController(IMaganerService maganerService)
        {
            _maganerService = maganerService;
        }

        [HttpPost("add-eating")]
        public async Task<IActionResult> AddEating([FromBody] addEating newEating)
        {
            if (newEating == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _maganerService.AddEating(newEating);

            return BadRequest(result);
        }
        [HttpPost("addMenu")]
        public async Task <IActionResult> AddMenu([FromBody] newMenuDay newMenu)
        {
            if (newMenu == null || newMenu.lstMainDishes.Count==0) return BadRequest("Lỗi dữ liệu Của Menu");

            var result = _maganerService.AddMenu(newMenu);


           return Ok(result);
        }

        [HttpGet("TatCaMonAn")]
        public async Task<IActionResult> GetAllEating()
        {
            var eatings = await _maganerService.GetListEating();

            if (eatings == null || eatings.Count == 0)
            {
                return NotFound(new { Message = "No eatings found." });
            }

            return Ok(eatings);
        }
    }
}
