namespace AdventOfCode2025
{
    public class Day5
    {
        public long Part1()
        {
            long result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D5.txt");

            List<(long, long)> ranges = new List<(long, long)>();
            List<long> ids = new List<long>();

            bool isRanges = true;

            foreach (var line in outputLines)
            {
                if(line == "")
                {
                    isRanges = false;
                    continue;
                }

                if(isRanges)
                {
                    var range = line.Split('-');

                    ranges.Add((long.Parse(range[0]), long.Parse(range[1])));
                    continue;
                }

                ids.Add(long.Parse(line));
            }

            foreach(var id in ids)
            {
                foreach(var range in ranges)
                {
                    if(id >= range.Item1 && id <= range.Item2)
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }

        public long Part2()
        {
            long result = 0;
            var outputLines = new InputFile().ReadInputFile("Input_D5.txt");

            List<(long, long)> ranges = new List<(long, long)>();
            List<(long, long)> mergedRanges = new List<(long, long)>();

            foreach (var line in outputLines)
            {
                if (line == "")
                {
                    break;
                }

                var range = line.Split('-');

                ranges.Add((long.Parse(range[0]), long.Parse(range[1])));
            }

            ranges.Sort((a, b) => a.Item1.CompareTo(b.Item1));

            var previousRange = ranges.First();

            for (int i = 0; i < ranges.Count; i++)
            {
                var currentRange = ranges[i];

                if (previousRange.Item2 >= currentRange.Item1)
                {
                    var mergedRange = (previousRange.Item1, Math.Max(currentRange.Item2, previousRange.Item2));
                    previousRange = mergedRange;
                }
                else
                {
                    mergedRanges.Add(previousRange);
                    previousRange = currentRange;
                }
            }

            mergedRanges.Add(previousRange); // Add the last range

            foreach (var range in mergedRanges)
            {
                result += (range.Item2 - range.Item1 + 1);
            }

            return result;
        }
    }
}
