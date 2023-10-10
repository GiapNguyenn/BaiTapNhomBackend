using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Data
{
    public class TinhTrangPhanMon
    {
        [Key]
        public int IDTTPhanMon { get; set; }
        [Required]
        public string NoiDung { get; set; }
        public bool IsDelete { get; set; }

    }
}
