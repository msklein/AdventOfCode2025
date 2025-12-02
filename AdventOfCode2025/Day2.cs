using System.Collections;
using System.Text.RegularExpressions;

namespace AdventOfCode2025
{
    public class Day2
    {
        public long Part1()
        {
            long result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D2.txt");
            var idRanges = outputLines.First().Split(',').Select(range =>
            {
                var bounds = range.Split('-').Select(long.Parse).ToArray();
                return (Min: bounds[0], Max: bounds[1]);
            }).ToArray();

            Regex pattern = new Regex(@"^(\d+)\1$");

            foreach (var idRange in idRanges)
            {
                IEnumerable<long> range = CreateLongRange(idRange.Min, idRange.Max - idRange.Min +1);

                foreach (var number in range)
                {
                    var match = pattern.Match(number.ToString());

                    if (match.Success)
                    {
                        result += number;
                    }
                };
            }

            return result;
        }

        public long Part2()
        {
            long result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D2.txt");
            var idRanges = outputLines.First().Split(',').Select(range =>
            {
                var bounds = range.Split('-').Select(long.Parse).ToArray();
                return (Min: bounds[0], Max: bounds[1]);
            }).ToArray();

            Regex pattern = new Regex(@"^(\d+)\1+$");

            foreach (var idRange in idRanges)
            {
                IEnumerable<long> range = CreateLongRange(idRange.Min, idRange.Max - idRange.Min + 1);

                foreach (var number in range)
                {
                    var match = pattern.Match(number.ToString());

                    if (match.Success)
                    {
                        result += number;
                    }
                }
                ;
            }

            return result;
        }

        private static IEnumerable<long> CreateLongRange(long start, long count)
        {
            long limit = start + count;
            for (long i = start; i < limit; i++)
            {
                yield return i;
            }
        }
    }
}
