using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Data
{
    [Table("NienKhoa")]
    public class NienKhoa
    {
        [Key]
        [StringLength(8)]
        public string IDNienKhoa { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string TenNienKhoa { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string NamBD { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string NamTotNghiep { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayXetDungDot { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(250)]
        public string? MoTa { get; set; }
        [Column(TypeName = "bit")]
        [Required]
        public bool IsDelete { get; set; }
    }
}
