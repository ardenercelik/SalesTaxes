using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SalesTaxesAPI.Models
{
    public class TaxableItem : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxableItemId { get; set; }
        [Required]
        public string Name{ get; set; }
        
        [Required]
        public bool IsExempt { get; set; }
        [Required]
        public bool IsImported { get; set; }
        public double TaxValue { get; set; }
        public double TaxRate { get; set; }
        [Required]
        public double BasePrice { get; set; }

    }
    

    public class TaxableItemPostDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsExempt { get; set; }
        [Required]
        public bool IsImported { get; set; }
        [Required]
        public double BasePrice { get; set; }
    }
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }
        public DateTime DateCreated{ get; set; }
        
        public DateTime DateUpdated { get; set; }
    }

    

    

}
