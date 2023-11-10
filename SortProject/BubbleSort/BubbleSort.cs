///冒泡排序
namespace BubbleSort
{
    internal class BubbleSort
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 5, 8, 4, 1, 3, 6, 9, 7 };
            Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.WriteLine("Hello, World!");
        }

        static void Sort(int[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length - i - 1; j++)
                {
                    if (args[j] > args[j + 1])
                    {
                        args[j] = args[j] - args[j + 1];
                        args[j + 1] = args[j] + args[j + 1];
                        args[j] = args[j + 1] - args[j];
                    }
                }
            }
        }
    }
}