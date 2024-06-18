using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class persons
    {
        [Key]
        [Required]
        public int person_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string account_id { get; set; }
        [Required]
        public int is_worker { get; set; }
    }
}