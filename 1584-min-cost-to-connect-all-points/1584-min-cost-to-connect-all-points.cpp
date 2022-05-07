class Solution {
public:
  int minCostConnectPoints(vector<vector<int>>& points) {
    const int n = points.size();
    auto dist = [](const vector<int>& pi, const vector<int>& pj) {
      return abs(pi[0] - pj[0]) + abs(pi[1] - pj[1]);
    };
    vector<int> ds(n, INT_MAX);  
    for (int i = 1; i < n; ++i)
      ds[i] = dist(points[0], points[i]);
    
    int ans = 0;
    for (int i = 1; i < n; ++i) {
      auto it = min_element(begin(ds), end(ds));
      const int v = distance(begin(ds), it);
      ans += ds[v];      
      ds[v] = INT_MAX; // done
      for (int i = 0; i < n; ++i) {
        if (ds[i] == INT_MAX) continue;
        ds[i] = min(ds[i], dist(points[i], points[v]));
      }        
    }
    return ans;
  }
};