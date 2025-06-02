using Core.DTOs;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : ICommonService<UserDto, UserInsertDto, UserUpdateDto>
    {
        private UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

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


        public async Task<UserDto> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Age = user.Age,
                };

                return userDto;
            }

            return null;
        }

        public async Task<UserDto> Add(UserInsertDto userInsertDto)
        {
            var user = new User()
            {
                Name = userInsertDto.Name,
                LastName = userInsertDto.LastName,
                Email = userInsertDto.Email,
                Password = userInsertDto.Password,
                Age = userInsertDto.Age,
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

            return userDto;
        }

        public async Task<UserDto> Update(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
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

                return userDto;
            }                

            return null;
        }

        public async Task<UserDto> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Age = user.Age,

                };

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return userDto;
            }

            return null;
        }             
    }
}
