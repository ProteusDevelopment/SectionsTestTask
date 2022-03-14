using Random = UnityEngine.Random;

namespace Extensions
{
    public static class ArrayExtensions
    {
        public static T GetRandom<T>(this T[] array)
        {
            int position = Random.Range(0, array.Length);

            return array[position];
        }
    }
}