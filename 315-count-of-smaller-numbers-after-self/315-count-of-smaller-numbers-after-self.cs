public class Solution
    {
        private class SegTree
        {
            private const int CHUNK_SIZE = 32;

            private class Node
            {
                public readonly int Min;
                public readonly int Max;

                public Node(int min, int max)
                {
                    Min = min;
                    Max = max;
                }

                public Node Left;
                public Node Right;
                public bool IsLeaf => Left == null && Right == null;
                public int IntervalCount;
                public IDictionary<int, int> Val2Count;
            }

            private readonly Node _root;

            public SegTree(int min, int max)
            {
                _root = new Node(min, max);
                Build(_root);
            }

            private void Build(Node node)
            {
                int chunk = node.Max - node.Min + 1;
                int chunksCount = Convert.ToInt32(Math.Ceiling((double)chunk / CHUNK_SIZE));

                if (chunksCount <= 1)
                {
                    node.Val2Count = new Dictionary<int, int>();
                    return;
                }

                int leftChunksCount = chunksCount / 2;

                node.Left = new Node(node.Min, node.Min + leftChunksCount * CHUNK_SIZE - 1);
                node.Right = new Node(node.Min + leftChunksCount * CHUNK_SIZE, node.Max);

                Build(node.Left);
                Build(node.Right);
            }

            private void RegisterValue(Node node, int value)
            {
                if (node == null || value < node.Min || value > node.Max)
                {
                    return;
                }

                node.IntervalCount++;

                if (!node.IsLeaf)
                {
                    RegisterValue(node.Left, value);
                    RegisterValue(node.Right, value);
                }
                else
                {
                    if (!node.Val2Count.ContainsKey(value))
                    {
                        node.Val2Count[value] = 0;
                    }

                    node.Val2Count[value]++;
                }
            }

            public void RegisterValue(int value)
            {
                RegisterValue(_root, value);
            }

            private int GetCount(Node node, int from, int to)
            {
                if (node == null || from > node.Max || to < node.Min)
                {
                    return 0;
                }

                if (node.Min == from && node.Max == to)
                {
                    return node.IntervalCount;
                }

                if (node.IsLeaf)
                {
                    int res = 0;
                    foreach (var p in node.Val2Count)
                    {
                        if (p.Key <= to && p.Key >= from)
                        {
                            res += p.Value;
                        }
                    }

                    return res;
                }

                return GetCount(node.Left, Math.Max(node.Left.Min, from), Math.Min(node.Left.Max, to))
                       + GetCount(node.Right, Math.Max(node.Right.Min, from), Math.Min(node.Right.Max, to));
            }

            public int GetCount(int from, int to) => GetCount(_root, from, to);
        }
        
        public IList<int> CountSmaller(int[] nums)
        {
            int[] res = new int[nums.Length];

            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var num in nums)
            {
                min = Math.Min(num, min);
                max = Math.Max(num, max);
            }

            SegTree segTree = new SegTree(min, max);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                segTree.RegisterValue(nums[i]);
                res[i] = segTree.GetCount(min, nums[i] - 1);
            }

            return res;
        }
    }