using api_usuario.Data;
using api_usuario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_usuario.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /*private DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }*/

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users  = await context.Users.ToListAsync();
            return users;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody]User model)
        {

            if (ModelState.IsValid)
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromServices] DataContext context, Guid id )
        {
            var item = await context.Users.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            context.Users.Remove(item);
            await context.SaveChangesAsync();

            return NoContent();
        }

        

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromServices] DataContext context, Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            context.Entry(user).State = EntityState.Modified;

            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound("User not found!");
            }

               
          
            return NoContent();
        }

    }
}
