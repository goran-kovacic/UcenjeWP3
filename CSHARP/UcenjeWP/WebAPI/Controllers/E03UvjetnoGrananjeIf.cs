using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E03")]
    public class E03UvjetnoGrananjeIf : ControllerBase
    {

        [HttpGet]
        [Route("Zad1")]
        public int zad1(int a, int b)
        {
            var zbroj = a + b;
            return (a+b)%2==0 ? a*b : a+b;
        }




    }
}
