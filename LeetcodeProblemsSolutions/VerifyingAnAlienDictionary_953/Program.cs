// See https://leetcode.com/problems/verifying-an-alien-dictionary/description/ for problem description

namespace VerifyingAnAlienDictionary_953;

public class Solution
{
    public static bool IsAlienSorted(string[] words, string order)
    {
        var sortedWords = new string[words.Length];
        Array.Copy(words, sortedWords, words.Length);

        var rank = order
                        .Select((c, i) => new { c, i })
                        .ToDictionary(x => x.c, x => x.i);

        Array.Sort(sortedWords, (a, b) =>
        {
            int len = Math.Min(a.Length, b.Length);
            for(int i = 0; i < len; i++)
            {
                if (rank[a[i]] != rank[b[i]])
                {
                    var cmp = rank[a[i]].CompareTo(rank[b[i]]);
                    if (cmp != 0)
                    {
                        return cmp;
                    }
                }
            }

            return a.Length.CompareTo(b.Length);
        });

        var IsSorted = words
                            .Zip(sortedWords, (a, b) => a.Equals(b))
                            .All(x => x);

        return IsSorted;
    }
    public static void Main(string[] args)
    {
        string[] words = ["word", "world", "row"];
        var order = "worldabcefghijkmnpqstuvxyz";

        Console.WriteLine(IsAlienSorted(words, order));
    }
}