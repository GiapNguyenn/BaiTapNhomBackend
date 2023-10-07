﻿using Microsoft.EntityFrameworkCore;
namespace BaiTapNhom_BackEnd.Data
{
    public class ToBoMonConText:DbContext
    {
        public ToBoMonConText(DbContextOptions<ToBoMonConText> options) :base(options)
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
    }
}