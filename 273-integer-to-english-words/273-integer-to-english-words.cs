public class Solution 
{
    string[] lessThan20 = ",One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Eleven,Twelve,Thirteen,Fourteen,Fifteen,Sixteen,Seventeen,Eighteen,Nineteen".Split(",");
    string[] tens = ",Ten,Twenty,Thirty,Forty,Fifty,Sixty,Seventy,Eighty,Ninety".Split(",");
    string[] thousands = ",Thousand,Million,Billion".Split(","); 
    
    public string NumberToWords(int num) 
    {
        if(num == 0) return "Zero";
        var result = new List<string>();
        for(int i = 0; i < thousands.Length; i++)
        {
            var lessThanThousand = num % 1000;
            num = num / 1000;
            if(lessThanThousand != 0)
            {
                var res = ConvertLessThanThousand(lessThanThousand);
                res.Add(thousands[i]);
                res.AddRange(result);
                result = res;
            }
        }
        
        return string.Join(" ", result.Where(x => !string.IsNullOrWhiteSpace(x))).Trim();
    }
    
    private List<string> ConvertLessThanThousand(int n)
    {
        var result = new List<string>();
        if(n < 20)
            result.Add(lessThan20[n]);
        else if(n < 100)
        {
            result.Add(tens[n / 10]);
            result.AddRange(ConvertLessThanThousand(n % 10));
        }
        else
        {
            result.AddRange(ConvertLessThanThousand(n / 100));
            result.Add("Hundred");
            result.AddRange(ConvertLessThanThousand(n % 100));
        }
        
        return result;
    }
}