using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Abstracts
{
    internal interface IEntity<T>
    {
        //ID
        public int ID { get; set; } //veritabanında her nesnenin benzersiz kimliği

        public T MasterId { get; set; }

        //Oluşturulma zamanı
        public DateTime CreatedDate { get; set; }

        //Değişiklik zamanı
        public DateTime? ModifiedDate { get; set; }

        //Hangi bilgisayardan o verinin oluşturulduğu
        public string ComputerName { get; set; }

        //verinin değiştirildiği bilgisayarın adı
        public string ModifiedComputerName { get; set; }

        //Hangi ip adresinden tanımlandığı
        public string IpAddress { get; set; }

        //Durumların temsil edilmesi (verinin aktif olup olmaması)
        public DataStatus Status { get; set; }
    }
}
