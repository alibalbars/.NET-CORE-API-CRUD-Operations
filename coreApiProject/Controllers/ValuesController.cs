using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreApiProject.Data;
using coreApiProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
//using System.Web.Http;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace coreApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly DatabaseContext context;
        public ValuesController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            return Ok("bingollu");
        }

        [HttpGet("category")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAllCat()
        {
            var dataset = await context.Categories.Where(s => s.Hidden == true).ToListAsync();
            return Ok(dataset);
        }

        [HttpGet("todo")]
        public async Task<IActionResult> GetAllTodo()
        {
            var dataset = await context.Todos.Where(s => s.Hidden == true).ToListAsync();

            return Ok(dataset);
        }

        [HttpGet("category/{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCat(int id)
        {
            Categories cat;
            try
            {
                cat = context.Categories.FirstOrDefault(s => s.ID == id && s.Hidden == true);
                if (cat == null)
                {
                    return NotFound($"{id} ID'li category bulunamadı!");
                }
                context.SaveChanges();
                return Ok(cat);
            }
            catch (Exception)
            {
                return BadRequest("Database Error!");
            }
        }

        [HttpGet("todo/{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            Todos cat;
            try
            {
                cat = context.Todos.FirstOrDefault(s => s.ID == id && s.Hidden == false);
                if (cat == null)
                {
                    return NotFound($"{id} ID'li category bulunamadı!");
                }
                context.SaveChanges();
                return Ok(cat);
            }
            catch (Exception)
            {
                return BadRequest("Database Error!");
            }
        }
        
        [HttpPost("category")]
        public async Task<IActionResult> PostCat([System.Web.Http.FromBody] Categories category)
        {
            try
            {
                await context.Categories.AddAsync(category);
                if (context.SaveChanges() > 0)
                    return CreatedAtAction("Get", new { id = category.ID }, category);
                else
                    return BadRequest("Hata!");
            }
            catch (DbUpdateException E)
            {
                Debug.WriteLine("Hata Kodu : " + E.Message);
                return BadRequest("Database update error!");
            }


        }

        [HttpPost("todo")]
        public IActionResult PostTodo([System.Web.Http.FromBody]Todos todo)
        {
            try
            {
                context.Todos.Add(todo);
                if (context.SaveChanges() > 0)
                    return CreatedAtAction("Get", new { id = todo.ID }, todo);
                else
                    return BadRequest("Hata!");
            }
            catch (DbUpdateException E)
            {
                Debug.WriteLine("Hata Kodu : " + E.Message);
                return BadRequest("Database update error!");
            }

        }

        
        [HttpPut("category")]
        public IActionResult PutCat([System.Web.Http.FromBody]Categories category)
        {
            var cat = context.Categories.FirstOrDefault(s => s.ID == category.ID);
            if(cat == null)
            {
                return NotFound($"{category.ID} ID'sine sahip ürün bulunamadı!");
            }
            context.Entry(cat).CurrentValues.SetValues(category);
            Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAA : " + context.Entry(cat));
            context.SaveChanges();
            return Ok(category);
            
        }

        [HttpPut("todo")]
        public IActionResult PutTodo(Todos _todo)
        {
            var todo = context.Todos.FirstOrDefault(s => s.ID == _todo.ID);
            if(todo == null)
            {
                return NotFound($"{_todo.ID} ID'li todo bulunamadı!");
            }
            context.Entry(todo).CurrentValues.SetValues(_todo);
            context.SaveChanges();

            return Ok(_todo);

        }

        // DELETE api/values/5
        [HttpDelete("category")]
        public IActionResult DeleteCat(Categories _cat)
        {
            Categories cat;

            try
            {
                cat = context.Categories.FirstOrDefault(s => s.ID == _cat.ID);
                if (cat == null)
                {
                    return NotFound($"{_cat.ID} ID'li category bulunamadı!");
                }
                else
                {
                    cat.Hidden = _cat.Hidden;
                    context.SaveChanges();
                    return Ok($"{_cat.ID} ID'li category silindi!");
                }
                
            }
            catch (Exception e)
            {

                return BadRequest("Database Error!");
            }

        }


        [HttpDelete("todo")]
        public IActionResult DeleteTodo(Todos _todo)
        {
            Todos todo;

            try
            {
                todo = context.Todos.FirstOrDefault(s => s.ID == _todo.ID);
                if (todo == null)
                {
                    return NotFound($"{_todo.ID} ID'li todo bulunamadı!");
                }
                else
                {
                    todo.Hidden = _todo.Hidden;
                    context.SaveChanges();
                    return Ok($"{_todo.ID} ID'li todo silindi!");
                }
                
            }
            catch (Exception e)
            {

                return BadRequest("Database Error!");
            }
            

        }
    }
}
