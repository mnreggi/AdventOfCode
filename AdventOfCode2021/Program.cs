using System;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Measurements larger than the previous measurement : {await Day1Service.Day1_Part1()}");
            Console.WriteLine($"Sums larger than the previous sum : {await Day1Service.Day1_Part2()}");
        }
    }
}