using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach (var filePath in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output")))
			{
				File.Delete(filePath);
			}

			foreach(var filePath in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input")))
			{
				List<string> targets = new List<string>();
				var words = File.ReadAllText(filePath).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

				for(int i = 0; i < words.Count(); i++)
				{
					if(words[i].Equals("target", StringComparison.OrdinalIgnoreCase))
						targets.Add(words[i + 1]);
				}

				StringBuilder output = new StringBuilder();

				if(targets.Any())
				{
					output.AppendLine("Targets executed");
					output.AppendLine("****************");

					foreach(var target in targets)
					{
						output.AppendLine(target);
					}
				}

				File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", new FileInfo(filePath).Name), output.ToString());

				output = new StringBuilder();

				if (targets.Any())
				{
					targets.Sort();

					output.AppendLine("Targets executed - sorted alphabetically");
					output.AppendLine("****************************************");

					foreach (var target in targets)
					{
						output.AppendLine(target);
					}
				}

				File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", "Sorted." + new FileInfo(filePath).Name), output.ToString());

				Console.WriteLine(filePath);
			}

			Console.Read();
		}
	}
}
