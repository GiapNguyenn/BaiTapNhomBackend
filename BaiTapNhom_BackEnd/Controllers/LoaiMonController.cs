using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
using BaiTapNhom_BackEnd.Models;

namespace BaiTapNhom_BackEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiMonController : ControllerBase
    {
        private readonly TodoContext _context;
        public LoaiMonController(TodoContext context)
        {
            _context = context;
        }
        // Get:API: LoaiMon/{id}
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            List<LoaiMon> ?TodoList = null;
            try
            {
                TodoList = await _context.Set<LoaiMon>().FromSqlInterpolated($"EXEC PSP_LoaiMon_GetAll").ToListAsync();
                if (TodoList == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(TodoList);

        }
        [HttpPost]
        public async Task<IActionResult> Creat(string tenLoaiMon, string moTa, bool isDelete)
        {
            int idLoaiMon = 0;
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_LoaiMon_InsertLoaiMon {idLoaiMon},{tenLoaiMon},{moTa},{isDelete}");
            return Ok();
        }
        [HttpGet("idloaimon")]
        public async Task<IActionResult> Read(int idLoaiMon)
        {
            List<LoaiMon>? TodoList = null;
            try
            {
                TodoList = await _context.Set<LoaiMon>().FromSqlInterpolated($"EXEC PSP_LoaiMon_GetIDLoaiMon {idLoaiMon}").ToListAsync();
                if (TodoList == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(TodoList);

        }
        [HttpDelete("idloaimon")]
        public async Task<IActionResult> Delete(int idLoaiMon)
        {
            List<LoaiMon> existingEntity = await _context.Set<LoaiMon>().FromSqlInterpolated($"EXEC PSP_LoaiMon_GetIDLoaiMon {idLoaiMon}").ToListAsync();
            if (existingEntity == null)
            {
                return NotFound();
            }
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_LoaiMon_DeleteLoaiMon {idLoaiMon}");
            return NoContent();
        }
    }
}
