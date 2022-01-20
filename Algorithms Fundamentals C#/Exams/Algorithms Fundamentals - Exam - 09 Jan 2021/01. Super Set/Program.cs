using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Super_Set
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var subset = Subsets(arr).Reverse();
            foreach (var sub in subset)
            {
                Console.WriteLine(string.Join(" ",sub));
            }
        }
        public static IList<IList<int>> Subsets(int[] nums)
        {
            if (nums == null) return null;

            HashSet<string> unique = new HashSet<string>();
            IList<IList<int>> lst = new List<IList<int>>();
            if (nums.Length == 0)
                return lst;
            lst.Add(new int[0]);

            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(nums);

            while (q.Count != 0)
            {
                int[] temp1 = q.Dequeue();
                lst.Add(temp1);

                if (temp1.Length > 1)
                {
                    for (int i = 0; i < temp1.Length; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        int[] temp2 = new int[temp1.Length - 1];
                        int counter = 0;
                        for (int j = 0; j < temp1.Length; j++)
                        {
                            if (j != i)
                            {
                                temp2[counter++] = temp1[j];
                                sb.Append(temp1[j].ToString() + "-");
                            }
                        }
                        if (!unique.Contains(sb.ToString()))
                        {
                            unique.Add(sb.ToString());
                            q.Enqueue(temp2);
                        }
                    }
                }
            }

            return lst;
        }
    }
}
