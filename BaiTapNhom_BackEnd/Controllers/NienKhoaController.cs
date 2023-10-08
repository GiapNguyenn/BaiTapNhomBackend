using BaiTapNhom_BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaiTapNhom_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NienKhoaController : ControllerBase
    {
        private readonly ToBoMonConText _context;
        public NienKhoaController(ToBoMonConText context)
        {
            _context = context;
        }

        // GET: api/<NienKhoaController>
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            List<NienKhoa> nienKhoaItems = new List<NienKhoa>();
            try
            {
                nienKhoaItems =await _context.nienKhoas.ToListAsync();
                if (nienKhoaItems == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(nienKhoaItems);
        }

        // GET api/<NienKhoaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            List<NienKhoa> lisNK = new List<NienKhoa>();
            lisNK = await (from NK in _context.nienKhoas where NK.IDNienKhoa == id select NK).ToListAsync();
            if (lisNK == null)
            { return NotFound(); }

            return Ok(lisNK);
        }

        // POST api/<NienKhoaController>
        [HttpPost]
        public async Task<IActionResult> Post(string idNK, string nameNK, string namBD, string namTN, DateTime ngayXet, string mota, bool isdelete)
        {
            int num = 0;
            try
            {
                num = await _context.Database.ExecuteSqlInterpolatedAsync($"insert into NienKhoa(IDNienKhoa,TenNienKhoa,NamBD,NamTotNghiep,NgayXetDungDot,MoTa,IsDelete) values({idNK},{nameNK},{namBD},{namTN},{ngayXet},{mota},{isdelete}) ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(num);
        }

        // PUT api/<NienKhoaController>/5
        [HttpPut]
        public async Task<IActionResult> Put(string idNK, string nameNK, string namBD, string namTN, DateTime ngayXet, string mota, bool isdelete)
        {
            int num = 0;
            try
            {
                num = await _context.Database.ExecuteSqlInterpolatedAsync($"update NienKhoa set TenNienKhoa = {nameNK},NamBD = {namBD},NamTotNghiep= {namTN},NgayXetDungDot= {ngayXet},MoTa= {mota},IsDelete= {isdelete} where IDNienKhoa = {idNK} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(num);
        }

        // DELETE api/<NienKhoaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            int num = 0;
            try
            {
                num = await _context.Database.ExecuteSqlInterpolatedAsync($"delete NienKhoa where IDNienKhoa = {id} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(num);
        }
    }
}
