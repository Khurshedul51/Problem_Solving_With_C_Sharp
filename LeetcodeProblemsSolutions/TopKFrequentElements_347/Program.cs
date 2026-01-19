// See https://leetcode.com/problems/top-k-frequent-elements/description/ for problem description

namespace TopKFrequentElements_347
{
    public class Solution
    {
        private static int[] TopKFrequent(int[] nums, int k)
        {
            /// calculating frequency of nums
            var dict = new Dictionary<int,  int>();
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            /// selecting top k frequent elements 
            var minPriorityQueue = new PriorityQueue<int, int>();
            foreach (int key in dict.Keys)
            {
                minPriorityQueue.Enqueue(key, dict[key]);

                if(minPriorityQueue.Count > k)
                {
                    minPriorityQueue.Dequeue();
                }
            }

            var ans = new int[k];
            for (int i = 0; i < k; i++)
            {
                ans[i] = minPriorityQueue.Dequeue();
            }

            return ans;
        }
        public static void Main(string[] args)
        {
            int[] nums = [1, 2, 1, 2, 1, 2, 3, 1, 3, 2];
            var k = 2;

            Console.WriteLine(string.Join(" ", TopKFrequent(nums, k)));
        }
    }
}