namespace LeetCodeSolution;

public class Solution852
{
    // 时间复杂度为 O(n)
    public int PeakIndexInMountainArray(int[] arr) {
        return Array.IndexOf(arr, arr.Max());
    }
    
    // 二分查找 时间复杂度为 O(logn)
    public int PeakIndexInMountainArray2(int[] arr) {
        var left = 0;
        var right = arr.Length - 1;
        while (left < right)
        {
            var mid = (left + right) / 2;
            if (arr[mid] > arr[mid + 1])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }
}