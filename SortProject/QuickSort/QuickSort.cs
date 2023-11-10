namespace QuickSort
{
    internal class QuickSort
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 5, 8, 4, 1, 3, 6, 9, 7 };
            Sort(nums, 0, nums.Length - 1);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.WriteLine("Hello, World!");
        }

        static void Sort(int[] args, int s, int e)
        {
            if (s >= e)
                return;

            int star = s;
            int end = e;
            int pivot = args[s];
            while (star < end)
            {
                while (star < end && args[end] >= pivot)
                {
                    end--;
                }
                args[star] = args[end];
                while (star < end && args[star] <= pivot)
                {
                    star++;
                }
                args[end] = args[star];
            }
            args[star] = pivot;
            Sort(args, s, star - 1);
            Sort(args, end + 1, e);
        }
    }
}