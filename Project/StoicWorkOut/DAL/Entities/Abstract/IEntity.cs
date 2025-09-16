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

    }
}
