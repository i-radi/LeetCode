class Solution {
public:
   int findMinStep(string board, string hand) {
	vector<int> freq(26, 0);
	for(char c: hand)
		freq[c - 'A']++;
	unordered_map<string, int> cache;
	return dfs(board, freq, cache);
}

int dfs(string board, vector<int>& freq, unordered_map<string, int>& cache) {
    string key = board + "#" + serialize(freq);
	if(cache.count(key)) {
        return cache[key];
    }
	int r = INT_MAX;
	if(board.length() == 0) {           
		r = 0;
	} else {
		for(int i = 0; i < board.length(); i++) {    
			for(int j = 0; j < freq.size(); j++) {     
                bool worthTrying = false;
                if(board[i] - 'A' == j)
                    worthTrying = true;
                else if(0 < i && board[i] == board[i - 1] && board[i] - 'A' != j) 
                    worthTrying = true;
                    
				if(freq[j] > 0 && worthTrying) {     
					board.insert(board.begin() + i, j + 'A');  
					freq[j]--;   

					string newStr = updateBoard(board);  
					int steps = dfs(newStr, freq, cache);   
					if(steps != -1) {   
						r = min(r, steps + 1);
					}

					freq[j]++; 
					board.erase(board.begin() + i);   
				}
			}
		}
	}
	if(r == INT_MAX) r = -1; 
	cache[key] = r;
	return r;
}

string updateBoard(string board) {
	 int start = 0;
	 int end = 0; 
	 int boardLen = board.length();
	 while(start < boardLen) {
		 while(end < boardLen && board[start] == board[end]) {
			 end++;  
		 }
		
		 if(end - start >= 3) {  
			 string newBoard = board.substr(0, start) + board.substr(end); 
			 return updateBoard(newBoard);    
		 } else {
			 start = end;
		 }
	 }
	 return board;
}

string serialize(vector<int>& freq) {
    string key = "";
    for(int i = 0; i < freq.size(); i++) {
        if(freq[i] > 0)
        key += to_string((char) i + 'A') + to_string(freq[i]);
    }
    return key;
}  
};