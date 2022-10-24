public class RandomizedCollection {
    Dictionary<int, int> d;
    private Random rand;
    List<int> values;
    
    /** Initialize your data structure here. */
    public RandomizedCollection() {
        d = new Dictionary<int, int>();
        rand = new Random();
        values = new List<int>();
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) {
        values.Add(val);
        if (!d.ContainsKey(val))
        {
            d.Add(val, 1);
            return true;
        }

        d[val]++;
        return false;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) {
        if (!d.ContainsKey(val))
        {
            return false;
        }

        values.Remove(val);
        d[val]--;
        
        if (d[val] == 0)
            d.Remove(val);
        
        return true;
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() {   
        return values[rand.Next(values.Count)];
    }
}