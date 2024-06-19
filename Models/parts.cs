using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class parts
    {
        [Key]
        [Required]
        public int part_id { get; set; }
        [Required]
        public string part_name { get; set; }
        [Required]
        public string part_number { get; set; }
        public string manufacturer { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public string in_stock { get; set; }
    }
}