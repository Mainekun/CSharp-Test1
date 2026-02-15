using System.Collections.Generic;

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
					new Frequency(0, 0, 1), 
					new DateTime(2020, 2, 2), 
					10000),
				mg2 = new Magazine(
					"人民日报", 
					new Frequency(1,0,0), 
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

		public double MaxRating { 
			get
			{
				if (_magazines.Count == 0)
				{
					return 0; 
				}

				Magazine target = _magazines.Values
					.OrderBy(mg => mg.AverageRating)
					.Last();

				return target.AverageRating;

			}
		}

		public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
		{
			return _magazines
				.Where(mg => mg.Value.Frequency.Equals(value));
		}

		public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupByFrequency
		{
			get
			{
				return _magazines
					.GroupBy(mg => mg.Value.Frequency);
			}
		}

		public override string ToString()
        {
			string displayString = "===== MagazineCollection =====\n";
			foreach (var magazine in _magazines)
			{
				
				displayString += $"====\nKey: {magazine.Key.ToString()}\n{magazine.Value.ToString()}\n";
			}
            return displayString += "=====";
        }

		public string ToShortString()
		{
			string displayString = "===== MagazineCollection =====\n";
			foreach (var magazine in _magazines)
			{
				displayString += $"====\nKey: {magazine.Key.ToString()}\n{magazine.Value.ToShortString()}\n";
			}
			return displayString += "=====";
		}

		
	}
}
