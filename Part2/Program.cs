namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            var counts = Enumerable.Repeat(1, lines.Length).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                string[] parts = line.Split(": ");
                string[] numStrings = parts[1].Split(" | ");

                var winners = numStrings[0]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToHashSet();

                int score = numStrings[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Count(winners.Contains);

                for (int j = 1; j <= score; j++)
                {
                    counts[i + j] += counts[i];
                }
            }

            Console.WriteLine(counts.Sum());
        }
    }
}
