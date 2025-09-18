using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Abstract
{
    public abstract class BaseEntity : IEntity<Guid>

    {
        protected BaseEntity()
        {
            MasterId = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            ComputerName = Environment.MachineName;
            IpAddress = "192.168.1.1";
        }

        public int ID { get ; set ; }
        public Guid MasterId { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
        public string ComputerName { get ; set ; }
        public string UpdatedComputerName { get ; set ; }
        public string IpAddress { get ; set ; }
        public DataStatus Status { get ; set ; }
    }
}
