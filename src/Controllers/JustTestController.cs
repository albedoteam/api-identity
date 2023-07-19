namespace Identity.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class JustTestController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}