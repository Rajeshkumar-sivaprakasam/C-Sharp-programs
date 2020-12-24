using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    public int countingDivisable(int s, int e)
    {
        var count = 0;
        while(s <= e)
        {
            if (s % 3 != 0 && s % 5 != 0 && s % 7 != 0)
            {
                count++;
            }
            s++;
        }
        
        
        return count;
    }
    static void Main(String[] args) {
        
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var s = Convert.ToInt32(Console.ReadLine());
        var e = Convert.ToInt32(Console.ReadLine());
        Solution obj = new Solution();
        Console.WriteLine(obj.countingDivisable(s,e));
        
    }
}