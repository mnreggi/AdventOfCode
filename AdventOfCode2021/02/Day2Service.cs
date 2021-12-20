using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021._02
{
    public static class Day2Service
    {
        public static async Task<int> Day2_Part1()
        {
            var position = 0;
            var depth = 0;
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"02\Input.txt");
            foreach (var line in await File.ReadAllLinesAsync(filePath))
            {
                var actions = line.Split(" ");
                var command = Enum.Parse<Commands>(actions[0]);
                var movement = int.Parse(actions[1]);

                switch (command)
                {
                    case Commands.forward:
                        position += movement;
                        break;
                    case Commands.down:
                        depth += movement;
                        break;
                    case Commands.up:
                        depth -= movement;
                        break;
                }
            }

            return position*depth;
        }

        public static async Task<int> Day2_Part2()
        {
            var position = 0;
            var depth = 0;
            var aim = 0;
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"02\Input.txt");
            foreach (var line in await File.ReadAllLinesAsync(filePath))
            {
                var actions = line.Split(" ");
                var command = Enum.Parse<Commands>(actions[0]);
                var movement = int.Parse(actions[1]);

                switch (command)
                {
                    case Commands.forward:
                        position += movement;
                        depth += aim * movement;
                        break;
                    case Commands.down:
                        aim += movement;
                        break;
                    case Commands.up:
                        aim -= movement;
                        break;
                }
            }

            return position*depth;
        }
    }
}