using BaiTapNhom_BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaiTapNhom_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        BaiTapNhomBackEndDBConText _context;
        public SinhVienController(BaiTapNhomBackEndDBConText context)
        {
            _context = context;

        }

        /// <summary>
        /// Lấy danh sách sinh viên theo phân trang.
        /// vi lay 1 lan 4000 sinh vien hoi lau vs lag
        /// </summary>
        /// <param name="pageIndex">Chỉ số trang (1, 2, 3, ...)</param>
        /// <param name="pageSize">Kích thước trang (số lượng sinh viên trên mỗi trang)</param>
        /// <returns>Danh sách sinh viên trên trang tương ứng</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            //List<SinhVien> allSinhVienList = await _context.SinhViens.ToListAsync();
            List<SinhVien> allSinhVienList = await _context.Set<SinhVien>().FromSqlInterpolated($"Select * from SinhVien").ToListAsync();
            int totalItemCount = allSinhVienList.Count;
            int startIndex = (pageIndex - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize - 1, totalItemCount - 1);

            List<SinhVien> pagedSinhVienList = allSinhVienList.GetRange(startIndex, endIndex - startIndex + 1);
            Console.WriteLine($"so luong Sinh vien la: {pagedSinhVienList.Count}");
            return Ok(pagedSinhVienList);

        }

        // GET api/<SinhVienController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            List<SinhVien> listSV = new List<SinhVien>();
            try
            {
                listSV = await (from sv in _context.sinhviens where sv.MSSV == id select sv).ToListAsync();
                if (listSV == null)
                    return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:  {ex.Message}");
            }
            return Ok(listSV);
        }

        // POST api/<SinhVienController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SinhVien value)
        {

            int count = 0;
            try
            {
                count = await _context.Database.ExecuteSqlInterpolatedAsync($@"insert into SinhVien (MSSV,HoSinhVien,TenSinhVien,GioiTinh,Lop,IsDelete,TrangThai,DiaChi,DienThoai,CCCD)
                                                                            values ({value.MSSV},{value.HoSinhVien},{value.TenSinhVien},{value.GioiTinh},{value.lop},{value.IsDelete},
                                                                            {value.TrangThai},{value.DiaChi},{value.DienThoai},{value.CCCD})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:  {ex.Message}");
            }
            return Ok(count);
        }

        // PUT api/<SinhVienController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SinhVien value)
        {
            int count = 0;
            try
            {
                count = await _context.Database.ExecuteSqlInterpolatedAsync($@"Update SinhVien set HoSinhVien = {value.HoSinhVien},
                                                                            TenSinhVien = {value.TenSinhVien},GioiTinh = {value.GioiTinh},Lop = {value.lop},
                                                                            IsDelete = {value.IsDelete},TrangThai = {value.TrangThai},DiaChi = {value.DiaChi},
                                                                            DienThoai = {value.DienThoai},CCCD = {value.CCCD} where MSSV = {value.MSSV}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:  {ex.Message}");
            }
            return Ok(count);
        }

        // DELETE api/<SinhVienController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            int count = 0;
            try
            {
                count = await _context.Database.ExecuteSqlInterpolatedAsync($"Delete SinhVien where MSSV = {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:  {ex.Message}");
            }
            return Ok(count);
        }
    }
}

