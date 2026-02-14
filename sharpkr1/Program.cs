using System.Collections.Generic;

namespace sharpkr1
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    class TestCollections<TKey,TValue>
    {
        private List<TKey> _keys;
        private List<TValue> _values;
        private Dictionary<TKey, TValue> _keydict;
        private Dictionary<string, TValue> _stringdict;
        private GenerateElement<TKey, TValue> _generateElementFunction;

        public TestCollections(int amount, GenerateElement<TKey, TValue> genFunction)
        {
            _generateElementFunction = genFunction;
            _keydict = new Dictionary<TKey, TValue>(amount);
            _keys = new List<TKey>(amount);
            _values = new List<TValue>(amount);
            _stringdict = new Dictionary<string, TValue>(amount);
        }

    }

    class Person
    {
        public String firstName;
        public String lastName;

        public Person(String f, String s) 
        {
            firstName = f;
            lastName = s;
        }
    }

    class Article
    {
        public Person author;
        public String articleName;
        public double articleRating;

        public Article(Person author, string articleName, double articleRating)
        {
            this.author = author;
            this.articleName = articleName;
            this.articleRating = articleRating;
        }

        public Article()
        {
            author = new Person("firstname", "lastname");
            articleName = "unnamed article";
            articleRating = 0.0;
        }

        public override string ToString()
        {
            return $"===" +
                $"article: {articleName}" +
                $"author: {author.firstName} {author.lastName}" +
                $"rating: {articleRating}";
        }
    }

    class Frequency
    {
        public int days;
        public int weeks;
        public int months;

        public Frequency(int days, int weeks, int months)
        {
            this.days = days;
            this.weeks = weeks;
            this.months = months;
        }

        public Frequency()
        {
            days = 0;
            weeks = 0;
            months = 0;
        }

        public override string ToString()
        {
            return $"{days} day(s), {weeks} week(s), {months} month(es)";
        }
    }

    class Magazine
    {
        private String _magazineName;
        private Frequency _frequency;
        private DateTime _releaseDate;
        private int _amount;// tirazh
        private Article[] _articles;

        public String Name => _magazineName;
        public Frequency Frequency => _frequency;
        public DateTime ReleaseDate => _releaseDate;
        public Article[] Articles => _articles;
        public int Amount => _amount;

        public double AverageRating
        {
            get
            {
                double avg = 0.0;
                foreach (Article article in _articles)
                {
                    avg += article.articleRating;
                }

                return avg / _articles.Length;
            }
        }

        public bool this[Frequency index]
        {
            get
            {
                return _frequency.Equals(index);
            }
        }

        public void AddArticles(params Article[] articles)
        {
            foreach (Article article in articles)
            {
                _articles.Append(article);
            }
        }

        public override string ToString()
        {
            return $"===" +
                $"magazine: {_magazineName}" +
                $"frequncy: {_frequency.ToString()}" +
                $"released: {_releaseDate.ToString()}" +
                $"articles: {string.Join("\n", Array.ConvertAll(_articles, x => x.articleName))}";
        }

        virtual public String ToShortString()
        {
            return $"===" +
                $"magazine: {_magazineName}" +
                $"frequncy: {_frequency.ToString()}" +
                $"released: {_releaseDate.ToString()}" +
                $"avg rating: {AverageRating}";
        }

        public Magazine(string magazineName, Frequency frequency, DateTime releaseDate, int amount, Article[] articles)
        {
            this._magazineName = magazineName;
            this._frequency = frequency;
            this._releaseDate = releaseDate;
            this._amount = amount;
            this._articles = articles;
        }

        public Magazine()
        {
            _magazineName = "unnamed magazine";
            _frequency = new Frequency(0, 0, 0);
            _releaseDate = new DateTime();
            _amount = 0;
            _articles = new Article[0];
        }
    }

    class Edition
    {
        protected String _editionName;
        protected DateTime _releaseDate;
        protected int _amount; //tirazh

        public String Name => _editionName;

        public Edition()
        {
            _editionName = "unnamed edition";
            _releaseDate = new DateTime();
            _amount = 0;
        }

        public Edition(String name, DateTime releaseDate, int amount)
        {
            this._editionName = name;
            this._releaseDate = releaseDate;
            this._amount = amount;
        }


    }

    internal class Program
    {
        static KeyValuePair<TKey, TValue> GenFunc<TKey, TValue>(int i)
        {
            if (i <= 0)
            {
                throw new ArgumentException("'i' must be positive");
            }

            return new KeyValuePair<TKey, TValue>();
        }

        static void Main(string[] args)
        {
            int itemsAmount = 0;

            while (itemsAmount <= 0)
            {
                Console.Write("\u001b[s\u001b[3;33;40mEnter amount of items: ");
                bool parseResult = int.TryParse(Console.ReadLine(), out itemsAmount);
                
                if (parseResult == false)
                {
                    Console.WriteLine("\u001b[u\u001b[3;31;40mMust be integer!                               ");
                    itemsAmount = 0;
                }
                else
                {
                    if (itemsAmount > 0)
                    {
                        Console.WriteLine($"\u001b[u\u001b[5;32;40mAccepted: {itemsAmount}\u001b[0;0;0m                               ");
                    }
                    else
                    {
                        Console.WriteLine($"\u001b[u\u001b[3;31;40mDenied {itemsAmount}. Must be positive!                              ");
                    }
                }
            }


        }
    }
}
