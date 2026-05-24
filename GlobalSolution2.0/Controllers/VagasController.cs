using GlobalSolution2._0.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution2._0.Controllers
{
    public class VagasController : Controller
    {
        private IVagasService _service;
        public VagasController(IVagasService service) 
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("/vagas")]
        public async Task<IActionResult> GetVagas()
        {
            try 
            { 
            var result = await _service.GetVagas();

                if(result == null)
                    return BadRequest(result);

                return Ok(result);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
