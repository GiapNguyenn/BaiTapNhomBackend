using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Models
{
    public class LoaiMon
    {
        [Key]
        public int IDLoaiMon { get; set; }
        [Required]
        public string? TenLoaiMon { get; set; }
        public string? Mota { get; set; }
        public bool IsDelete { get; set; }

    }
}
