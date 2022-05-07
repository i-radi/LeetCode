class Solution {
    public String smallestStringWithSwaps(String s, List<List<Integer>> pairs) {
        int len = s.length();
        int[] parent = new int[len];
        for (int i = 0; i < len; i++) {
            parent[i] = i;
        }

        for (List<Integer> pair : pairs) {
            int ancestry1 = find(pair.get(0), parent);
            int ancestry2 = find(pair.get(1), parent);
            parent[ancestry2] = ancestry1;
        }

        HashMap<Integer, PriorityQueue<Character>> map = new HashMap<>();
        for (int i = 0; i < len; i++) {
            int ancestry = find(i, parent);
            if (!map.containsKey(ancestry)) {
                map.put(ancestry, new PriorityQueue<>());
            }
            map.get(ancestry).offer(s.charAt(i));
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < len; i++) {
            PriorityQueue<Character> queue = map.get(find(i, parent));
            sb.append(queue.poll());
        }
        return sb.toString();
    }

    private int find(int i, int[] parent) {
        if (parent[i] != i) {
            parent[i] = find(parent[i], parent);
        }
        return parent[i];
    }
}