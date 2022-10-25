class Solution {
public:
    string smallestGoodBase(string n) {
        unsigned long x = stol(n); 
        for (int p = log2(x); p > 1; --p) {
            int k = pow(x, 1./p); 
            unsigned long sm = 1, val = 1; 
            for (int i = 1; i <= p; ++i, val *= k, sm += val); 
            if (sm == x) return to_string(int(k)); 
        }
        return to_string(x-1); 
    }
};