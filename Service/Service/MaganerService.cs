using Common;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entitys;
using Model.RequestModel.ImaganerService;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MaganerService : IMaganerService
    {
        private readonly AppDbcontext _context;
        public MaganerService(AppDbcontext context)
        {
            _context = context;
        
        }



        public async Task<Notification> AddEating(addEating newEating)
        {
            // Kiểm tra điều kiện hợp lệ trước khi lưu
            if (string.IsNullOrEmpty(newEating.Name) || newEating.Name.Length > 30 || newEating.type == null)
            {
                return Notification.NotAcceptable;
            }

            try
            {
                // Thêm đối tượng Eating vào context
                _context.eatings.Add(new Model.Entitys.Eating()
                {
                    Name = newEating.Name,
                    describe = newEating.describe,
                    type = newEating.type,
                });

                // Lưu các thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                // Trả về thông báo thành công
                return Notification.Created;
            }
            catch (Exception ex)
            {
                // Ghi log chi tiết lỗi nếu có vấn đề trong quá trình lưu
                Console.WriteLine($"Error: {ex.Message}");
                return Notification.BadRequest;  // Đảm bảo bạn có thông báo lỗi phù hợp với ứng dụng của bạn
            }
        }

        public Task<List<Eating>> GetListEating()
        {
            return _context.eatings.ToListAsync();
        }


        public Notification AddMenu(newMenuDay newMenu)
        {
          
            var menu = new Menu
            {
                Date = newMenu.DateTime,
                dessert = newMenu.dessert,
                note = newMenu.Note
            };

            _context.menus.Add(menu);

            _context.SaveChanges();

           //  duyệt danh sách các món chính và số lượng để add vào db
            foreach (var item in newMenu.lstMainDishes) {

                var menuDetail = new MenuDetail
                {
                    MenuId=menu.Id,

                    EatingId = item.IdEating,

                    Quantity = item.TotalEating,
                };

                _context.menuDetails.Add(menuDetail);
            }
            // duyệt các món phụ trong ngày id  vào db
            foreach (var item in newMenu.lstSideDishes)
            {
                var menuDetail = new MenuDetail
                {
                    MenuId = menu.Id,

                    EatingId = item,

                    Quantity = 0
                };
                _context.menuDetails.Add(menuDetail);
            }    


          

            _context.SaveChanges();

            return Notification.Created;
        }

    }
}
