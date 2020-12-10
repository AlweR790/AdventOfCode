using System;

namespace AdventOfCode
{
	class Program
	{
		public static IGeneralSolution generalSolution;
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, please select day to solve");
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int dayNumber))
				{
					switch (dayNumber)
					{
						case 1: generalSolution = new day01.Solution(); break;
						case 2: generalSolution = new day01.Solution(); break;
						default: Console.WriteLine("Day not solved yet, try again later"); continue;
					}
					Console.WriteLine(generalSolution.solve());
				}
				else
				{
					Console.WriteLine("Enter a number please");
					continue;
				}
			}
		} 
		
	}
}
