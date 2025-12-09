using System.Data;
using System.Linq.Expressions;

namespace AdventOfCode2025
{
    public class Day6
    {
        public decimal Part1()
        {
            decimal result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D6.txt");

            int numOfMathProblems = outputLines[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length;

            List<List<string>> mathProblems = new List<List<string>>();

            for (int i = 0; i < numOfMathProblems; i++)
            {
                mathProblems.Add(new List<string>());
            }

            foreach (var line in outputLines)
            {
                var numbers = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                int index = 0;

                foreach (var number in numbers)
                {
                    mathProblems[index++].Add(number);
                }
            }

            foreach (var problem in mathProblems)
            {
                var mathSymbol = problem.Last();

                problem.Remove(problem.Last());

                string expression = string.Empty;

                foreach (var item in problem.Take(problem.Count - 1))
                {
                    expression += (item + ".0" + " " + mathSymbol);
                }

                expression += problem.Last();

                DataTable dt = new DataTable();

                var mathExpression = dt.Compute(expression, null);

                result += Convert.ToDecimal(mathExpression);
            }

            return result;
        }
    }
}
