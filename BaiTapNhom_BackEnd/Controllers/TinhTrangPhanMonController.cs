using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiTapNhom_BackEnd.Models;
using BaiTapNhom_BackEnd.Data;

namespace BaiTapNhom_BackEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangPhanMonController : ControllerBase
    {
        private readonly BaiTapNhomBackEndDBConText _context;
        public TinhTrangPhanMonController(BaiTapNhomBackEndDBConText context)
        {
            _context = context;
        }
        // Get:API: LoaiMon/{id}
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            List<TinhTrangPhanMon>? TodoList = null;
            try
            {
                TodoList = await _context.Set<TinhTrangPhanMon>().FromSqlInterpolated($"EXEC PSP_TinhTrangPhanMon_getTinhTrangPhanMon").ToListAsync();
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
        public async Task<IActionResult> Creat(string noiDung, bool isDelete)
        {
            int idTTPhanMon = 0;
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_TinhTrangPhanMon_insertTinhTrangPhanMon {idTTPhanMon},{noiDung},{isDelete}");
            return Ok();
        }
        [HttpGet("idTTPhanMon")]
        public async Task<IActionResult> Read(int idTTPhanMon)
        {
            List<TinhTrangPhanMon>? TodoList = null;
            try
            {
                TodoList = await _context.Set<TinhTrangPhanMon>().FromSqlInterpolated($"EXEC PSP_TinhTrangPhanMon_getTinhTrangPhanMonByID {idTTPhanMon}").ToListAsync();
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
        [HttpPut("{idTTPhanMon}")]
        public async Task<IActionResult> Update(int idTTPhanMon, TinhTrangPhanMon entity)
        {
            try
            {

                List<TinhTrangPhanMon> existingEntity = await _context.Set<TinhTrangPhanMon>()
                                 .FromSqlInterpolated($"EXEC PSP_TodoItem_SelectByID {idTTPhanMon}")
                                 .ToListAsync();

                if (existingEntity == null)
                {
                    return NotFound();
                }

                existingEntity[0].NoiDung = entity.NoiDung;
                existingEntity[0].IsDelete = entity.IsDelete;

                int PhanMon = await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC PSP_TinhTrangPhanMon_updateTinhTrangPhanMon {existingEntity[0].IDTTPhanMon}, {existingEntity[0].NoiDung}, {existingEntity[0].IsDelete}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("idTTPhanMon")]
        public async Task<IActionResult> Delete(int idTTPhanMon)
        {
            List<TinhTrangPhanMon> existingEntity = await _context.Set<TinhTrangPhanMon>().FromSqlInterpolated($"EXEC PSP_TinhTrangPhanMon_getTinhTrangPhanMonByID {idTTPhanMon}").ToListAsync();
            if (existingEntity == null)
            {
                return NotFound();
            }
            int PhanMon = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_TinhTrangPhanMon_deteleTinhTrangPhanMon {idTTPhanMon}");
            return Ok(PhanMon);
        }

    }
}