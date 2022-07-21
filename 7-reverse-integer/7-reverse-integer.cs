class Solution {
    public int Reverse (int x) {
        long value = 0;
        bool negative = x < 0;
        long y = x;
        y = Math.Abs (y);

        while (y > 0) {
            value = value * 10 + y % 10;
            y /= 10;
        }

        if (value > int.MaxValue) return 0;

        if (negative) return 0 - (int) value;
        else  return (int) value;

    }
}