using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutPara1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = {0, 1, 2, 3, 5};
            int maxNumIndex;
            Console.WriteLine(MaxNum(intArray,out maxNumIndex));
            Console.ReadKey();
        }

        static int MaxNum(int[] nums,out int maxNumIndex)
        {
            int maxNum = nums[0];
            maxNumIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (maxNum<nums[i])
                {
                    maxNumIndex = i;
                }
            }
            return maxNum;
        }
    }
}
