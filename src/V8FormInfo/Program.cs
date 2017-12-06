using System;

namespace V8FormInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            int argsCount = args.Length;
            
            if (argsCount == 0)
            {
                Console.WriteLine("Вывод информации о составе контейнера обычной формы 1С:Предприятие 8");
            }
        }
    }
}
