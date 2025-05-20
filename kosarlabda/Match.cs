using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosarlabda
{
	class Match
	{
		public string Hazai { get; set; }
		public string Idegen { get; set; }
		public int Hazai_pont { get; set; }
		public int Idegen_pont { get; set; }
		public string Helyszin { get; set; }
		public string Idopont { get; set; }

		public Match(string line)
		{
			string[] lineSplitted = line.Split(";");

			Hazai = lineSplitted[0];
			Idegen = lineSplitted[1];

			if (int.TryParse(lineSplitted[2], out var hazai_pont_converted))
			{
				Hazai_pont = hazai_pont_converted;
			}

			if (int.TryParse(lineSplitted[3], out var idegen_pont_converted))
			{
				Idegen_pont = idegen_pont_converted;
			}

			Helyszin = lineSplitted[4];

			Idopont = lineSplitted[5];
		}
	}
}
