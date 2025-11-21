using BLL.Services.Abstracts;
using BLL.Services.DTOs;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class OrderDetailServiceManager : ServiceManager<OrderDetail>, IOrderDetailServiceManager
    {
        private readonly UserManager<IdentityUser> _userManager;

        public OrderDetailServiceManager(IRepository<OrderDetail> repository, UserManager<IdentityUser> userManager) : base(repository)
        {
            _userManager = userManager;
        }

        public decimal GetTotalRevenue()
        {
            // Toplam geliri hesaplamak için OrderDetail tablosundaki tüm kayıtların UnitPrice ve Quantity çarpımlarını toplarız.

            var totalRevenue=GetAll().Sum(od => od.UnitPrice * od.Quantity);
            return totalRevenue;

        }

        public List<OrderDetailDTO> GetUserOrderDetail()
        {
            var result = GetAll().Select(od => new OrderDetailDTO
            {
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                ProductName = od.Product.ProductName,
                Quantity = od.Quantity,
                UnitPrice = od.UnitPrice,
                UserId = od.Order.UserId,
                OrderDate = od.Order.OrderDate
            })
               .ToList<OrderDetailDTO>();
            return result;
        }
    }
}
