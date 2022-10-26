public class Solution
    {
        private readonly IList<(int from, int to)> _ranges;
        private readonly int[] _weightdRangesIndices;
        private readonly Random _rnd;

        public Solution(int n, int[] blacklist)
        {
            _rnd = new Random();
            _ranges = new List<(int @from, int to)>();

            Array.Sort(blacklist);

            int from = 0;
            int to = 0;

            for (int i = 0; i < blacklist.Length; i++)
            {
                to = blacklist[i];

                if (from < to)
                {
                    _ranges.Add((from, to));
                }

                from = to + 1;
            }

            to = n;

            if (from < to)
            {
                _ranges.Add((from, to));
            }

            _weightdRangesIndices = new int[_ranges.Count];
            int sumWeight = 0;
            for (int i = 0; i < _ranges.Count; i++)
            {
                sumWeight += (_ranges[i].to - _ranges[i].from);
                _weightdRangesIndices[i] = sumWeight;
            }
        }

        private int PickRangeIndex()
        {
            int weight = _rnd.Next(0, _weightdRangesIndices.Last()) + 1;
            int res = Array.BinarySearch(_weightdRangesIndices, weight);
            return res >= 0 ? res : -res - 1;
        }

        public int Pick()
        {
            int rangeIdx = PickRangeIndex();
            return _rnd.Next(_ranges[rangeIdx].from, _ranges[rangeIdx].to);
        }
    }