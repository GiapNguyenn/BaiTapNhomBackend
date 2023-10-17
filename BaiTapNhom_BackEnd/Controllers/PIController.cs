using BaiTapNhom_BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaiTapNhom_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PIController : ControllerBase
    {
        public BaiTapNhomBackEndDBConText _context { get; set; }
        public PIController(BaiTapNhomBackEndDBConText context) => _context = context;
        // GET: api/<PIController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<PI> listPI = new List<PI>();
            try
            {
                listPI = await _context.Set<PI>().FromSqlInterpolated($"EXEC PSP_PI_Select").ToListAsync();
                if (listPI == null)
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(listPI);
        }

        // GET api/<PIController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            List<PI> listPI = new List<PI>();
            try
            {
                listPI = await _context.Set<PI>().FromSqlInterpolated($"EXEC PSP_PI_Select {id}").ToListAsync();
                if (listPI == null)
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(listPI);
        }

        // POST api/<PIController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PI value)
        {
            int count = 0;
            try
            {
                count = await _context.Database
                    .ExecuteSqlInterpolatedAsync($@"exec PSP_PI_Insert_and_Update {value.IDPI},{value.PIKiHieu},{value.PItiengAnh},{value.PITiengViet},
                                                  {value.PhuongPhapDanhGia},{value.CongCuDanhGia},{value.Target},{value.MoTa},{value.IsDelete},{value.IDSO} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(count);
        }

        // PUT api/<PIController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PI value)
        {
            int count = 0;
            try
            {
                count = await _context.Database
                    .ExecuteSqlInterpolatedAsync($@"exec PSP_PI_Insert_and_Update {value.IDPI},{value.PIKiHieu},{value.PItiengAnh},{value.PITiengViet},
                                                  {value.PhuongPhapDanhGia},{value.CongCuDanhGia},{value.Target},{value.MoTa},{value.IsDelete},{value.IDSO} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(count);
        }

        // DELETE api/<PIController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int count = 0;
            try
            {
                count = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PSP_PI_DeleteById {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(count);
        }
    }
}
