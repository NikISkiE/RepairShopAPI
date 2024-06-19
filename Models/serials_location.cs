using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class serials_location
    {
        [Key]
        [Required]
        public int serial_id { get; set; }
        [Required]
        public int part_id { get; set; }
        [Required]
        public string serial { get; set; }
        public string localisation { get; set; }
    }
}