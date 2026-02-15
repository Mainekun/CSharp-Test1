using System.ComponentModel;

namespace sharpkr1
{
    class Magazine
    {
        private String _magazineName;
        private Frequency _frequency;
        private DateTime _releaseDate;
        private int _circulation;// tirazh
        //private Article[] _articles;

		private List<Person> _editors;
		private List<Article> _articles;

        public String Name => _magazineName;
        public Frequency Frequency => _frequency;
        public DateTime ReleaseDate => _releaseDate;
        public List<Article> Articles => _articles;
		public List<Person> Editors => _editors;
        public int Circulation => _circulation;

        public double AverageRating
        {
            get
            {
				if (_articles.Count == 0)
				{
					return 0; 
				}	

                double avg = 0.0;
                foreach (Article article in _articles)
                {
                    avg += article.articleRating;
                }

                return avg / _articles.Count;
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
                _articles.Add(article);
            }
        }

        public override string ToString()
        {
			string displayString =
				$"=== magazine: {_magazineName}\n" +
				$"frequncy: {_frequency.ToString()}\n" +
				$"released: {_releaseDate.ToString()}\n";

			if (_editors.Count != 0)
			{
				displayString += $"editors: \n";

				foreach (var editor in _editors)
				{
					displayString += editor.ToString() + "\n";
				}
			}

			displayString += $"articles: \n\n";

			foreach (var article in _articles)
			{
				displayString += article.ToString() + "\n";
			}

			return displayString;
        }

        virtual public String ToShortString()
        {
            return $"=== " +
                $"magazine: {_magazineName}\n" +
                $"frequncy: {_frequency.ToString()}\n" +
                $"released: {_releaseDate.ToString()}\n" +
				$"editors team size: {_editors.Count}\n" +
				$"avg rating: {AverageRating}\n";
		}

        public Magazine(string magazineName, Frequency frequency, DateTime releaseDate, int circulation)
        {
            this._magazineName = magazineName;
            this._frequency = frequency;
            this._releaseDate = releaseDate;
            this._circulation = circulation;
			this._articles = new List<Article>();
			this._editors = new List<Person>();
        }

        public Magazine()
        {
            _magazineName = "unnamed magazine";
            _frequency = new Frequency(0, 0, 0);
            _releaseDate = new DateTime();
            _circulation = 0;
            _articles = new List<Article>();
			_editors = new List<Person>();
		}

		public void SortByName()
		{
			_articles.Sort((x, y) => x.CompareTo(y));
		}

		// TODO: i dont know it should work or not
		public void SortByAuthor()
		{
			_articles.Sort(new Article());
		}

		public void SortByRating()
		{
			_articles.Sort(new ArticleRatingComparer());
		}
    }
}
