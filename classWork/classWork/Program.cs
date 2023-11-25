using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePathSource = @"C:\Users\zunderz\Documents\projc#\classWork\classWork\qwe.jpg";

            if (File.Exists(filePathSource))
            {
                FileInfo fileInfoSource = new FileInfo(filePathSource);
                string filePathTarget = Path.Combine(fileInfoSource.Directory.FullName, $"{Path.GetFileNameWithoutExtension(fileInfoSource.Name)}-копия{fileInfoSource.Extension}");
                var size= fileInfoSource.Length;
                using (FileStream fileStreamSource = new FileStream(filePathSource, FileMode.Open))
                using (FileStream fileStreamTarget = new FileStream(filePathTarget, FileMode.Create))
                {
                    byte[] dataBuffer = new byte[size];
                    int bytesRead;
                    while ((bytesRead = fileStreamSource.Read(dataBuffer, 0, dataBuffer.Length)) > 0)
                    {
                        fileStreamTarget.Write(dataBuffer, 0, bytesRead);
                    }
                }
                Console.WriteLine($"Размер файла: {size} байт");
                Console.WriteLine($"Файл успешно скопирован в {filePathTarget}");
            }
            else
            {
                Console.WriteLine("Исходный файл не найден");
            }
        }
    }
}