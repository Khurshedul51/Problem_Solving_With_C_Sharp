// Problem Link: https://leetcode.com/problems/valid-anagram/description/

namespace ValidAnagram_242
{
    public class Solution
    {
        private static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) 
                return false;

            var dictS = new Dictionary<char, int>();
            var dictT = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if(dictS.ContainsKey(s[i]))
                    dictS[s[i]] = dictS[s[i]] + 1;
                else dictS.Add(s[i], 1);

                if (dictT.ContainsKey(t[i]))
                    dictT[t[i]] = dictT[t[i]] + 1;
                else dictT.Add(t[i], 1);
            }

            if (dictS.Count != dictT.Count)
                return false;

            foreach( var pair in dictS)
            {
                var key = pair.Key;
                var value = pair.Value;

                if (!dictT.ContainsKey(key))
                {
                    return false;
                }
                else if (dictT[key] != value)
                    return false;
            }

            return true;
        }
        public static void Main(string[] args)
        {
            var s = "rat";
            var t = "car";

            Console.WriteLine(IsAnagram(s, t));
        }
    }
}