using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day1Service
    {
        public static async Task<int> Day1_Part1()
        {
            int? previousValue = null;
            var countIncreases = 0;
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"01\Input.txt");
            foreach (var line in await File.ReadAllLinesAsync(filePath))
            {
                if (previousValue != null && previousValue < int.Parse(line))
                {
                    countIncreases++;
                    previousValue = int.Parse(line);
                }
                else
                {
                    previousValue = int.Parse(line);
                }
            }

            return countIncreases;
        }
        
        public static async Task<int> Day1_Part2()
        {
            var countIncreases = 0;
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"01\Input.txt");
            var lines = (await File.ReadAllLinesAsync(filePath)).Select(int.Parse).ToArray();

            for (var i = 0; i < (lines.Length - 3); i++)
            {
                var currentValue = lines[i] + lines[i + 1] + lines[i + 2];
                var nextValue = lines[i + 1] + lines[i + 2] + lines[i + 3];

                if (currentValue < nextValue)
                {
                    countIncreases++;
                }
            }

            return countIncreases;
        }
    }
}