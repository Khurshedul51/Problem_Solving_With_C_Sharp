// Problem Link: https://leetcode.com/problems/group-anagrams/description/

using System.Text;

namespace GroupAnagrams_49
{
    public class Solution
    {
        private static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if(strs.Length == 0)
                return [];

            var list = new List<IList<string>>();
            var dict = new Dictionary<string, IList<string>>();
            
            foreach (string str in strs)
            {
                var counts = new int[26];
                foreach (char c in str)
                {
                    counts[c - 'a']++;
                }

                var sb = new StringBuilder();
                foreach (var count in counts)
                {
                    sb.Append('#');
                    sb.Append(count);
                }

                var key = sb.ToString();
                if (!dict.ContainsKey(key))
                {
                    dict[key] = [];
                }
                dict[key].Add(str);
            }

            list = [.. dict.Values];

            return list;
        }
        public static void Main(string[] args)
        {
            string[] strs = ["eat", "tea", "tan", "ate", "nat", "bat"];

            var groupAnagrams = GroupAnagrams(strs);

            Console.Write("[");
            foreach (var list in groupAnagrams)
            {
                Console.Write("["+ string.Join(',', list) + "],");
            }
            Console.WriteLine("]");
        }
    }
}