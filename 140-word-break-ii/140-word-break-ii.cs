public class Solution
{
	Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
	IList<string> wordDict;
	int minWordLen;
	int maxWordLen;

	public IList<string> WordBreak(string s, IList<string> wordDict)
	{
		foreach (var c in s)
			if (!wordDict.Any(w => w.Contains(c)))
				return new List<string>();
		this.wordDict = wordDict;

		maxWordLen = wordDict.Max(w => w.Length);
		minWordLen = wordDict.Min(w => w.Length);

		return BreakNextWords(s);
	}

	private IList<string> BreakNextWords(string s)
	{
		if (string.IsNullOrEmpty(s))
			return new List<string>();

		if (dict.ContainsKey(s))
			return dict[s];

		var list = new List<string>();

		for (int i = minWordLen; i <= maxWordLen; i++)
		{
			if (i > s.Length)
				break;
			var subLeft = s.Substring(0, i);
			if (wordDict.Contains(subLeft))
			{
				var subRight = s.Substring(i);
				if (subRight.Length == 0)
					list.Add($"{subLeft}");
				else
				{
					var rest = BreakNextWords(subRight);
					if (rest.Count == 0)
						continue;  //no combination for the given subRight
					foreach (var el in rest)
						list.Add($"{subLeft} {el}");
				}
			}
		}
		dict.Add(s, list);
		return list;
	}
}