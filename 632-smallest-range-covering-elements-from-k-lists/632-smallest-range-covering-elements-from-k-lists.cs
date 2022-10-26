public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        var list = new List<int>();
        int len = nums.Count;
        var indexArr = new int[len];
        for(int i = 0;i<len;i++){
            indexArr[i] = nums[i].Count-1;
            int index = FindIndex(list,i,nums,indexArr);
            list.Insert(index,i);
        }
        //Console.WriteLine(string.Join(",",indexArr));
        int[] result = new int[]{nums[list.First()][indexArr[list.First()]],nums[list.Last()][indexArr[list.Last()]]};
        
        while(true){
            var lastIndex = list.Last();
            if(--indexArr[lastIndex] == -1)
                break;
        	//Console.WriteLine(j+","+indexArr[j]);
            list.RemoveAt(list.Count-1);
            
        	list.Insert(FindIndex(list,lastIndex,nums,indexArr),lastIndex);
            
        	int n1 = nums[list.First()][indexArr[list.First()]];
        	int n2 = nums[list.Last()][indexArr[list.Last()]];
            
            if(n2-n1 < result[1]-result[0] || n2-n1 == result[1]-result[0] && n1 < result[0]){
                result[0] = n1;
                result[1] = n2;
            }   
            //Console.WriteLine(string.Join(",",list));
        }
        
        return result;
    }
    
    private int FindIndex(List<int> list,int index,IList<IList<int>> nums,int[] indexArr){
        if(list.Count == 0)
        	return 0;
        
        int low = 0;
        int high = list.Count-1;
        int v = nums[index][indexArr[index]];
        while(low < high-1){
            int mid = low + (high-low)/2;
            
            int mid_v = nums[list[mid]][indexArr[list[mid]]];
            
            if(mid_v == v)
                return mid;
            else if(mid_v < v)
                low = mid;
        	else
                high = mid;
        }
        if(nums[list[low]][indexArr[list[low]]] >= v)
            return low;
        else if(nums[list[high]][indexArr[list[high]]]>= v)
            return high;
        else
            return high+1;
    }
}