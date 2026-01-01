// Problem Link: https://leetcode.com/problems/contains-duplicate/

namespace ContainsDuplicate_217
{
    public class Solution
    {
        private static bool ContainsDuplicate(int[] nums)
        {
            var hashSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if(hashSet.Contains(nums[i]))
                    return true;
                else
                    hashSet.Add(nums[i]);
            }

            return false;
        }
        public static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());

            //var nums = new int[n];

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    nums[i] = int.Parse(Console.ReadLine());
            //}

            int[] nums = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2];

            Console.WriteLine(ContainsDuplicate(nums));
        }
    }
}