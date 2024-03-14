using System.ComponentModel.DataAnnotations;

namespace SoftwareCompany.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Введіть назву послуги")]

        [Display(Name = "Назва послуги")]
        public override string Title { get; set; }

        [Display(Name = "Короткий опис послуги")]
        public override string SubTitle { get; set; }

        [Display(Name = "Повний опис послуги")]
        public override string Text { get; set; }

    }
}
