using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcCreditApp.Models
{
    public class Credit
    {
        public virtual int CreditId { get; set; }

        [Required]
        [DisplayName("Название кредита")]
        public virtual string Head { get; set; }

        [Required]
        [DisplayName("Период кредита")]
        public virtual int Period { get; set; }

        [Required]
        [DisplayName("Сумма кредита")]
        public virtual int Sum { get; set; }

        [Required]
        [DisplayName("Процент кредита")]
        public virtual int Procent { get; set; }
    }
}
