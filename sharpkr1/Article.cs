using sharpkr1;

namespace sharpkr1
{
    class Article : IComparable, IComparer<Article> {
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
            return
                $"# article: {articleName} \n" +
                $"  author: {author.ToString()}\n" +
                $"  rating: {articleRating} \n";
        }

		/// <summary>
		/// Compares by name
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
        public int CompareTo(object? obj)
        {
			if (obj == null) 
			{
				throw new NullReferenceException("How am i supposed to compare null with string?");
			}
			if (obj is Article)
			{
				var objCast = (Article)obj;
				return articleName.CompareTo(objCast.articleName);
			}
			throw new Exception("What is this? Apples? Bananas?");
        }

		/// <summary>
		/// Compares by authors first name
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
        public int Compare(Article? x, Article? y)
        {
			if (x == null || y == null)
			{
				throw new ArgumentNullException("Comparing nulls");
			}
			return String.Compare(x.author.firstName, y.author.firstName);
        }
    }
}


/// <summary>
/// Comparer for comparering by rating
/// </summary>
class ArticleRatingComparer : IComparer<Article>
{
	public int Compare(Article? x, Article? y)
	{
		if (x == null || y == null)
		{
			throw new ArgumentNullException("Comararing null values");
		}
		if (x.articleRating == y.articleRating)
		{
			return 0;
		}
		if (x.articleRating > y.articleRating)
		{
			return -1;
		}
		if (x.articleRating < y.articleRating)
		{
			return 1;
		}
		throw new Exception("ArticleRatingComparer.Compare: exception caught: undefiend relation");
	}
}