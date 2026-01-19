// See https://leetcode.com/problems/longest-consecutive-sequence/description/ for problem description

namespace LongestConsecutiveSequence_128;

public class Solution
{
    public static int LongestConsecutive(int[] nums)
    {
        if(nums.Length == 0) return 0;

        var set = new HashSet<int>(nums);

        var longest = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Contains(nums[i] - 1))
            {
                var currentNum = nums[i];
                int length = 1;
                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    length++;
                    set.Remove(currentNum - 1);
                }
                longest = Math.Max(longest, length);
            }
        }

        return longest;
    }
    public static void Main(string[] args)
    {
        int[] nums = [100, 4, 200, 1, 3, 2];

        Console.WriteLine(LongestConsecutive(nums));
    }
}