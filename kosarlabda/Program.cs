using System.Text.RegularExpressions;

namespace kosarlabda
{
	class Program
	{
		static void Main(string[] args)
		{
			//fájl beolvasása stringtömbbe
			string[] lines = System.IO.File.ReadAllLines("C:/Users/gluck/source/repos/infojegyzethu_acb_kosarlabdaliga/eredmenyek.csv");

			//üres objektumlista létrehozása
			List<Match> matchList = new List<Match>();

			for (int i = 1; i < lines.Length; i++)
			{
				//példány legenerálása a stringtömb sorából
				Match matchInstance = new Match(lines[i]);

				//példány hozzáadása listához
				matchList.Add(matchInstance);
			}

			Console.WriteLine("3. feladat: a Real Madrid hány mérközést játszott hazai, illetve idegen csapatként?");
			Console.WriteLine(rmHanyMerkozesHazai(matchList));
			Console.WriteLine(rmHanyMerkozesIdegen(matchList));

			Console.WriteLine("4. feladat: Volt-e döntetlen mérközés?");
			Console.WriteLine(voltEDontetlen(matchList));

			Console.WriteLine("5. feladat: A barcelonai csapatnak mi a pontos neve?");
			Console.WriteLine(barcelonaiCsapatPontosneve(matchList));

			Console.WriteLine("6. feladat: 2004 nov 21-én mely csapatok játszottak mérközéseket, és milyen eredmény született?");
			adottDatumonMelyCsapatokEsEredmeny(matchList, "2004-10-03");

			Console.WriteLine("7. feladat: melyek azok a stadionok, amelyek 20-nál több alkalommal voltak kosárlabdamérkőzések helyszínei? A stadionok neve mögött jelenjen meg a mérközések száma is!");
			stadionok(matchList);

			Console.ReadKey();
		}

		private static void stadionok(List<Match> matchList)
		{
			List<string> listOfVenues = new List<string>();
			List<string> distinctListOfVenues = new List<string>();

			foreach (var item in matchList)
			{
				listOfVenues.Add(item.Helyszin);
			}
			distinctListOfVenues = listOfVenues.Distinct().ToList();



			foreach (var venue in distinctListOfVenues)
			{
				int y = 0;

				for (int i = 0; i < matchList.Count; i++)
				{
					if (matchList[i].Helyszin == venue)
					{
						y++;
					}
				}

				if (y > 20)
				{
					Console.WriteLine(venue + " " + y);
				}
			}
		}

		private static void adottDatumonMelyCsapatokEsEredmeny(List<Match> matchList, string date)
		{
			List<Match> filteredMatchList = new List<Match>();
			foreach (var item in matchList)
			{
				if (item.Idopont == date)
				{
					filteredMatchList.Add(item);
				}
			}

			foreach (var item in filteredMatchList)
			{
				Console.WriteLine(item.Hazai + "-" + item.Idegen + " (" + item.Hazai_pont + ":" + item.Idegen_pont + ")");
			}
		}

		private static string barcelonaiCsapatPontosneve(List<Match> matchList)
		{
			string barcelonaPontosNeve = "";

			foreach (var item in matchList)
			{
				if (item.Hazai.Contains("Barcelona"))
				{
					barcelonaPontosNeve = item.Hazai;
					break;
				}
			}
			return barcelonaPontosNeve;
		}

		private static string voltEDontetlen(List<Match> matchList)
		{
			string voltEDontetlen = "nem";
			int dontetlenekSzama = 0;

			foreach (var item in matchList)
			{
				if (item.Hazai_pont == item.Idegen_pont)
				{
					dontetlenekSzama++;
				}
			}

			if (dontetlenekSzama > 0)
			{
				voltEDontetlen = "igen";
			}

			return $"{voltEDontetlen}";
		}

		private static string rmHanyMerkozesIdegen(List<Match> matchList)
		{
			int rmHanyMerkozesIdegen = 0;

			foreach (var item in matchList)
			{
				if (item.Hazai == "Real Madrid")
				{
					rmHanyMerkozesIdegen++;
				}
			}

			return $"hazai: {rmHanyMerkozesIdegen}";
		}

		private static string rmHanyMerkozesHazai(List<Match> matchList)
		{
			int rmHanyMerkozesIdegen = 0;

			foreach (var item in matchList)
			{
				if (item.Idegen == "Real Madrid")
				{
					rmHanyMerkozesIdegen++;
				}
			}

			return $"idegen: {rmHanyMerkozesIdegen}";
		}
	}
}
