namespace sharpkr1
{
	delegate TKey KeySelector<TKey>(Magazine mg);

	class MagazineCollection<TKey>
	{
		private Dictionary<TKey, Magazine> _magazines;
		private KeySelector<TKey> _keySelector;

		public MagazineCollection(KeySelector<TKey> keySelector)
		{
			_keySelector = keySelector;
			_magazines = new Dictionary<TKey, Magazine>();
		}

		public void AddDefaults()
		{
			Magazine 
				mg1 = new Magazine(
					"CHIP", 
					new Frequency(0, 1, 0), 
					new DateTime(2020, 2, 2), 
					10000),
				mg2 = new Magazine(
					"人民日报", 
					new Frequency(0,1,0), 
					new DateTime(1950, 9, 1), 
					1000000);

			TKey key1 = _keySelector(mg1),
				key2 = _keySelector(mg2);

			_magazines.Add(key1, mg1);
			_magazines.Add(key2, mg2);
		}

		public void AddMagazines(params Magazine[] magazines)
		{
			foreach (var magazine in magazines)
			{
				TKey key = _keySelector(magazine);
				_magazines.Add(key, magazine);
			}
		}

        public override string ToString()
        {
            return base.ToString();
        }

		public string ToShortString()
		{
			return "";
		}


	}
}
