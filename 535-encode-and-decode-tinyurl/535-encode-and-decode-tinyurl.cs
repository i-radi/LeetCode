public class Codec {
 
    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(longUrl));
    }
 
    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        return Encoding.UTF8.GetString(Convert.FromBase64String(shortUrl));
    }
}
// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));