using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

class CSVParser {
	static void Main(string[] args) {
		var values = new List<float>();
		float sum = 0;
		float mean = 0;

		foreach (string file in args) {
			using var reader = new StreamReader(file);
			reader.ReadLine();
			string[] line = reader.ReadLine().Split(",");
			bool escape = false;
			int mark = 0;

			for (int i = 0; i < line.Length; i++) {
				if (!escape) {
					mark = i;
				}
				
				if (line[i].Contains("\"")) {
					escape = !escape;
				}

				if (escape) { continue; }

				string cell = String.Join("",
							  new ArraySegment<string>(line,
								      		   mark,
										   1 + i - mark))
						    .Replace("\"", "");

				values.Add(float.Parse(cell, 
						       NumberStyles.Currency,
						       new CultureInfo("en-US")));
			}
		}
		
		foreach (float v in values) {
			sum += v;
			mean += v;
			Console.WriteLine(v);
		}

		mean = mean / values.Count;
		
		Console.WriteLine("Sum: " + sum);
		Console.WriteLine("Mean: " + mean);

		using var writer = new StreamWriter("results.csv");

		writer.WriteLine("Sum,Average");
		writer.WriteLine(sum + "," + mean);
	}
}
