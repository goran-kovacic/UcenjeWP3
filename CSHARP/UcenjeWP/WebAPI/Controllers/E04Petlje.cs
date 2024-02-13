using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E04")]
    public class E04Petlje : ControllerBase
    {

        [HttpGet]
        [Route("Zad1")]
        public int zad1(int a, int b)
        {
            int sum = 0;
            int min=0, max=0;
            if(a > b)
            {
                min = b; max = a;
            }else if(a < b)
            {
                min = a; max = b;
            }else if( a==b)
            {
                return 0;
            }
            for(int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }




    }
}
