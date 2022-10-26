public class Solution {
    public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital) {
        var minHeap=new Heap<(int capital,int i)>((a,b)=>b.capital.CompareTo(a.capital));
        var maxHeap=new Heap<(int profit ,int i)>((a,b)=>a.profit.CompareTo(b.profit));
        int n = Profits.Length;
        
        for(int i=0;i<n;i++){
            minHeap.Push((Capital[i],i));
        }
        int availableCapital = W;
        for (int i = 0; i < k; i++){
            while(minHeap.Count>0 && minHeap.Peek().capital<=availableCapital){
                var cap=minHeap.Pop();
                maxHeap.Push((Profits[cap.i],cap.i));
            }       
            if(maxHeap.Count==0){
                break;
            } 
            availableCapital+=maxHeap.Pop().profit;
        }
        
        return availableCapital;

    }
}
public class Heap<T> where T : IComparable<T>{
    List<T> heap=new List<T>();
    Func<T,T,int> comparFunc;
    int length=0;
    public int Count{get{return length;}}
    public Heap(){
        var array=new List<T>();
        this.comparFunc=Heap<T>.MIN_HEAP;
        this.heap=buildHeap(array);
        this.length=heap.Count;
    }
    public Heap(Func<T,T,int> func){
        var array=new List<T>();
        this.comparFunc=func;
        this.heap=buildHeap(array);
        this.length=heap.Count;
    }
    public Heap(List<T> array,Func<T,T,int> func){
        this.comparFunc=func;
        this.heap=buildHeap(array);
        this.length=heap.Count;
    }
    public T Peek(){
        return heap[0];
    }
    public T Pop(){
        swap(0,heap.Count-1,heap);
        T valueToRemove=heap[heap.Count-1];
        heap.RemoveAt(heap.Count-1);
        length-=1;
        siftDown(0,heap.Count-1,heap);

        return valueToRemove;

    }
    public void Push(T value){
        heap.Add(value);
        length+=1;
        siftUp(heap.Count-1,heap);

    }
    List<T> buildHeap(List<T> array){
        int firstParent=(array.Count-2)/2;
        for(int currentIdx=firstParent;currentIdx>=0;currentIdx--){
            siftDown(currentIdx,array.Count-1,array);
        }
        return array;
    }
    void siftDown(int currentIdx,int endIdx,List<T> heap){
        int childOne=(currentIdx*2)+1;
        while(childOne<=endIdx){
            int childTwo=(currentIdx*2)+2<=endIdx?(currentIdx*2)+2:-1;
            int idxToSwap=0;
            if(childTwo!=-1){
                if(comparFunc(heap[childTwo],heap[childOne])>0)
                    idxToSwap=childTwo;
                else
                    idxToSwap=childOne;
            }
            else{
                idxToSwap=childOne;
            }
            if(comparFunc(heap[idxToSwap],heap[currentIdx])>0){
                swap(currentIdx,idxToSwap,heap);
                currentIdx=idxToSwap;
                childOne=(currentIdx*2)+1;
            }
            else 
                return;
        }
    }
    void siftUp(int index,List<T> heap){
        int parentIndex=(index-1)/2;
        while(index>0){
            if(comparFunc(heap[index],heap[parentIndex])>0){
                swap(index,parentIndex,heap);
                index=parentIndex;
                parentIndex=(index-1)/2;
            }
            else{
                return;
            }
        }
    }
    void swap(int i,int j,List<T> heap){
        T temp=heap[j];
        heap[j]=heap[i];
        heap[i]=temp;
    }
    public static int MAX_HEAP(T a,T b){
        return a.CompareTo(b);
    }
    public static int MIN_HEAP(T a,T b){
        return b.CompareTo(a);
    }
}