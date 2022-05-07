class Solution {
    public String removeDuplicates(String S, int K) {
        char[] SC = S.toCharArray();
        int i, j;
        Stack<Integer> st = new Stack<>();
        st.add(0);
        for (i = 1, j = 1; j < S.length(); i++, j++) {
            char chr = SC[i] = SC[j];
            if (i == 0 || chr != SC[i-1]) st.add(i);
            else if (i - st.peek() + 1 == K) i = st.pop() - 1;
        }
        return new String(SC, 0, i);
    }
}