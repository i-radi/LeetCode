class Solution {
    public int maxOperations(int[] nums, int k) {
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int num : nums) {
            map.put(num, map.getOrDefault(num, 0) + 1);
        }

        int res = 0;
        for (int key : map.keySet()) {
            if (k == 2 * key) {
                res += map.get(key) / 2;
            } else if (map.containsKey(k - key)) {
                int min = Math.min(map.get(key), map.get(k - key));
                res += min;
                map.put(key, map.get(key) - min);
                map.put(k - key, map.get(k - key) - min);
            }
        }
        return res;
    }
}