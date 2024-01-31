using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E02")]
    public class E02VarijableTipoviPodatakaOperatori : ControllerBase
    {

        [HttpGet]
        [Route("zad1")]
        public int zad1()
        {
            return int.MaxValue;
        }

        [HttpGet]
        [Route("zad3")]
        public float Zad3(int a, int b)
        {
            return (a * b) + (a / (float)b);
        }

        [HttpGet]
        [Route("zad4")]
        public bool Zad4(int a, int b)
        {
            return a == b;
        }



    }
}
