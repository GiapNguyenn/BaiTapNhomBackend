using BaiTapNhom_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
namespace BaiTapNhom_BackEnd.Data
{
    public class BaiTapNhomBackEndDBConText:DbContext
    {
        public BaiTapNhomBackEndDBConText(DbContextOptions<BaiTapNhomBackEndDBConText> options) :base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer("name=ConnectionStrings:DefaultConnection");
                base.OnConfiguring(optionsBuilder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"eror ToBoMon {ex.Message}");
            }
        }
        public DbSet<ToBoMon> toBoMons { get;set; }
        public DbSet<NienKhoa> nienKhoas { get;set; }
        public DbSet<Blooms> blooms { get;set; }
        public DbSet<TinhTrangPhanMon> tinhTrangPhanMons { get;set; }
        public DbSet<HeDaoTao> heDaoTao { get;set;}
        public DbSet<LoaiMon> loaiMons { get; set; }
        public DbSet<SinhVien> sinhviens { get; set; }
        public DbSet<PI> pi { get; set; }

    }

}
