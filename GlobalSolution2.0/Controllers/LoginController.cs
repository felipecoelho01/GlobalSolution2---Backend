using GlobalSolution2._0.Application.Interfaces;
using GlobalSolution2._0.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution2._0.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var result = await _service.Login(model);

                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
