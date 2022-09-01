public class Solution 
{
    public string LicenseKeyFormatting(string s, int k) 
    {
        s = s.Replace("-", "").ToUpper();
        
        StringBuilder sb = new StringBuilder(s);
        
        for(int i=s.Length-k;i>0;i-=k)
        {
            sb.Insert(i,"-");
        }
        return sb.ToString();
    }
}