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
                var tempLine = line;
                var subLine = string.Empty;
                var lineNumber = string.Empty;
                var nextDigit = string.Empty;
                int digitsLeft = 12;
                int index = 0;
                int includeLength = 0;

                for (int i = 0; i < 12; i++, digitsLeft--)
                {
                    if (lineNumber.Length + tempLine.Length == 12)
                    {
                        lineNumber += tempLine;
                        break;
                    }

                    includeLength = tempLine.Length - digitsLeft + 1;

                    subLine = tempLine.Substring(0, includeLength);
                    nextDigit = subLine.Max(c => c.ToString());
                    index = tempLine.IndexOf(nextDigit) + 1;
                    
                    int leftover = subLine.Length - 1 - subLine.IndexOf(nextDigit);

                    tempLine = tempLine.Substring(index);

                    lineNumber += nextDigit;
                }

                result += long.Parse(lineNumber);
            }

            return result;
        }
    }
}
