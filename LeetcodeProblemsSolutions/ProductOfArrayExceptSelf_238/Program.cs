// Problem Link: https://leetcode.com/problems/product-of-array-except-self/description/

namespace ProductOfArrayExceptSelf_238
{
    public class Solution
    {
        /// <summary>
        /// <para>
        ///     Time Complexity: O(n)
        /// </para>
        /// <para>
        ///     Space Complexity: O(n)
        /// </para>
        /// </summary>
        /// <param name="nums">Array of integers</param>
        /// <returns>An integer array</returns>
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

        /// <summary>
        /// <para>
        ///     Time Complexity: O(n)
        /// </para>
        /// <para>
        ///     Space Complexity: O(1)
        /// </para>
        /// </summary>
        /// <param name="nums">Array of integers</param>
        /// <returns>An integer array</returns>
        private static int[] ProductExceptSelfOptimal(int[] nums)
        {
            var answer = new int[nums.Length];

            /// calculating prefix product for the nums[i] and storing it in the answer[i]
            var prefixProduct = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] = prefixProduct;
                prefixProduct *= nums[i];
            }

            /// calculating suffix product for the nums[i] and multiplying with answer[i]
            /// that stores the prefix product of nums[i]
            /// product except self of nums[i] = prefix product[i] * suffix product[i]
            /// and storing it in the answer[i]
            var suffixProduct = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                answer[i] *= suffixProduct;
                suffixProduct *= nums[i];
            }

            return answer;
        }
        public static void Main(string[] args)
        {

            int[] nums = [1, 2, 3, 4];

            //var answer = ProductExceptSelf(nums);
            //Console.WriteLine("[" + string.Join(',', answer) + "]");

            var answer = ProductExceptSelfOptimal(nums);
            Console.WriteLine(string.Join(" ", answer));
        }
    }
}