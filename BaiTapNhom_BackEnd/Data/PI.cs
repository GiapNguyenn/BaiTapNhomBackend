using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Data
{
    [Table("PI")]
    public class PI
    {
        [Key]
        public int IDPI { get; set; }
        public string PIKiHieu { get; set; }
        public string PItiengAnh { get; set; }
        public string? PITiengViet { get; set; }
        public string PhuongPhapDanhGia { get; set; }
        public string CongCuDanhGia { get; set; }
        [Column(TypeName = "float")]
        public float? Target { get; set; }
        public string? MoTa { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public int IDSO { get; set; }
    }
}
