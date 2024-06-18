using System.ComponentModel.DataAnnotations;

namespace RepairShopAPI
{
    public class accounts
    {
        [Key]
        [Required]
        public int account_id { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public int perm_lvl { get; set; }
        [Required]
        public string password { get; set; }
    }
}