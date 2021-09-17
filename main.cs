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
			foreach (string cell in line) {
				Console.WriteLine(cell);
				values.Add(float.Parse(cell,
						       NumberStyles.Currency,
						       new CultureInfo("en-US")));
			}
		}
		
		foreach (float val in values) {
			Console.WriteLine(val);
		}
	}
}
