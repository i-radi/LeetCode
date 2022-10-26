public class Solution {
public int CheckRecord(int n) {
	var late0 = new long[n + 1];
	var late1 = new long[n + 1];
	var late2 = new long[n + 1];
	late0[0] = 1;
	late0[1] = 1;
	late1[1] = 1;
	late2[1] = 0;
	for (var i = 2; i <= n; i++) {
		late0[i] = (late0[i - 1] + late1[i - 1] + late2[i - 1]) % 1000000007;
		late1[i] = late0[i - 1];
		late2[i] = late1[i - 1];
	}
	var noAbsent = late0[n] + late1[n] + late2[n];
	var oneAbsent = 0L;
	for (var i = 0; i < n; i++) {
		oneAbsent = (oneAbsent + late0[i + 1] * late0[n - i]) % 1000000007;
	}
	return (int)((noAbsent + oneAbsent) % 1000000007);
}
}