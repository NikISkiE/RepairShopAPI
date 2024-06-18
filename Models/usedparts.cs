using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class usedparts
    {
        [Key]
        [Required]
        public int used_id { get; set; }
        public int part_id { get; set; }
        public int appointment_id { get; set; }
    }
}