using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Abstract
{
    public interface IEntity<T>
    {
        public int ID { get; set; }
        // Master Id oluştur T tipinde
        public T MasterId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ComputerName { get; set; }
        public string UpdatedComputerName { get; set; }
        public string IpAddress { get; set; }
        public DataStatus Status { get; set; }
    }
}
