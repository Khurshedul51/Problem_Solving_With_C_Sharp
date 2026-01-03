// Problem Link: https://leetcode.com/problems/product-of-array-except-self/description/

namespace ProductOfArrayExceptSelf_238
{
    public class Solution
    {
        private static int[] ProductExceptSelf(int[] nums)
        {
            var prefixProducts = new int[nums.Length];
            var postfixProducts = new int[nums.Length];
            var answer = new int[nums.Length];

            var prefixProduct = 1;
            var postfixProduct = 1;

            for (int i = 0, j = nums.Length - 1; i<nums.Length; i++, j--)
            {
                prefixProducts[i] = prefixProduct;
                postfixProducts[j] = postfixProduct;

                prefixProduct *= nums[i];
                postfixProduct *= nums[j];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] = prefixProducts[i] * postfixProducts[i];
            }

            return answer;
        }
        public static void Main(string[] args)
        {

            int[] nums = [-1, 1, 0, -3, 3];

            var answer = ProductExceptSelf(nums);
            Console.WriteLine("[" + string.Join(',', answer) + "]");
        }
    }
}