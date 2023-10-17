using BaiTapNhom_BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaiTapNhom_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloomsController : ControllerBase
    {
        BaiTapNhomBackEndDBConText dbContext;
        public BloomsController(BaiTapNhomBackEndDBConText db) => dbContext = db;
        // GET: api/<BloomsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list =await dbContext.blooms.ToListAsync();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        // GET api/<BloomsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var list =await (from Blooms in dbContext.blooms where Blooms.IDBlooms == id select Blooms).ToListAsync();
            if (list == null)
                return NotFound();
            return Ok(list);
        }


        // POST api/<BloomsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blooms value)
        {
            int num = 0;
            try
            {
                num = await dbContext.Database.ExecuteSqlInterpolatedAsync($"insert into Blooms(BloomsLevel,BloomsLevelTV,BloomType,Descriptions,LevelType,Activity,Target,KeyWords,ExampleCLO,TemplateQuestion,IsDelete) values ({value.BloomsLevel},{value.BloomsLevelTV},{value.BloomType},{value.Descriptions},{value.LevelType},{value.Activity},{value.Target},{value.KeyWords},{value.ExampleCLO},{value.TemplateQuestion},{value.IsDelete})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(num);
        }

        // PUT api/<BloomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Blooms value)
        {
            int num = 0;
            try
            {
                num = await dbContext.Database.ExecuteSqlInterpolatedAsync($"update Blooms set BloomsLevel={value.BloomsLevel},BloomsLevelTV={value.BloomsLevelTV},BloomType={value.BloomType},Descriptions={value.Descriptions},LevelType={value.LevelType},Activity={value.Activity},Target={value.Target},KeyWords={value.KeyWords},ExampleCLO={value.ExampleCLO},TemplateQuestion={value.TemplateQuestion},IsDelete={value.IsDelete} where IDBlooms ={id} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(num);
        }

        // DELETE api/<BloomsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int num = 0;
            try
            {
                num = await dbContext.Database.ExecuteSqlInterpolatedAsync($"delete Blooms where IDBlooms = {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return Ok(num);
        }
    }
}
