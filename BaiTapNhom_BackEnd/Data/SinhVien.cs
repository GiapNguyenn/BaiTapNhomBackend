using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Data
{
    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public string MSSV { get; set; }
        public string HoSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public bool? GioiTinh { get; set; }
        public string lop { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public int TrangThai { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? CCCD { get; set; }
    }
}
