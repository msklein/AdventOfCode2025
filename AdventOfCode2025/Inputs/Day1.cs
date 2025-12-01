namespace AdventOfCode2025.Inputs
{
    public class Day1
    {
        public int Part1()
        {
            var outputLines = new InputFile().ReadInputFile("Inputs/Day1.txt");
            var nodeList = new LinkedList<int>();
            int startingPosition = 50;
            int passCode = 0;
            int currentPosition = startingPosition;

            for (int i = 0; i < 100; i++)
            {
                nodeList.AddLast(i);
            }

            var currentNode = nodeList.Find(startingPosition);

            foreach (var line in outputLines)
            {
                var direction = line.Substring(0, 1);
                var value = int.Parse(line.Substring(1, line.Length - 1));

                if (direction == "L")
                {
                    for (int i = 0; i < value; i++)
                    {
                        currentNode = currentNode.Previous ?? nodeList.Last;
                    }
                }
                else if (direction == "R")
                {
                    for (int i = 0; i < value; i++)
                    {
                        currentNode = currentNode.Next ?? nodeList.First;
                    }
                }

                if (currentPosition == 0)
                {
                    passCode++;
                }
            }

            return passCode;
        }
    }
}
