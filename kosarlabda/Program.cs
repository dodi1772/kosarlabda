using System.Text.RegularExpressions;

namespace kosarlabda
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] sorok = System.IO.File.ReadAllLines("C:/Users/Diák/source/repos/kosarlabda/eredmenyek.csv");

			List<Match> MatchLista = new List<Match>();

			for (int i = 1; i < sorok.Length; i++)
			{
				Match ujMatch = new Match(sorok[i]);

				MatchLista.Add(ujMatch);
			}

			Console.WriteLine("3. feladat: Hány mérkőzést játszott a Real Madrid hazai, illetve idegen csapatként?");
			Console.WriteLine(RealMadridHazaiMatchekSzama(MatchLista));
			Console.WriteLine(RealMadridIdegenMatchekSzama(MatchLista));

			Console.WriteLine("4. feladat: Volt-e döntetlen mérkőzés?");
			Console.WriteLine(VoltDontetlen(MatchLista));

			Console.WriteLine("5. feladat: Mi a pontos neve a barcelonai csapatnak?");
			Console.WriteLine(BarcelonaCsapatNeve(MatchLista));

			Console.WriteLine("6. feladat: 2004-10-03-án mely csapatok játszottak és milyen eredmény született?");
			MatchekAdottNapon(MatchLista, "2004-10-03");

			Console.WriteLine("7. feladat: Mely stadionokban rendeztek 20-nál több mérkőzést? A stadion neve mellett jelenjen meg a mérkőzések száma is!");
			Stadionok20FelettiMatchsel(MatchLista);

			Console.ReadKey();
		}

		private static void Stadionok20FelettiMatchsel(List<Match> MatchLista)
		{
			List<string> stadionok = new List<string>();
			List<string> kulonbozoStadionok = new List<string>();

			foreach (var Match in MatchLista)
			{
				stadionok.Add(Match.Helyszin);
			}
			kulonbozoStadionok = stadionok.Distinct().ToList();

			foreach (var stadion in kulonbozoStadionok)
			{
				int MatchSzamlalo = 0;

				for (int i = 0; i < MatchLista.Count; i++)
				{
					if (MatchLista[i].Helyszin == stadion)
					{
						MatchSzamlalo++;
					}
				}

				if (MatchSzamlalo > 20)
				{
					Console.WriteLine(stadion + " " + MatchSzamlalo);
				}
			}
		}

		private static void MatchekAdottNapon(List<Match> MatchLista, string datum)
		{
			List<Match> adottNapiMatchek = new List<Match>();
			foreach (var Match in MatchLista)
			{
				if (Match.Idopont == datum)
				{
					adottNapiMatchek.Add(Match);
				}
			}

			foreach (var Match in adottNapiMatchek)
			{
				Console.WriteLine(Match.Hazai + "-" + Match.Idegen + " (" + Match.HazaiPont + ":" + Match.IdegenPont + ")");
			}
		}

		private static string BarcelonaCsapatNeve(List<Match> MatchLista)
		{
			string barcelonaNev = "";

			foreach (var Match in MatchLista)
			{
				if (Match.Hazai.Contains("Barcelona"))
				{
					barcelonaNev = Match.Hazai;
					break;
				}
			}
			return barcelonaNev;
		}

		private static string VoltDontetlen(List<Match> MatchLista)
		{
			string dontetlenVolt = "nem";
			int dontetlenDb = 0;

			foreach (var Match in MatchLista)
			{
				if (Match.HazaiPont == Match.IdegenPont)
				{
					dontetlenDb++;
				}
			}

			if (dontetlenDb > 0)
			{
				dontetlenVolt = "igen";
			}

			return $"{dontetlenVolt}";
		}

		private static string RealMadridHazaiMatchekSzama(List<Match> MatchLista)
		{
			int hazaiDb = 0;

			foreach (var Match in MatchLista)
			{
				if (Match.Hazai == "Real Madrid")
				{
					hazaiDb++;
				}
			}

			return $"hazai: {hazaiDb}";
		}

		private static string RealMadridIdegenMatchekSzama(List<Match> MatchLista)
		{
			int idegenDb = 0;

			foreach (var Match in MatchLista)
			{
				if (Match.Idegen == "Real Madrid")
				{
					idegenDb++;
				}
			}

			return $"idegen: {idegenDb}";
		}
	}
}