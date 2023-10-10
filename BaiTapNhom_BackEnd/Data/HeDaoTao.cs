using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Data
{
    public class HeDaoTao
    {
        [Key]
        public int IDHeDaoTao { get; set; }
        [Required]
        public string TenHeDaoTao { get; set; }
        public string MoTa {  get; set; }
        public bool IsDelete { get; set; }

    }
}
