using AutoMapper;
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
        private IMapper _mapper;

        public List<string> Errors { get; }

        public UserService(IRepository<User> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await _userRepository.Get();

            return users.Select(u => _mapper.Map<UserDto>(u)); 

        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);

                return userDto;
            }

            return null;
        }

        public async Task<UserDto> Add(UserInsertDto userInsertDto)
        {
            var user = _mapper.Map<User>(userInsertDto);


            await _userRepository.Add(user);
            await _userRepository.Save();

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<UserDto> Update(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                user = _mapper.Map<UserUpdateDto, User>(userUpdateDto, user);


                _userRepository.Update(user);
                await _userRepository.Save();

                var userDto = _mapper.Map<UserDto>(user);

                return userDto;
            }                

            return null;
        }

        public async Task<UserDto> Delete(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);

                _userRepository.Delete(user);
                await _userRepository.Save();

                return userDto;
            }

            return null;
        }

        public bool Validate(UserInsertDto insertDto)
        {
            if (_userRepository.Search(u => u.Email == insertDto.Email).Count() > 0)
            {
                Errors.Add("Ya existe un usuario con el mismo Email.");
                return false;
            }

            return true;
        }

        public bool Validate(UserUpdateDto updateDto)
        {
            if (_userRepository.Search(u => u.Email == updateDto.Email && updateDto.UserId != u.UserId).Count() > 0)
            {
                Errors.Add("Ya existe un usuario con el mismo Email.");
                return false;
            }

            return true;
        }
    }
}
