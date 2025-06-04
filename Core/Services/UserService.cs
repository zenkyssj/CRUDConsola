using Core.DTOs;
using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : ICommonService<UserDto, UserInsertDto, UserUpdateDto>
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await _userRepository.Get();

            return users.Select(u => new UserDto()
            {
                UserId = u.UserId,
                Name = u.Name,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                Age = u.Age,

            });

        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

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

            await _userRepository.Add(user);
            await _userRepository.Save();

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
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                user.Name = userUpdateDto.Name;
                user.LastName = userUpdateDto.LastName;
                user.Email = userUpdateDto.Email;
                user.Password = userUpdateDto.Password;
                user.Age = userUpdateDto.Age;

                _userRepository.Update(user);
                await _userRepository.Save();

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
            var user = await _userRepository.GetById(id);

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

                _userRepository.Delete(user);
                await _userRepository.Save();

                return userDto;
            }

            return null;
        }             
    }
}
