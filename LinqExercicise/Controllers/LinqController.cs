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
            IEnumerable<int> list = Enumerable.Range(n - 1, m - 1).Select(x => x + 1);

            return Ok(list);
        }

        #endregion

        #region 5.
        [HttpPost("actionfive")]
        public ActionResult<int[]> PostActionFive([FromBody] int[] array)
        {
            int sum = array.Sum(x => x);

            int? oddNumbersSum = array.Where(x => x % 2 != 0).Sum(y => y);

            double? evenNumbersAvg = array.Where(x => x % 2 == 0).Count() > 0 ? array.Where(x => x % 2 == 0).Average(y => y) : null;

            int? firstEven = array.FirstOrDefault(x => x % 2 == 0);

            int? lastOdd = array.LastOrDefault(x => x % 2 != 0);

            int[] ascending = array.OrderBy(x => x).ToArray();

            int[] descending = array.OrderByDescending(x => x).ToArray();

            int? minValue = array.Min(x => x);

            int? maxValue = array.Max(x => x);

            bool isAllEven = array.All(x => x % 2 == 0);

            bool isAnyOdd = array.Any(x => x % 2 != 0);

            int[] dinstict = array.Distinct().ToArray();

            int? last = array.LastOrDefault();

            int? first = array.FirstOrDefault();

            int halfIndex = array.Length / 2;

            double? median = array.Length % 2 != 0 ? array.OrderBy(x => x).ElementAt(halfIndex) : (array.OrderBy(x => x).ElementAt(halfIndex) + array.OrderBy(x => x).ElementAt(halfIndex - 1)) / 2.0;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] chars = alphabet.ToCharArray();

            char[] toLetters = array.Select(number => chars[number > 26 ? (number % 26 == 0 ? 25 : (number - 26 * (number / 26) - 1)) : number - 1]).ToArray();

            int[] toDouble = array.Select(x => x * 2).ToArray();

            byte[] toBits = array.Select(x => x % 2 == 0 ? (byte)1 : (byte)0).ToArray();

            int[][] groupEvenOdds = array.GroupBy(x => x % 2 == 0).Select(arr => arr.Select(x => x).ToArray()).ToArray();

            int Aggregate = array.Aggregate(1, (prev, current) => prev * current);

            return Ok(new {sum, oddNumbersSum, evenNumbersAvg, firstEven, lastOdd, ascending, descending, minValue, maxValue, isAllEven, isAnyOdd, dinstict, last, first, median, toLetters, toDouble, toBits, groupEvenOdds, Aggregate });

        }

        #endregion

        #region 6.

        [HttpPost("juros")]
        public ActionResult<double[]> PostPortionPrice(double value, int portions, double interestRates)
        {
            double valuePriceRate = value * (Math.Pow((1 + interestRates), portions) * interestRates) / (Math.Pow((1 + interestRates), portions) - 1);

            IEnumerable<double> parcelas = Enumerable.Repeat(valuePriceRate, portions);

            return Ok(parcelas);
            
        }
        #endregion

        #region 7.

        [HttpGet("datetime")]
        public ActionResult<object[]> PostDayAniversy([FromQuery] DateTime date, [FromQuery] int n)
        {
            IEnumerable<DateTime> dates = Enumerable.Range(0, n).Select(x => date.AddYears(x));
            return Ok(dates.Select(date => new { date, weekDay = date.DayOfWeek.ToString() }));
        }

        #endregion

        #region 8.
        [HttpGet("CountLetter")]
        public ActionResult<object[]> GetLetterObject([FromQuery] string s)
        {
            char[] splitedString = s.ToCharArray();

            return Ok(splitedString.Select((x, i) => new { x, count = s.Count(x => x == s[i])}).Distinct());


        }


        #endregion




    }
}
