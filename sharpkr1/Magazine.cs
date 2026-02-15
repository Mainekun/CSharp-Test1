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
                _articles.Append(article);
            }
        }

        public override string ToString()
        {
            return $"===" +
                $"magazine: {_magazineName}\n" +
                $"frequncy: {_frequency.ToString()}\n" +
                $"released: {_releaseDate.ToString()}\n" +
                $"articles: {string.Join("\n", String.Join("\n", _articles))}\n";
        }

        virtual public String ToShortString()
        {
            return $"===" +
                $"magazine: {_magazineName}\n" +
                $"frequncy: {_frequency.ToString()}\n" +
                $"released: {_releaseDate.ToString()}\n" +
                $"avg rating: {AverageRating} \n";
        }

        public Magazine(string magazineName, Frequency frequency, DateTime releaseDate, int circulation)
        {
            this._magazineName = magazineName;
            this._frequency = frequency;
            this._releaseDate = releaseDate;
            this._circulation = circulation;
			this._articles = new List<Article>();
        }

        public Magazine()
        {
            _magazineName = "unnamed magazine";
            _frequency = new Frequency(0, 0, 0);
            _releaseDate = new DateTime();
            _circulation = 0;
            _articles = new List<Article>();
		}

		public void SortByName()
		{
			_articles.Sort();
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
