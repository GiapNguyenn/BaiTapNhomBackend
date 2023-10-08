using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapNhom_BackEnd.Data
{
    [Table("Blooms")]
    public class Blooms
    {
        [Key]
        [Column(TypeName ="int")]
        public int IDBlooms { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string BloomsLevel { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(250)]
        public string BloomsLevelTV { get; set; }
        [Column(TypeName = "int")]
        public int BloomType { get; set; }
        [Column(TypeName = "ntext")]
        [StringLength(50)]
        public string Descriptions { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(150)]
        public string LevelType {  get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(250)]
        public string? Activity { get; set; }
        [Column(TypeName = "Nvarchar")]
        public string? Target {  get; set; }
        [Column(TypeName = "ntext")]
        public string? KeyWords { get; set; }
        [Column(TypeName = "ntext")]
        public string? ExampleCLO { get; set; }
        [Column(TypeName = "ntext")]
        public string? TemplateQuestion { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool IsDelete { get; set; }
    }
    
}
