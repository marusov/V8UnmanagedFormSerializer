using System;
using System.IO;
using System.Collections.Generic;

namespace V8FormInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            int argsCount = args.Length;
            
            if (argsCount != 1)
            {
                Console.WriteLine("Вывод информации о составе контейнера обычной формы 1С:Предприятие 8");
            }
            else
            {
                FormReader.Read(args[0]);
            }
        }
    }

    class FormReader
    {
        public static void Read(string filePath)
        {
            List<int> blockHeader = new List<int>();
            
            Console.WriteLine($"Имя файла: {filePath}");
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                blockHeader.Add(reader.ReadInt32());
                blockHeader.Add(reader.ReadInt32());
                blockHeader.Add(reader.ReadInt32());
                blockHeader.Add(reader.ReadInt32());

            }
            
            Console.WriteLine($"Маркер: {blockHeader[0]}");
            Console.WriteLine($"Размер: {blockHeader[1]}");
            Console.WriteLine($"Версия: {blockHeader[2]}");
            Console.WriteLine($"Резерв: {blockHeader[3]}");


        }
    }
}
