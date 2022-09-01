public class Solution 
{
    public string LicenseKeyFormatting(string s, int k) 
    {
        string str = s.Replace("-", "").ToUpper();
        int chunkSize = k;
        int stringLength = str.Length;

        string output = string.Empty;
        for (int i = stringLength; i >= 0; i -= chunkSize)
        {
            if (i < chunkSize)
            {
                if (i != 0)
                {
                    output = str.Substring(0, i) + (output == string.Empty ? "" : "-" + output);
                }
            }
            else
            {
                output = str.Substring(i - chunkSize, chunkSize) + (output == string.Empty ? "" : "-" + output);
            }
        }

        return output;
    }
}