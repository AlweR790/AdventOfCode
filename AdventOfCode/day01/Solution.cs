using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AdventOfCode.day01
{
	public class Solution : IGeneralSolution
	{
		List<int> ints = new List<int>();
		public Solution()
		{
			loadData();
		}
		private void loadData()
		{
			WebClient client = new WebClient();
			client.Headers["Cookie"] = "session=53616c7465645f5f06f5655377eb610bb7ed8e8bffb8e09f0e62cd94a1d0cd75ad53f6e1533022923ef698988ae2b326";
			Stream stream = client.OpenRead("https://adventofcode.com/2020/day/1/input");
			using (StreamReader sr = new StreamReader(stream))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					ints.Add(int.Parse(line));
				}
			}
		}
		public string part1()
		{
			for (int i = 0; i < ints.Count; i++)
			{
				int n1 = ints[i];
				for (int y = i + 1; y < ints.Count; y++)
				{
					int n2 = ints[y];
					if (n1 + n2 == 2020)
					{
						return n1 * n2 + "";
					}
				}
			}
			return "";
		}
		public string part2()
		{
			for (int i = 0; i < ints.Count; i++)
			{
				int n1 = ints[i];
				for (int x = i; x < ints.Count; x++)
				{
					int n2 = ints[x];
					for (int y = x; y < ints.Count; y++)
					{
						int n3 = ints[y];
						if (n1 + n2 + n3 == 2020)
						{
							return n1 * n2 * n3 + "";							
						}
					}
				}
			}
			return "";
		}
	}
}
