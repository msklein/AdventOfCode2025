namespace AdventOfCode2025
{
    public class Day3
    {
        public long Part1()
        {
            long result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D3.txt");

            foreach (var line in outputLines)
            {
                var digits = line.ToCharArray();

                var subLine = line.Substring(0, line.Length - 1);
                var firstDigit = subLine.Max(c => c.ToString());
                var positionOfMax = Array.IndexOf(digits, firstDigit[0]);

                var newDigits = digits.Where((c, index) => index > positionOfMax).ToArray();
                var secondDigit = newDigits.Max(c => c.ToString());

                result += long.Parse(firstDigit + secondDigit);
            }

            return result;
        }
        public long Part2()
        {
            long result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D3.txt");

            foreach (var line in outputLines)
            {
                var digits = line.ToCharArray();

                var subLine = line.Substring(0, line.Length - 1);
                var firstDigit = subLine.Max(c => c.ToString());
                var positionOfMax = Array.IndexOf(digits, firstDigit[0]);

                var newDigits = digits.Where((c, index) => index > positionOfMax).ToArray();
                var secondDigit = newDigits.Max(c => c.ToString());
                
                result += long.Parse(firstDigit + secondDigit);

                for (int i = 0; i < 12; i++)
                {

                }
            }

            return result;
        }
    }
}
