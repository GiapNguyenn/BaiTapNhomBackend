using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_BackEnd.Data
{
    public class ToBoMon
    {
        [Key] public int IDToBoMon { get; set; }
        [Required]
        public string? TenToBoMon { get;set; }
        public string? GhiChu { get;set; }
        public string? ToTruong { get;set; }   
        public bool IsDelete { get;set; }
    }
}
