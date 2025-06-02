using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> Get();
        Task<UserDto> GetById(int id);
        Task<UserDto> Add(UserInsertDto userInsertDto);
        Task<UserDto> Update(int id, UserUpdateDto userUpdateDto);
        Task<UserDto> Delete(int id);
    }
}
