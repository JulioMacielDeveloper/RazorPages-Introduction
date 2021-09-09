using System.ComponentModel.DataAnnotations;

namespace RazorPagesIntroduction.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(10)] // Data Annotations
        public string Name { get; set; }
    }
}