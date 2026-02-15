namespace sharpkr1
{
    class Edition
    {
        protected String _editionName;
        protected DateTime _releaseDate;
        protected int _circulation; //tirazh

        public String Name 
		{ 
			get
			{
				return _editionName; 
			}
			set
			{
				_editionName = value; 
			}
		}
		public DateTime ReleaseDate 
		{ 
			get
			{
				return _releaseDate;
			}
			set
			{
				_releaseDate = value; 
			}
		}
		public int Circulation 
		{ 
			get 
			{ 
				return _circulation;
			} 
			set
			{
				if (_circulation < 0)
				{
					throw new ArgumentException("Circulation must be non-negative!(Circulation >= 0)");
				}
				_circulation = value;
			}
		}


        public Edition()
        {
            _editionName = "unnamed edition";
            _releaseDate = new DateTime();
            _circulation = 0;
        }

        public Edition(String name, DateTime releaseDate, int circulation)
        {
            this._editionName = name;
            this._releaseDate = releaseDate;
            this._circulation = circulation;
        }

		public virtual object DeepCopy()
		{
			Edition copy = new Edition(_editionName, _releaseDate, _circulation);
			return copy;
		}


        public override bool Equals(object? obj)
        {
			if (obj is Edition)
			{
				var objCast = (Edition)obj;

				if (objCast._releaseDate.CompareTo(this._releaseDate) == 0 && 
					objCast._editionName == this._editionName && 
					objCast._circulation == this._circulation)
				{
					return true;
				}

				return false;
			}

			return false;
        }

		public override int GetHashCode()
		{
			return _editionName.GetHashCode() * 32 * 32 + _releaseDate.GetHashCode() + _circulation.GetHashCode() * 32;
		}

        public override string ToString()
        {
			return "=== Edition\n" +
				$"Name: {_editionName}\n" +
				$"Release date: {_releaseDate}\n" +
				$"Ciruclation: {_circulation}\n" +
				$"===\n";
        }

    }
}
