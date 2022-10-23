public class Solution {
public int CountDigitOne(int n) {

 if(n<1)
 return 0;
 
 int res=0;
 char[] cha = n.ToString ().ToCharArray ();
 Array.Reverse (cha);

 if((n+1)%(int)Math.Pow(10,cha.Length)==0&&(n+1)/(int)Math.Pow(10,cha.Length)==1){
      return 10*CountDigitOne((int)Math.Pow(10,cha.Length-1)-1)+(int)Math.Pow(10,cha.Length-1);
 }
 
 for(int i=0;i<cha.Length;i++){
     if((int)cha[i]==48)
     res+=0;

     else
 res+=((int)cha[i]-48)*CountDigitOne((int)Math.Pow(10,i)-1)+((int)cha[i]==49?n%(int)Math.Pow(10,i)+1:(int)Math.Pow(10,i));
 }
 return res;
}
}