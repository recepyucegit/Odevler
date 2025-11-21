using BLL.Services.DTOs;
using DAL.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IOrderDetailServiceManager : IServiceManager<OrderDetail>
    {
        // OrderDetail'a özel metotlar ekleyebilirsiniz.

        //GetTotal Revenue isminde bir metot oluşturarak içerisinde toplam geliri döndüren metot.
        decimal GetTotalRevenue();

        List<OrderDetailDTO> GetUserOrderDetail();

    }
}
