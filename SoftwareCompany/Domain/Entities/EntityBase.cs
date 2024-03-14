using System.ComponentModel.DataAnnotations;

namespace SoftwareCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;  
        
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Заголовок")]
        public virtual string ?Title { get; set; }

        [Display(Name = "Підзаголовок")]
        public virtual string ?SubTitle { get; set; }

        [Display(Name = "Опис")]
        public virtual string ?Text { get; set; }

        [Display(Name = "Зображення")]
        public virtual string ?TitleImagePath { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string? MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string ?MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string ?MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
