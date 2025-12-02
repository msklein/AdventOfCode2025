namespace AdventOfCode2025
{
    public class InputFile
    {
        public List<string> ReadInputFile(string fileName)
        {
            var directory = AppContext.BaseDirectory;
            var path = Path.Combine(directory, "Inputs", fileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The file at path {path} was not found.");
            }

            return File.ReadAllLines(path).ToList();
        }
    }
}
