using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcCreditApp.Models
{
    public class Bid
    {

        public virtual int BidId { get; set; }

        [Required]
        [DisplayName("Имя заявителя")]
        public virtual string Name { get; set; }

        [Required]
        [DisplayName("Тип кредита")]
        public virtual string CreditHead { get; set; }

        [Required]
        [DisplayName("Дата заявки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public virtual DateTime bidDate { get; set; }
    }
}
