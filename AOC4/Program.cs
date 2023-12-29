namespace AOC4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            string[] lines = File.ReadAllLines("input.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(": ");
                string[] numStrings = parts[1].Split(" | ");

                var winners = numStrings[0]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToHashSet();

                var myNums = numStrings[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);

                int nextScore = 1;
                int setScore = 0;

                foreach(int num in myNums.Where(winners.Contains))
                {
                    setScore = nextScore;
                    nextScore *= 2;
                }
                score += setScore;
            }
            Console.WriteLine(score);
        }
    }
}