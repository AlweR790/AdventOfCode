using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AdventOfCode.day02
{
	public class Solution : IGeneralSolution
	{
		public Solution()
		{
			loadData();
		}
		List<KeyValuePair<string, string>> pws = new List<KeyValuePair<string, string>>();
		int correct = 0;
		private void loadData()
		{
			WebClient client = new WebClient();
			client.Headers["Cookie"] = "session=53616c7465645f5f63d7f07756c2c0cae4c20019c0f8a634a5cab3b08f5958505809d418a7935abff63837372ff1d4cf";
			Stream stream = client.OpenRead("https://adventofcode.com/2020/day/2/input");
			using (StreamReader sr = new StreamReader(stream))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					var split = line.Split(':');
					pws.Add(new KeyValuePair<string,string>(split[0], split[1]));
				}
			}

		}

		public string part1()
		{
			foreach (var line in pws)
			{
				var split = line.Key.Split(' ');
				var charr = split[1].First();
				var minmax = split[0].Split('-');
				int min = int.Parse(minmax[0]);
				int max = int.Parse(minmax[1]);
				int charCount = line.Value.Count(x => x == charr);
				if (charCount >= min && charCount <= max)
					correct++;
			}
			return correct.ToString();
		}

		public string part2()
		{
			correct = 0;
			foreach (var line in pws)
			{
				var split = line.Key.Split(' ');
				var charr = split[1].First();
				var minmax = split[0].Split('-');
				int min = int.Parse(minmax[0]);
				int max = int.Parse(minmax[1]);
				var atMin = line.Value.Substring(min, 1);
				var atMax = line.Value.Substring(max, 1);
				if (atMax.First() == charr ^ atMin.First() == charr)
					correct++;
					

			}
			return correct.ToString();
		}
		
	}
}
