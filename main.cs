using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

class CSVParser {
	static void Main(string[] args) {
		var values = new List<float>();

		foreach (string file in args) {
			using var reader = new StreamReader(file);
			reader.ReadLine();
			string[] line = reader.ReadLine().Split(",");
			bool escape = false;
			int mark = 0;

			for (int i = 0; i < line.Length; i++) {
				if (line[i].Contains("\"")) {
					escape = !escape;
				} else {
					mark = i;
				}

				if (escape) { continue; }

				values.Add(float.Parse(String.Join("",
								   new ArraySegment<string>(line,
								   			    mark,
											    1 + i - mark))
							     .Replace("\"", ""),
						       NumberStyles.Currency,
						       new CultureInfo("en-US")));
			}
		}
		
		foreach (float val in values) {
			Console.WriteLine(val);
		}
	}
}
