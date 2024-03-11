using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V01")]
    public class V01:ControllerBase
    {
        [HttpGet]
        [Route("vjezba1")]
        public double v1(int a, int b, string c)
        {
            if(c == "+")
            {
                return a + b;
            }else if(c == "-")
            {
                return a - b;
            }else if (c == "*")
            {
                return a* b;
            }
            else if(c == "/") 
            {
                return (double)a/ b;
            }
            else
            {
                return 0;
            }
            
        }

        [HttpPost("vjezba2")]
        public double v2(double[] niz)
        {
            int prvi = (int)niz[0];
            double drugi = niz[niz.Length - 1] % 1;
            double sum = prvi + drugi;
            return sum;
        }
    }
}
