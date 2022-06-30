using LinqExercicise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LinqExercicise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinqController : Controller
    {
        [HttpPost]
        public ActionResult<int[]> PostAllNumbers([FromBody] int[] array)
        {
            return array;
        }

        #region 1.

        //Dada uma array de números inteiros, crie uma action que retorne uma array com quadrado de cada número.
        [HttpPost("squared")]
        public ActionResult<int[]> PostSquaredList([FromBody] int[] array)
        {
            return Ok(array.Select(x => x * x));
        }
        #endregion

        #region 2.

        //crie uma action que retorne os N primeiros números;
        [HttpPost("firstnumbers")]
        public ActionResult<int[]> PostFirstThanN([FromBody] int[] array, int n)
        {
            return Ok(array.Take(n));
        }

        //crie outra action que retorne os N últimos números.
        [HttpPost("lastnumbers")]
        public ActionResult<int[]> PostLastNumbers([FromBody] int[] array, int n)
        {
            return Ok(array.TakeLast(n));
        }
        #endregion

        #region 3.
        //crie uma action que retorne os elementos E da array enquanto E for menor que N;
        [HttpPost("elementlower")]
        public ActionResult<int[]> PostLowerElements([FromBody] int[] array, int n)
        {
            return Ok(array.TakeWhile(x => x < n));         
        }

        //crie uma action que ignore os elementos E da array enquanto E for menor que N, e retorne os demais elementos.
        [HttpPost("ignoreelementelower")]
        public ActionResult<int[]> PostIgnoreElementLower([FromBody] int[] array, int n)
        {
            return Ok(array.SkipWhile(x => x < n));
        }

        //crie uma action que retorne o primeiro elemento E que for maior que N;
        [HttpPost("firstelementgreater")]
        public ActionResult<int[]> PostFirstElementeGreater([FromBody] int[] array, int n)
        {
            return Ok(array.First(x => x > n));
        }

        //crie uma action que retorne o último elemento E que for menor que N;
        [HttpPost("lastelementlower")]
        public ActionResult<int[]> PostLastElementeLower([FromBody] int[] array, int n)
        {
            return Ok(array.Last(x => x < n));
        }
        #endregion

        #region 4.
        //crie uma action que retorne uma array com o elemento N repetido M vezes;

        [HttpPost("repetemtimes")]
        public ActionResult<int[]> PostRepeteMTimes([FromBody] int n, int m)
        {
            IEnumerable<int> list = Enumerable.Repeat(n, m);

            return Ok(list);
        }

        //crie uma action que retorne uma array de N a M com PA n+1.

        [HttpPost("repetentompa")]
        public ActionResult<int[]> PostRepeteNToMPa([FromBody] int n, int m)
        {

        }




        #endregion

    }
}
