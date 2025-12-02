namespace AdventOfCode2025
{
    public class Day1
    {
        public int Part1()
        {
            var outputLines = new InputFile().ReadInputFile("Input_D1.txt");
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

                if (currentNode.Value == 0)
                {
                    passCode++;
                }
            }

            return passCode;
        }

        public int Part2()
        {
            var outputLines = new InputFile().ReadInputFile("Input_D1.txt");
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
                        if (currentNode.Value == 0)
                        {
                            passCode++;
                        }

                        if (currentNode.Previous == null)
                        {
                            currentNode = nodeList.Last;
                        }
                        else
                        {
                            currentNode = currentNode.Previous;
                        }
                    }
                }
                else if (direction == "R")
                {
                    for (int i = 0; i < value; i++)
                    {
                        if (currentNode.Value == 0)
                        {
                            passCode++;
                        }

                        if (currentNode.Next == null)
                        {
                            currentNode = nodeList.First;
                        }
                        else
                        {
                            currentNode = currentNode.Next;
                        }
                    }
                }
            }

            //Check if it ends on 0
            if (currentNode.Value == 0)
            {
                passCode++;
            }

            return passCode;
        }
    }
}
