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
        //Dada uma array de números inteiros, crie uma ÚNICA action que retorne

        [HttpPost("actionfive")]
        public ActionResult<int[]> PostActionFive([FromBody] int[] array)
        {
            //soma
            int sum = array.Sum(x => x);

            //soma numeros impares
            int? oddNumbersSum = array.Where(x => x % 2 != 0).Sum(y => y);

            //media numeros pares
            double? evenNumbersAvg = array.Where(x => x % 2 == 0).Count() > 0 ? array.Where(x => x % 2 == 0).Average(y => y) : null;

            //primeiro par
            int? firstEven = array.FirstOrDefault(x => x % 2 == 0);

            //primeiro impar
            int? lastOdd = array.LastOrDefault(x => x % 2 != 0);

            //ordem crescente
            int[] ascending = array.OrderBy(x => x).ToArray();

            //ordem descendente
            int[] descending = array.OrderByDescending(x => x).ToArray();

            //valor minimo
            int? minValue = array.Min(x => x);

            //valor maximo
            int? maxValue = array.Max(x => x);

            //retorna True se forem todos pares
            bool isAllEven = array.All(x => x % 2 == 0);

            //verifica se existe algum valor impar
            bool isAnyOdd = array.Any(x => x % 2 != 0);

            //retira elementos repetidos da lista
            int[] dinstict = array.Distinct().ToArray();

            //ultimo elemento
            int? last = array.LastOrDefault();

            //primeiro elemento
            int? first = array.FirstOrDefault();

            //calculo da mediana
            int halfIndex = array.Length / 2;

            double? median = array.Length % 2 != 0 ? array.OrderBy(x => x).ElementAt(halfIndex) : (array.OrderBy(x => x).ElementAt(halfIndex) + array.OrderBy(x => x).ElementAt(halfIndex - 1)) / 2.0;

            //transformar elementos numericos com elementos do alfabeto baseado com a posição '1' = 'A' '2' = 'B' ...
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] chars = alphabet.ToCharArray();

            char[] toLetters = array.Select(number => chars[number > 26 ? (number % 26 == 0 ? 25 : (number - 26 * (number / 26) - 1)) : number - 1]).ToArray();

            //Dobro do array
            int[] toDouble = array.Select(x => x * 2).ToArray();

            //transformar numeros pares em 1 e numeros impares em 2
            byte[] toBits = array.Select(x => x % 2 == 0 ? (byte)1 : (byte)0).ToArray();

            //agrupamento em duas arrays diferentes uma com os pares e outra com os impares
            int[][] groupEvenOdds = array.GroupBy(x => x % 2 == 0).Select(arr => arr.Select(x => x).ToArray()).ToArray();

            //a soma dos numeros de um array cujo valor se dá pela soma dos elementos E da Array A, sendo E = A[n-1] * A[n].
            int Aggregate = array.Aggregate(1, (prev, current) => prev * current);

            return Ok(new {sum, oddNumbersSum, evenNumbersAvg, firstEven, lastOdd, ascending, descending, minValue, maxValue, isAllEven, isAnyOdd, dinstict, last, first, median, toLetters, toDouble, toBits, groupEvenOdds, Aggregate });

        }

        #endregion

        #region 6.
        //Crie uma action que receba o valor de um produto, a taxa de juros e o número de parcelas e retorne o valor da parcela Price.

        [HttpPost("juros")]
        public ActionResult<double[]> PostPortionPrice(double value, int portions, double interestRates)
        {
            double valuePriceRate = value * (Math.Pow((1 + interestRates), portions) * interestRates) / (Math.Pow((1 + interestRates), portions) - 1);

            IEnumerable<double> parcelas = Enumerable.Repeat(valuePriceRate, portions);

            return Ok(parcelas);
            
        }
        #endregion

        #region 7.
        // Crie uma action que receba uma data de aniversário, um número inteiro N e retorne o dia da semana nos próximos N anos no seguinte formato:

        [HttpGet("datetime")]
        public ActionResult<object[]> PostDayAniversy([FromQuery] DateTime date, [FromQuery] int n)
        {
            IEnumerable<DateTime> dates = Enumerable.Range(0, n).Select(x => date.AddYears(x));
            return Ok(dates.Select(date => new { date, weekDay = date.DayOfWeek.ToString() }));
        }

        #endregion

        #region 8.
        //Dada uma string S, crie uma action que retorne os caracteres (desconsiderando letter-casing) e sua frequência em S no seguinte formato:
        [HttpGet("CountLetter")]
        public ActionResult<object[]> GetLetterObject([FromQuery] string s)
        {
            s = s.ToLower();
            char[] splitedString = s.ToCharArray();

            return Ok(splitedString.Select((x, i) => new { character = x, count = s.Count(x => x == s[i])}).Distinct());
        }

        #endregion




    }
}
