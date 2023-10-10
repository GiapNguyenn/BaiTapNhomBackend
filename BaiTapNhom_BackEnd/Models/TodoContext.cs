using BaiTapNhom_BackEnd.Data;
using Microsoft.EntityFrameworkCore;
namespace BaiTapNhom_BackEnd.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<LoaiMon> loaiMons { get; set; }
    }
}
