using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiTapNhom_BackEnd.Models;
using BaiTapNhom_BackEnd.Data;

namespace BaiTapNhom_BackEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeDaoTaoController : ControllerBase
    {
        private readonly ToBoMonConText _context;
        public HeDaoTaoController(ToBoMonConText context)
        {
            _context = context;
        }
        // Get:API: LoaiMon/{id}
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            List<HeDaoTao>? TodoList = null;
            try
            {
                TodoList = await _context.Set<HeDaoTao>().FromSqlInterpolated($"EXEC PSP_HeDaoTao_getHeDaoTao").ToListAsync();
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
        public async Task<IActionResult> Creat(string tenHeDaoTao, string moTa, bool isDelete)
        {
            int idHeDaoTao = 0;
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_HeDaoTao_insertHeDaoTao {idHeDaoTao},{tenHeDaoTao},{moTa},{isDelete}");
            return Ok();
        }
        [HttpGet("idHeDaoTao")]
        public async Task<IActionResult> Read(int idHeDaoTao)
        {
            List<HeDaoTao>? TodoList = null;
            try
            {
                TodoList = await _context.Set<HeDaoTao>().FromSqlInterpolated($"EXEC PSP_HeDaoTao_getHeDaoTaoByID {idHeDaoTao}").ToListAsync();
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
        [HttpPut("{idHeDaoTao}")]
        public async Task<IActionResult> Update(int idHeDaoTao, HeDaoTao entity)
        {
            try
            {

                List<HeDaoTao> existingEntity = await _context.Set<HeDaoTao>()
                                 .FromSqlInterpolated($"EXEC PSP_HeDaoTao_getHeDaoTaoByID {idHeDaoTao}")
                                 .ToListAsync();

                if (existingEntity == null)
                {
                    return NotFound();
                }

                existingEntity[0].TenHeDaoTao = entity.TenHeDaoTao;
                existingEntity[0].MoTa = entity.MoTa;
                existingEntity[0].IsDelete = entity.IsDelete;

                int DaoTao = await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC PSP_HeDaoTao_updateHeDaoTao {existingEntity[0].IDHeDaoTao}, {existingEntity[0].TenHeDaoTao},{existingEntity[0].MoTa}, {existingEntity[0].IsDelete}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("idHeDaoTao")]
        public async Task<IActionResult> Delete(int idHeDaoTao)
        {
            List<HeDaoTao> existingEntity = await _context.Set<HeDaoTao>().FromSqlInterpolated($"EXEC PSP_HeDaoTao_getHeDaoTaoByID {idHeDaoTao}").ToListAsync();
            if (existingEntity == null)
            {
                return NotFound();
            }
            int DaoTao = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_HeDaoTao_deleteHeDaoTao {idHeDaoTao}");
            return Ok(DaoTao);
        }

    }
}