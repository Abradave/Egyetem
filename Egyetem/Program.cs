using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Egyetem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Read();
            Length(nums);
            MinimumOrder(nums);
            BuborekOrder(nums);
            BeszuroOrder(nums);
            Console.ReadKey();
        }

        static void Length(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count++;
            }
            Console.WriteLine("Ilyen hosszú a lista {0}", count);
        }

        static int[] Read()
        {
            string[] beo = System.IO.File.ReadAllLines(@"D:\Downloads\szamok.txt");
            int[] nums = new int[beo.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(beo[i]);
            }
            return nums;
        }

        static void MinimumOrder(int[] nums)
        {
            for (int j = 0; j < nums.Length - 1; j++)
            {
                int min = j;
                for (int i = j + 1; i < nums.Length; i++)
                {
                    if (nums[i] < nums[min])
                    {
                        min = i;
                    }
                }
                int swap = nums[min];
                nums[min] = nums[j];
                nums[j] = swap;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }

        static void BuborekOrder(int[] nums) 
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int swap = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = swap;
                    }
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }

        static void BeszuroOrder(int[] nums) 
        {
            int j = 0;
            int x = 0;

            for (int i = 2; i < nums.Length; i++)
            {
                j = i - 1;
                x = nums[i];
                while (j >= 1 && x < nums[j])
                {
                    nums[j + 1] = nums[j];
                    j = j - 1;
                }
                nums[j + 1] = x;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
