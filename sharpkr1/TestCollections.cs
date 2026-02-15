using System.Diagnostics;
using System.Runtime.CompilerServices;

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
		private KeyValuePair<String, KeyValuePair<TKey, TValue>>[] _testSequences;


		public TestCollections(int amount, GenerateElement<TKey, TValue> genFunction)
        {
			Console.WriteLine($"Creating collections capacity of {amount}\n" +											// \u001b[1;31m{typeof(TKey).Name}\u001b[0m
				$"- Dictionary<\u001b[1;31m{typeof(TKey).Name}\u001b[0m, \u001b[1;32m{typeof(TValue).Name}\u001b[0m>\n" + // \u001b[1;32m{typeof(TValue).Name}\u001b[0m
				$"- Dictionary<\u001b[1;34mstring\u001b[0m, \u001b[1;32m{typeof(TValue).Name}\u001b[0m>\n" +
				$"- List<\u001b[1;31m{typeof(TKey).Name}\u001b[0m>\n" +
				$"- List<\u001b[1;32m{typeof(TValue).Name}\u001b[0m>\n" +
				$"- Coresponding GenerateElementDelegate<\u001b[1;31m{typeof(TKey).Name}\u001b[0m, \u001b[1;32m{typeof(TValue).Name}\u001b[0m>" +
				$"\u001b[0m\n");
			Thread.Sleep(2000);
			Console.Write("\u001b[2J\u001b[H");
			_generateElementFunction = genFunction;
            _keydict = new Dictionary<TKey, TValue>(amount);
            _keys = new List<TKey>(amount);
            _values = new List<TValue>(amount);
            _stringdict = new Dictionary<string, TValue>(amount);

			_testSequences = new KeyValuePair<String, KeyValuePair<TKey, TValue>>[]{
				new KeyValuePair<String, KeyValuePair<TKey, TValue>>("First element search", _generateElementFunction(0)),
				new KeyValuePair<String, KeyValuePair<TKey, TValue>>("Middle element search", _generateElementFunction(amount / 2)),
				new KeyValuePair<String, KeyValuePair<TKey, TValue>>("Last element search", _generateElementFunction(amount - 1)),
				new KeyValuePair<String, KeyValuePair<TKey, TValue>>("Out of range element search", _generateElementFunction(amount + 10))
			}
			;
		}

		public void TestContains()
		{
			Console.Write("\u001b[1;96m");
			if (Stopwatch.IsHighResolution)
			{
				Console.WriteLine("Operations timed using the system's high-resolution performance counter.");
			}
			else
			{
				Console.WriteLine("Operations timed using the DateTime class.");
			}

			Thread.Sleep(1000);
			Console.WriteLine("\u001b[1F\u001b[2K\u001b[0m" +
				"Contains test");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			stopwatch.Stop();

			_keys.Clear();
			_values.Clear();

			for (var i = 0; i < _keys.Capacity; i++)
			{
				_keys.Add(_generateElementFunction(i).Key);
				_values.Add(_generateElementFunction(i).Value);
			}

			for (var i = 0; i < 4; i++)
			{
				Console.WriteLine(_testSequences[i].Key);

				KeyValuePair<TKey, TValue> observableElement = _testSequences[i].Value;

				stopwatch.Reset();
				stopwatch.Start();
				if (_keys.Contains(observableElement.Key)) { }
				stopwatch.Stop();

				Console.Write($"List<\u001b[1;31m{typeof(TKey).Name}\u001b[0m>: " +
					$"{stopwatch.Elapsed.Milliseconds}ms.{stopwatch.Elapsed.Nanoseconds}ns");

				stopwatch.Reset();
				stopwatch.Start();
				if (_values.Contains(observableElement.Value)) { }
				stopwatch.Stop();

				Console.WriteLine($"\u001b[30GList<\u001b[1;32m{typeof(TValue).Name}\u001b[0m>: " +
					$"{stopwatch.Elapsed.Milliseconds}ms.{stopwatch.Elapsed.Nanoseconds}ns");
			}

			Console.WriteLine();
		}

		public void TestContainsKey()
		{
			Console.Write("\u001b[1;96m");
			if (Stopwatch.IsHighResolution)
			{
				Console.WriteLine("Operations timed using the system's high-resolution performance counter.");
			}
			else
			{
				Console.WriteLine("Operations timed using the DateTime class.");
			}

			Thread.Sleep(1000);
			Console.WriteLine("\u001b[1F\u001b[2K\u001b[0m" +
				"ContainsKey test");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			stopwatch.Stop();

			_keydict.Clear();
			_stringdict.Clear();

			for (var i = 0; i < _keys.Capacity; i++)
			{
				_keydict.Add(_generateElementFunction(i).Key, _generateElementFunction(i).Value);
				_stringdict.Add(_generateElementFunction(i).Key.ToString(), _generateElementFunction(i).Value);
			}

			for (var i = 0; i < 4; i++)
			{
				Console.WriteLine(_testSequences[i].Key);

				KeyValuePair<TKey, TValue> observableElement = _testSequences[i].Value;

				stopwatch.Reset();
				stopwatch.Start();
				if (_keydict.ContainsKey(observableElement.Key)) { }
				stopwatch.Stop();

				Console.Write($"Dictionary<\u001b[1;31m{typeof(TKey).Name}\u001b[0m, \u001b[1;32m{typeof(TValue).Name}\u001b[0m>: " +
					$"{stopwatch.Elapsed.Milliseconds}ms.{stopwatch.Elapsed.Nanoseconds}ns");

				stopwatch.Reset();
				stopwatch.Start();
				if (_stringdict.ContainsKey(observableElement.Value.ToString())) { }
				stopwatch.Stop();

				Console.WriteLine($"\u001b[50GDictionary<\u001b[1;34mstring\u001b[0m, \u001b[1;32m{typeof(TValue).Name}\u001b[0m>: " +
					$"{stopwatch.Elapsed.Milliseconds}ms.{stopwatch.Elapsed.Nanoseconds}ns");
			}

			Console.WriteLine();
		}

		public void TestContainsValue()
		{
			Console.Write("\u001b[1;96m");
			if (Stopwatch.IsHighResolution)
			{
				Console.WriteLine("Operations timed using the system's high-resolution performance counter.");
			}
			else
			{
				Console.WriteLine("Operations timed using the DateTime class.");
			}

			Thread.Sleep(1000);
			Console.WriteLine("\u001b[1F\u001b[2K\u001b[0m" +
				"ContainsValue test");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			stopwatch.Stop();

			_keydict.Clear();

			for (var i = 0; i < _keys.Capacity; i++)
			{
				_keydict.Add(_generateElementFunction(i).Key, _generateElementFunction(i).Value);
			}

			for (var i = 0; i < 4; i++)
			{
				Console.WriteLine(_testSequences[i].Key);

				KeyValuePair<TKey, TValue> observableElement = _testSequences[i].Value;

				stopwatch.Reset();
				stopwatch.Start();
				if (_keydict.ContainsValue(observableElement.Value)) { }
				stopwatch.Stop();

				Console.WriteLine($"Dictionary<\u001b[1;31m{typeof(TKey).Name}\u001b[0m, \u001b[1;32m{typeof(TValue).Name}\u001b[0m>: " +
					$"{stopwatch.Elapsed.Milliseconds}ms.{stopwatch.Elapsed.Nanoseconds}ns");
			}

			Console.WriteLine();
		}
    }
}
