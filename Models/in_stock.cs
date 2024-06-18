using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class in_stock
    {
        [Key]
        [Required]
        public int stock_id { get; set; }
        [Required]
        public string part_number { get; set; }
        [Required]
        public int quantity_in_stock { get; set; }
    }
}