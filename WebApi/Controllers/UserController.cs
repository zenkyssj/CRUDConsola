using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get() =>
            await _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                Age = u.Age,
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,
            };

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add(UserInsertDto userInserDto)
        {
            var user = new User()
            {
                Name = userInserDto.Name,
                LastName = userInserDto.LastName,
                Email = userInserDto.Email,
                Password = userInserDto.Password,
                Age = userInserDto.Age,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,

            };

            return CreatedAtAction(nameof(GetById), new {id = user.UserId}, userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = userUpdateDto.Name;
            user.LastName = userUpdateDto.LastName;
            user.Email = userUpdateDto.Email;
            user.Password = userUpdateDto.Password;
            user.Age = userUpdateDto.Age;

            await _context.SaveChangesAsync();

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,

            };

            return Ok(userDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return Ok();
        }




    }
}
