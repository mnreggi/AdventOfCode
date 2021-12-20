using System;
using System.Threading.Tasks;
using AdventOfCode2021._01;
using AdventOfCode2021._02;
using AdventOfCode2021._03;

namespace AdventOfCode2021
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter day of advent");
            var game = Console.ReadLine();
            switch (game)
            {
                case "1":
                    Console.WriteLine($"Measurements larger than the previous measurement : {await Day1Service.Day1_Part1()}");
                    Console.WriteLine($"Sums larger than the previous sum : {await Day1Service.Day1_Part2()}");
                    break;
                case "2":
                    Console.WriteLine($"Multiply your final horizontal position by your final dept : {await Day2Service.Day2_Part1()}");
                    Console.WriteLine($"Multiply your final horizontal position by your final dept (With AIM): {await Day2Service.Day2_Part2()}");
                    break;
                case "3":
                    Console.WriteLine($"Power consumption of the submarine : {await Day3Service.Day3_Part1()}");
                    Console.WriteLine($"Life support of the submarine : {await Day3Service.Day3_Part2()}");
                    break;
            }
        }
    }
}