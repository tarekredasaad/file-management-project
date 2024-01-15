using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResultDTO>> RegisterWithEmailAndPass(UserDTO userDTO)
        {
            //ResultDTO resultDTO = new ResultDTO();
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode=400,Data = ModelState}) ; };

            return Ok( await _authService.Register(userDTO)) ;
        }
        

        

        [AllowAnonymous]
        [HttpPost("Login")]

        public async Task<ActionResult<ResultDTO>> Login(LoginDTO userDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            return Ok(await _authService.Login(userDTO));
        }

        //[HttpPost("Logout")]
        //public async Task<ActionResult<ResultDTO>> Logout()
        //{
        //    return Ok(await _authService.Logout());

        //}
        //[Authorize(Policy = "deleteUser")]
        //[HttpPost("Delete")]
        //public async Task<ActionResult<ResultDTO>> DeleteUser(string email)
        //{
        //    if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

        //    return Ok(await _authService.DeleteUser(email));

        //}

    }
}
