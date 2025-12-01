namespace AdventOfCode2025
{
    public class InputFile
    {
        public List<string> ReadInputFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at path {filePath} was not found.");
            }

            return File.ReadAllLines(filePath).ToList();
        }
    }
}
