namespace LinqSamples.Extensions
{
    public static class ConsoleExtension
    {
        public static void ToConsole<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
