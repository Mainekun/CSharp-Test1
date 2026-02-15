using System.Collections.Generic;
using System.Linq;

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

		static void Main(string[] args)
        {



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
