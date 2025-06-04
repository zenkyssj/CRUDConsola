using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.DTOs;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Core.Validators;
using FluentValidation;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IValidator<UserInsertDto> _userInsertValidator;
        private IValidator<UserUpdateDto> _userUpdateValidator;
        private ICommonService<UserDto, UserInsertDto, UserUpdateDto> _userServices;

        public UserController(
            IValidator<UserInsertDto> userInsertValidator,
            IValidator<UserUpdateDto> userUpdateValidator,
            [FromKeyedServices("userService")] ICommonService<UserDto, UserInsertDto, UserUpdateDto> userService)
        {
            _userInsertValidator = userInsertValidator;
            _userUpdateValidator = userUpdateValidator;
            _userServices = userService;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get() =>
            await _userServices.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var userDto = await _userServices.GetById(id);

            return userDto == null ? NotFound() : Ok(userDto);          
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add(UserInsertDto userInserDto)
        {
            var validationResult = await _userInsertValidator.ValidateAsync(userInserDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var userDto = await _userServices.Add(userInserDto);
          
            return CreatedAtAction(nameof(GetById), new {id = userDto.UserId}, userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UserUpdateDto userUpdateDto)
        {
            var validationResult = await _userUpdateValidator.ValidateAsync(userUpdateDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var userDto = await _userServices.Update(id, userUpdateDto);
            
            return userDto == null ? NotFound() : Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
           var userDto = await _userServices.Delete(id); 

            return userDto == null ? NotFound() : Ok(userDto);
        }
    }
}
