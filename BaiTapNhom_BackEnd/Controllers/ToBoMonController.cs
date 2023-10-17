using BaiTapNhom_BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTapNhom_BackEnd.Controllers 
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ToBoMonController : ControllerBase //Trương Nguyên Giáp người hoàn thành
    {
        private readonly BaiTapNhomBackEndDBConText _ToBoMon;
        public ToBoMonController(BaiTapNhomBackEndDBConText toBoMon)
        {
            _ToBoMon = toBoMon;
        }
        //Get:api/ToBoMon
        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            List<ToBoMon>? ToList = null;
            try
            {
                ToList = await _ToBoMon.Set<ToBoMon>().FromSqlInterpolated($"EXEC PSP_GetAll_ToBoMon").ToListAsync();
                if(ToList==null)
                {
                    NotFound();
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(ToList);
        }
        //Get:api/ToBoMon/id
        [HttpGet("GetbyID")]
        public async Task<IActionResult> GetbyID(int id)
        {
            List<ToBoMon>? ToList = null;
            try
            {
                ToList = await _ToBoMon.Set<ToBoMon>().FromSqlInterpolated($"EXEC PSP_GetID_ToBoMon {id}").ToListAsync();
                if(ToList==null)
                {
                    NotFound();
                }    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(ToList);
        }
        //Post:api/ToBoMon 
        [HttpPost]
        public async Task<IActionResult> Insert(string tentobomon,string ghichu,string totruong,bool isdelete)
        {
            int idtobomon = 0;
            await _ToBoMon.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_Insert_ToBoMon {idtobomon},{tentobomon},{ghichu},{totruong},{isdelete}");
            return Ok();
        }
        //Put:api/ToBoMon
        [HttpPut]
        public async Task<IActionResult> Update(int idTobomon,ToBoMon tbm)
        {
            try
            {
                List<ToBoMon>? ToList = null;
                ToList = await _ToBoMon.Set<ToBoMon>().FromSqlInterpolated($"EXEC PSP_GetID_ToBoMon {idTobomon}").ToListAsync();
                if (ToList == null)
                {
                    return NotFound();
                }
                else
                    ToList[0].TenToBoMon = tbm.TenToBoMon;
                    ToList[0].GhiChu = tbm.GhiChu;
                    ToList[0].ToTruong = tbm.ToTruong;
                    ToList[0].IsDelete = tbm.IsDelete;
                await _ToBoMon.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_Update_ToBoMon {ToList[0].IDToBoMon}, {ToList[0].TenToBoMon},{ToList[0].GhiChu},{ToList[0].ToTruong},{ToList[0].IsDelete}");
                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return NoContent();
        }
        //Delete:api/ToBoMon
        [HttpDelete]
        public async Task<IActionResult> Delete(int idtobomon)
        {
            await _ToBoMon.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_Delete_ToBoMon {idtobomon}");
            return Ok();
        }

    }
}
