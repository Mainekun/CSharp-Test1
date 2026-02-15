using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sharpkr1
{
    internal class Program
    {
        static KeyValuePair<string, int> SimpleGenFunc(int i)
        {
            if (i < 0)
            {
                throw new ArgumentException("'i' must be positive or zero");
            }

            return new KeyValuePair<string, int>($"{i} string", i);
        }

		static string StringKeySelector(Magazine mg)
		{
			return mg.Name + " " + mg.ReleaseDate.Date.ToString();
		}

		static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.UTF8;

			Magazine sampleMagazine = new Magazine("Daily articles", new Frequency(0, 1, 0), new DateTime(2026, 2, 1), 20);
			InitMagazine(ref sampleMagazine);
			Console.WriteLine(sampleMagazine.ToString());

			sampleMagazine.SortByAuthor();
			Console.WriteLine(sampleMagazine.ToString());

			sampleMagazine.SortByName();
			Console.WriteLine(sampleMagazine.ToString());

			sampleMagazine.SortByRating();
			Console.WriteLine(sampleMagazine.ToString());

			MagazineCollection<string> sampleMagazineCollection = new MagazineCollection<string>(StringKeySelector);
			sampleMagazineCollection.AddDefaults();
			sampleMagazineCollection.AddMagazines(sampleMagazine);
			Console.WriteLine(sampleMagazineCollection.ToString());

			Console.WriteLine($"MaxRating: {sampleMagazineCollection.MaxRating}");
			var freqGroup = sampleMagazineCollection.FrequencyGroup(new Frequency(0, 1, 0));
			
			Console.WriteLine($"Frequency: {String.Join(",", freqGroup.ToList())}");

			Console.WriteLine($"Group by frequency");
			var groupFreq = sampleMagazineCollection.GroupByFrequency.ToList();
			foreach (var group in groupFreq)
			{
				Console.WriteLine(group.Key + "\n" + String.Join("\n", group.ToList()));
			}

			TestCollections<string, int> testCols = InitializeTestCollections();
			testCols.TestContains();
			testCols.TestContainsKey();
			testCols.TestContainsValue();
		}

		static void InitMagazine(ref Magazine magazine)
		{
			magazine.AddArticles(
				new Article(new Person("Ilya", "Gorbatuk"), "Why C# is better than C/C++?", 5),
				new Article(new Person("Danil", "Chuvilin"), "How i quit Genshin Impact and start smoking 2 packs everyday", 4.8),
				new Article(new Person("Danil", "Rybuha"), "Non-obvious ways to hack your game with CE", 4.6),
				new Article(new Person("Vyacheslav", "Kostenko"), "Fate/Grand Order lore", 4.6),
				new Article(new Person("Vladislav", "Popov"), "Rich father, poor father", 4.9)
				);
		}

		static TestCollections<string, int> InitializeTestCollections()
		{
			int itemsAmount = 0;

			while (itemsAmount <= 0)
			{
				Console.Write("\u001b[s\u001b[3;33;40mEnter amount of items: ");
				bool parseResult = int.TryParse(Console.ReadLine(), out itemsAmount);

				if (parseResult == false)
				{
					Console.WriteLine("\u001b[u\u001b[3;31;40mMust be integer!                                   ");
					itemsAmount = 0;
				}
				else
				{
					if (itemsAmount > 0)
					{
						Console.WriteLine($"\u001b[u\u001b[5;32;40mAccepted: {itemsAmount}\u001b[0;0;0m                                         \n");
					}
					else
					{
						Console.WriteLine($"\u001b[u\u001b[3;31;40mDenied {itemsAmount}. Must be positive!                                        ");
					}
				}
			}

			Thread.Sleep(2000);
			Console.Write("\u001b[2J\u001b[H");

			return new TestCollections<string, int>(itemsAmount, SimpleGenFunc);
		}
	}
}
