using System;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("zipFile.rip", ZipArchiveMode.Create);

            zipFile.CreateEntryFromFile("copyMe.png", "newMe.png");


        }
    }
}
