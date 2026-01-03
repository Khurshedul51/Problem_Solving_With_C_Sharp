// Problem Link: https://leetcode.com/problems/contains-duplicate-ii/

namespace ContainsDuplicateII_219
{
    public class Solution
    {
        private static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    if (Math.Abs(dict[nums[i]] - i) <= k)
                        return true;

                    dict[nums[i]] = i;
                }
                else
                    dict.Add(nums[i], i);
            }

            return false;
        }
        public static void Main(string[] args)
        {

            int[] nums = [1, 2, 3, 1, 2, 3];
            int k = 2;

            Console.WriteLine(ContainsNearbyDuplicate(nums, k));
        }
    }
}