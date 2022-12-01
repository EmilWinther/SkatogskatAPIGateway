namespace SkatogskatAPI
{
    public static class Sortering
    {
        public static bool IsSorted<T>(this T[] arr, bool desc = false) where T : IComparable<T>
        {
            if (desc) return IsSortedDescending(arr); // TODO looking for smarter implementation
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSortedDescending<T>(this T[] arr) where T : IComparable<T>
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSorted<T>(this IEnumerable<T> data, bool desc = false) where T : IComparable<T>
        {
            T[] arr = data.ToArray();
            return IsSorted(arr, desc);
        }
    }
}
