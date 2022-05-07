class Solution {
    public int majorityElement(int[] a) {
        HashMap <Integer , Integer> frequency = new HashMap<>();
        for(int i = 0 ; i < a.length ; i++)
        {
            frequency.put(a[i] , frequency.getOrDefault(a[i] , 0) + 1);
            if(frequency.get(a[i]) > a.length / 2)
                return a[i];
        }
        return -1;
    }
}