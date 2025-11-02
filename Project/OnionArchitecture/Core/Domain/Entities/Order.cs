using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }

        // Foreign Keys
        public int UserId { get; set; }

        // Navigation Properties 

        //public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}