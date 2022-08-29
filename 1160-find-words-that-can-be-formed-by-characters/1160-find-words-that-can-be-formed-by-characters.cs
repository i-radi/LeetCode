public class Solution {
	public int CountCharacters(string[] words, string chars) {
		int count = 0;
		var freq = new int[26];

		foreach(var chr in chars)
			freq[chr - 'a']++;

		foreach(var word in words) {
			if(CanBeFormed(freq, word))
				count += word.Length;
		}

		return count;
	}

	public bool CanBeFormed(int[] chars, string word) {
		var freq = new int[26];

		foreach(var chr in word) {
			if(++freq[chr - 'a'] > chars[chr - 'a'])
				return false;
		}

		return true;
	}
}