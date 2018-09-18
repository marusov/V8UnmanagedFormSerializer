using System;
using System.IO;
using System.Collections.Generic;

namespace V8FormInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            
                FormReader.Read(@"D:\develop\CSharp\Projects\V8UnmanagedFormSerializer\TestFiles\Form.bin");
        }
    }

    class FormReader
    {
        public static void Read(string filePath)
        {
            List<int> blockHeader = new List<int>();
            List<char[]> blocksize = new List<char[]>();
            
             
             
            Console.WriteLine($"Имя файла: {filePath}");
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                blockHeader.Add(reader.ReadInt32());
                blockHeader.Add(reader.ReadInt32());
                blockHeader.Add(reader.ReadInt32());
                blockHeader.Add(reader.ReadInt32());
                reader.ReadBytes(2);
                blocksize.Add(reader.ReadChars(8));
                reader.ReadByte();
                blocksize.Add(reader.ReadChars(8));
                reader.ReadByte();
                blocksize.Add(reader.ReadChars(8));
                reader.ReadBytes(3); 
                //Console.WriteLine(reader.ReadChars(8));

                int rowCount = Int32.Parse(new string(blocksize[0]), System.Globalization.NumberStyles.HexNumber) / 12;

                for(int i = 1; i <= rowCount; i++)
                { 
                  Console.WriteLine($"Файл : {i}");
                  Console.WriteLine($"Адрес атрибутов: {reader.ReadInt32()}");
                  Console.WriteLine($"Адрес тела: {reader.ReadInt32()}");
                  reader.ReadInt32();  
                }



            }
            
            Console.WriteLine($"Смещение свободных блоков: {blockHeader[0]}");
            Console.WriteLine($"Размер блока: {blockHeader[1]}");
            Console.WriteLine($"Версия: {blockHeader[2]}");
            Console.WriteLine($"Резерв: {blockHeader[3]}");

            Console.WriteLine($"Размер файла: {new string(blocksize[0])}");
            Console.WriteLine($"Размер файла: {Int32.Parse(new string(blocksize[0]), System.Globalization.NumberStyles.HexNumber)}");
            Console.WriteLine($"Размер блока: {new string(blocksize[1])}");
            Console.WriteLine($"Адрес следующего блока: {new string(blocksize[2])}");


        }
    }
}
