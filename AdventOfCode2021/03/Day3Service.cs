using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021._03
{
    public static class Day3Service
    {
        public static async Task<int> Day3_Part1()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"03\Input.txt");
            var mapper = new Dictionary<int, int>();
            foreach (var line in await File.ReadAllLinesAsync(filePath))
            {
                if (mapper.Count == 0)
                {
                    for (var i = 0; i < line.Length; i++)
                    {
                        mapper.Add(i,0);
                    }
                }
                var position = 0;
                line.ToList().ForEach(x =>
                {
                    if (x == '0')
                    {
                        mapper[position]++;
                    }
                    else if (x == '1')
                    {
                        mapper[position]--;
                    }
                    position++;
                });
            }

            var tempBinaryGama = string.Empty;
            var tempBinaryEpsilon = string.Empty;
            foreach (var keyValuePair in mapper)
            {
                var value = keyValuePair.Value > 0 ? 0 : 1;
                tempBinaryGama += value;
                tempBinaryEpsilon += Convert.ToString(~value, 2)[^1];
            }

            var gamaRate = Convert.ToInt32(tempBinaryGama, 2);
            var epsilonRate = Convert.ToInt32(tempBinaryEpsilon, 2);

            var powerConsumption = gamaRate * epsilonRate;

            return powerConsumption;
        }
        
        public static async Task<int> Day3_Part2()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"03\Input.txt");
            var theFile = await File.ReadAllLinesAsync(filePath);
            
            var oxygenResult = Loop(theFile, 0, x => x > 0 ? 0 : 1);
            var co2Result = Loop(theFile, 0, x => x > 0 ? 1 : 0);

            var oxygen = Convert.ToInt32(oxygenResult.FirstOrDefault(), 2);
            var co2 = Convert.ToInt32(co2Result.FirstOrDefault(), 2);

            var lifeSupport = oxygen * co2;

            return lifeSupport;        
        }

        private static string[] Loop(string[] lines, int position, Func<int, int> condition)
        {
            var count = 0;

            if (lines.Count() == 1)
            {
                return lines;
            }
            
            foreach (var line in lines)
            {
                if (line[position] == '0')
                {
                    count++;
                }
                else if (line[position] == '1')
                {
                    count--;
                }
            }
            
            var value = condition(count);
            var restOfLines = lines.Where(x => x[position].ToString() == value.ToString()).Select(x => x);
            
            return Loop(restOfLines.ToArray(), position + 1, condition);
        }
    }
}