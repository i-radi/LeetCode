public class MyHashSet {

   		private HashSet<int> set = null;
		/** Initialize your data structure here. */
		public MyHashSet()
		{
			set = new HashSet<int>();
		}

		public void Add(int key)
		{
			set.Add(key);
		}

		public void Remove(int key)
		{
			set.Remove(key);
		}

		/** Returns true if this set contains the specified element */
		public bool Contains(int key)
		{
			if (set.Contains(key))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */