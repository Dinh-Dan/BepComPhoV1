using Common;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entitys;
using Model.RequestModel.Custom;
using Model.ResponseModel.CustomRepon;
using Service.IService;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Service.Service
{
    public class CustomService : ICustomService
    {
        private readonly AppDbcontext _context;
        public CustomService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<GetMenuDay> GetMenuDay(string date)
        {
            var menuDay = new GetMenuDay();

            // Chuyển chuỗi ngày thành kiểu DateTime
            if (DateTime.TryParse(date, out DateTime targetDate))
            {
                // Truy vấn cơ sở dữ liệu để lấy các menu có ngày trùng với targetDate
                var menus = _context.menus
                    .FirstOrDefault(menu => menu.Date.Date == targetDate.Date); // Chỉ so sánh ngày (bỏ qua thời gian)

                // Nếu tìm thấy các menu, tạo đối tượng GetMenuDay và trả về
                if (menus != null)
                {
                    menuDay.Date = menus.Date;
                    menuDay.dessert = menus.dessert;
                    menuDay.note = menus.note;
                    menuDay.Id = menus.Id;

                    // Truy vấn danh sách món ăn trong menu
                    var lstIds = await _context.menuDetails
                        .Where(ea => ea.MenuId == menuDay.Id)
                        .Select(ea => ea.EatingId) // Chọn chỉ thuộc tính Id
                        .ToListAsync();

                    menuDay.lstEating = await _context.eatings
     .Where(eating => lstIds.Contains(eating.Id)) // Kiểm tra nếu Id của Eating nằm trong lstIds
     .ToListAsync();

                    // Gán danh sách vào menuDay (nếu cần thêm trường hoặc xử lý)
                    // menuDay.EatingDetails = lstEating;

                    return menuDay;
                }
                else
                {
                    return null; // Không tìm thấy menu
                }
            }
            else
            {
                return null; // Ngày không hợp lệ
            }
        }



        public async Task<Notification> CreateCustomer(CreateCustomer newCustomer)
        {
            Random random = new Random();
            var nuber = random.Next(10000, 100000);
            var custom = new Customer
            {
                address = newCustomer.address,
                addMap = "21.024670, 105.754704",
                email = newCustomer.email,
                numberPhone = newCustomer.numberPhone,
                name = newCustomer.name,
                timeLate = newCustomer.timeLate,
                CODE = nuber.ToString()
            };
            try
            {
                _context.Customer.Add(custom);

                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();  // Sử dụng SaveChangesAsync() cho phương thức bất đồng bộ

                return Notification.Created;  // Trả về thông báo thành công

            }
            catch (Exception ex)
            {
                // Xử lý các lỗi không xác định khác
                return Notification.InternalServerError; // Trả về thông báo lỗi chung
            }
        }


        public async Task<Notification> CreateOrderAsync(OrderRequet newOrder)
        {
            try
            {
                // Tính toán tổng giá trị đơn hàng
                var PriceTes = newOrder.Detai.Sum(x => x.Quantity * x.Pirce);

                // Lấy thông tin shipper gần nhất đã giao cho customer
                var latestShipper = await GetLatestShipperForCustomerAsync(newOrder.IDCustom);

                if (latestShipper == null)
                {
                    latestShipper = _context.shipers.FirstOrDefault(x => x.Id >= 0);
                }

                // Tạo đối tượng Order từ OrderRequet
                var order = new Order()
                {
                    DateTimeOrder = newOrder.DateTimeOrder,
                    Note = newOrder.Note,
                    StatusOrder = StatusOder.received,
                    IsDessert = newOrder.IsDessert,
                    PriceOrder = newOrder.PriceOrder,
                    Sum = PriceTes,
                    CustomId = 1,  // Giả sử customerId = 1 (có thể thay đổi tùy thuộc vào input)
                    ShiperId = latestShipper.Id, // Gán shipper gần nhất
                };

         
                _context.oders.Add(order);
                await _context.SaveChangesAsync();

                
                var orderId = order.Id;
                // Thêm danh sách chi tiết đơn hàng
                foreach (var orderDetail in newOrder.Detai)
                {
                    var newOrderDetail = new OrderDetail()
                    {
                        OrderId = orderId,
                        EatingId = orderDetail.EatingId,
                        Count = orderDetail.Quantity,
                        Pirce = orderDetail.Pirce, 
                    };
                    _context.orderDetails.Add(newOrderDetail);


                    
                }

                await _context.SaveChangesAsync();



                // add vào bộ nhớ ram
              
               


                return Notification.Created;  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra khi tạo đơn hàng: {ex.Message}");
                return Notification.Conflict; 
            }
        }


        public async Task<Order> GetOrderByCustomerIdAsync(int customerId)
        {
            

            // 2. Nếu không tìm thấy trong bộ nhớ, tìm trong cơ sở dữ liệu
            var orderFromDb = await _context.oders
                .Include(o => o.OrderDetails) // Lấy chi tiết đơn hàng
                .FirstOrDefaultAsync(o => o.CustomId == customerId);

            // 3. Nếu không có trong cơ sở dữ liệu, trả về null
            return orderFromDb;
        }



        // Phương thức lấy shipper gần nhất của customer
        public async Task<Shiper> GetLatestShipperForCustomerAsync(int customerId)
        {
            var latestShipper = await _context.oders
                .Where(o => o.CustomId == customerId && o.ShiperId.HasValue)  
                .OrderByDescending(o => o.DateTimeOrder)  
                .Select(o => o.Shiper)
                .FirstOrDefaultAsync();

            return latestShipper;  
        }


        public async Task<Notification> UpdateOrder(OrderRequet newOrder)
        {

            return Notification.OK;
        }
    }


}
