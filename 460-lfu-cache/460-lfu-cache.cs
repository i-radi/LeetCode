public class LFUCache
       {
            private int _capacity = 0;
            private Dictionary<int, LinkedList<int[]>> _frequencyList = new Dictionary<int, LinkedList<int[]>>();
            private Dictionary<int, LinkedListNode<int[]>> _cache = new Dictionary<int, LinkedListNode<int[]>>();

            public LFUCache(int capacity)
            {
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (!_cache.ContainsKey(key))
                    return -1;
                else
                {
                    _cache[key].Value[1] += 1;
                    Reorder(_cache[key]);
                }

                return _cache[key].Value[2];
            }

            public void Put(int key, int value)
            {
                if (_capacity == 0)
                    return;

                if (_cache.ContainsKey(key))
                    _cache[key].Value[2] = value;
                else
                {
                    _cache.Add(key, new LinkedListNode<int[]>(new int[] { key, -1, value }));

                    if (_cache.Count > _capacity)
                    {
                        int min = _frequencyList.Keys.Min();

                        _cache.Remove(_frequencyList[min].Last.Value[0]);
                        _frequencyList[min].RemoveLast();

                        if (_frequencyList[min].Count == 1)
                            _frequencyList.Remove(min);
                    }
                }

                _cache[key].Value[1] += 1;
                Reorder(_cache[key]);
            }

            private void Reorder(LinkedListNode<int[]> item)
            {
                if (item.Previous != null)
                {
                    _frequencyList[item.Value[1] - 1].Remove(item);

                    if (_frequencyList[item.Value[1] - 1].Count == 1)
                        _frequencyList.Remove(item.Value[1] - 1);
                }

                if (!_frequencyList.ContainsKey(item.Value[1]))
                {
                    _frequencyList.Add(item.Value[1], new LinkedList<int[]>());
                    _frequencyList[item.Value[1]].AddFirst(new int[] { Int32.MinValue, Int32.MinValue, Int32.MinValue });
                }

                _frequencyList[item.Value[1]].AddAfter(_frequencyList[item.Value[1]].First, item);
            }
        }