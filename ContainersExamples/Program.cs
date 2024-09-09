namespace Containers
{
    public class Program
    {
        static void Main()
        {
            List<int> integerList = new() { 2, 1, 3 };
            Console.WriteLine("first element = " + integerList.ElementAt(0));
            Console.WriteLine("last element = " + integerList.ElementAt(integerList.Count - 1));

            integerList.Add(11);
            integerList.Add(5);

            Console.WriteLine("second element = " + integerList[1]);
            Console.WriteLine("last element = " + integerList[integerList.Count - 1]);

            Console.WriteLine($"size List = {integerList.Count}");

            List<string> strings = new List<string>();
            foreach (int value in integerList)
            {
                strings.Add(Convert.ToString(value));
            }
            Console.WriteLine($"IntegerList elements: [{String.Join(", ", strings.ToArray())}]");

            integerList.Remove(11);
            integerList.RemoveAt(3);

            strings.Clear();
            foreach (int value in integerList)
            {
                strings.Add(Convert.ToString(value));
            }
            Console.WriteLine($"After remove IntegerList elements: [{String.Join(", ", strings.ToArray())}]");

            integerList.Sort();
            strings.Clear();
            foreach (int value in integerList)
            {
                strings.Add(Convert.ToString(value));
            }
            Console.WriteLine($"After sorting IntegerList elements: [{String.Join(", ", strings.ToArray())}]");

            Console.WriteLine($"Element 11 exists ? {integerList.Contains(11)}");
            if(integerList.Find(x => x == 1) == 0)
            {
                Console.WriteLine("1 not finded");
            }
            else
            {
                Console.WriteLine("1 finded");
            }
        }
    }
}
