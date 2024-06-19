using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class appointments
    {
        [Key]
        [Required]
        public int appointment_id { get; set; }
        public int client_id { get; set; }
        public int worker_id { get; set; }
        [Required]
        public DateTime appointment_start { get; set; }
        public DateTime appointment_aproximated { get; set; }
        public DateTime appointment_end { get; set; }
        public string appointment_reason { get; set; }
        public string status { get; set; }
    }
}