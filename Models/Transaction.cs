using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHomeBudget.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Доходы/Расходы")]
        public bool IsIncome { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public CategoryType Category { get; set; }

        [Required]
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Display(Name = "Примечание")]
        public string? Comment { get; set; }
        
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
