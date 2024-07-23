using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021._04
{
    public static class Day4Service
    {
        public static async Task Day4_Part1()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"04\TestInput.txt");
            var enumerable = from l in await File.ReadAllLinesAsync(filePath)
                let x = l.Split(new [] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                select new
                {   
                    Sum = x.Sum(),
                    Average = x.Average()
                };
        }
    }
}