using System.Text;

namespace AdventOfCode2025
{
    public class Day4
    {
        public long Part1()
        {
            long result = 0;
            int numNeighbours = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D4.txt");

            for (int i = 0; i < outputLines.Count; i++)
            {
                for (int j = 0; j < outputLines[i].Length; j++)
                {
                    if (outputLines[i][j] == '@')
                    {
                        numNeighbours = 0;

                        var hasAbove = HasLinebove(i);
                        var hasBelow = HasLineBelow(i, outputLines.Count);
                        var hasLeft = HasColumnLeft(j);
                        var hasRight = HasColumnRight(j, outputLines[i].Length);

                        if (hasAbove)
                        {
                            if (outputLines[i - 1][j] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasBelow)
                        {
                            if (outputLines[i + 1][j] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasLeft)
                        {
                            if (outputLines[i][j - 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasRight)
                        {
                            if (outputLines[i][j + 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasAbove && hasLeft)
                        {
                            if (outputLines[i - 1][j - 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasAbove && hasRight)
                        {
                            if (outputLines[i - 1][j + 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasBelow && hasLeft)
                        {
                            if (outputLines[i + 1][j - 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasBelow && hasRight)
                        {
                            if (outputLines[i + 1][j + 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (numNeighbours < 4)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        public long Part2(List<string>? outputLines = null)
        {
            long result = 0;
            int numNeighbours = 0;

            if (outputLines == null)
            {
                outputLines = new InputFile().ReadInputFile("Input_D4.txt");
            }

            List<Tuple<int, int>> rollsToRemove = new List<Tuple<int, int>>();

            for (int i = 0; i < outputLines.Count; i++)
            {
                for (int j = 0; j < outputLines[i].Length; j++)
                {
                    if (outputLines[i][j] == '@')
                    {
                        numNeighbours = 0;

                        var hasAbove = HasLinebove(i);
                        var hasBelow = HasLineBelow(i, outputLines.Count);
                        var hasLeft = HasColumnLeft(j);
                        var hasRight = HasColumnRight(j, outputLines[i].Length);

                        if (hasAbove)
                        {
                            if (outputLines[i - 1][j] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasBelow)
                        {
                            if (outputLines[i + 1][j] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasLeft)
                        {
                            if (outputLines[i][j - 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasRight)
                        {
                            if (outputLines[i][j + 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasAbove && hasLeft)
                        {
                            if (outputLines[i - 1][j - 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasAbove && hasRight)
                        {
                            if (outputLines[i - 1][j + 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasBelow && hasLeft)
                        {
                            if (outputLines[i + 1][j - 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (hasBelow && hasRight)
                        {
                            if (outputLines[i + 1][j + 1] == '@')
                            {
                                numNeighbours++;
                            }
                        }

                        if (numNeighbours < 4)
                        {
                            rollsToRemove.Add(new Tuple<int, int>(i, j));
                            result++;
                        }
                    }
                }
            }

            if (result == 0)
            {
                return 0;
            }

            foreach (var roll in rollsToRemove)
            {
                var sbRows = outputLines.Select(s => new StringBuilder(s)).ToList();
                sbRows[roll.Item1][roll.Item2] = '.';
                outputLines = sbRows.Select(sb => sb.ToString()).ToList();
            }

            return result += Part2(outputLines);
        }

        private bool HasLinebove(int index)
        {
            return index - 1 >= 0;
        }

        private bool HasLineBelow(int index, int totalLines)
        {
            return index + 1 < totalLines;
        }

        private bool HasColumnLeft(int index)
        {
            return index - 1 >= 0;
        }

        private bool HasColumnRight(int index, int totalColumns)
        {
            return index + 1 < totalColumns;
        }
    }
}
