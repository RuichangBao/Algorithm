//选择排序
namespace SelectSort
{
    internal class SelectSort
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
                int lengthIndex = args.Length - i - 1;
                int maxIndex = lengthIndex;
                for (int j = 0; j < lengthIndex; j++)
                {
                    if (args[j] > args[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != lengthIndex)
                {
                    args[maxIndex] = args[maxIndex] - args[lengthIndex];
                    args[lengthIndex] = args[maxIndex] + args[lengthIndex];
                    args[maxIndex] = args[lengthIndex] - args[maxIndex];
                }
            }
        }
    }
}