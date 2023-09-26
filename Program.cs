namespace CustomSinglyLinkedList;

class Program
{
    private static void Main()
    {
        try
        {
            IList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Console.WriteLine(list.IndexOf(2));
            Console.WriteLine(list.Contains(5));
            Console.WriteLine(list[0]);
            Console.WriteLine(list.Count);

            var array = new int[5];
            list.CopyTo(array, 0);
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            list.Clear();
            Console.WriteLine(list.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}