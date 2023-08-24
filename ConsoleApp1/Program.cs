using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckTienDoP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<string> lstName = new List<string>();
            string[] names =
            {
                "Poter Rosse",
                "Camila Mccoy",
                "Giang Nguyen",
                "Hoang Pham",
                "Anna Tran",
                "Tho Nguyen",
                "Jessie Ochoa",
                "Kyra Howe",
                "Ace Moyer",
                "Jermaine Conway",
                "Haylee Trevino",
                "Alice Lawson",
                "Janiah Davies",
                "Zaiden Leblanc",
                "Efrain Boyd",
                "Litzy Wilson",


            };
            lstName.AddRange(names);
            if (lstName.Count == 0)
            {
                Console.WriteLine("Có cái nịt");
                return;
            }

            var data = lstName.Select(name =>
            {
                string[] splitName = name.Split(' ');
                int indexLastName = splitName.Length - 1;
                string lastName = splitName[indexLastName];
                return new
                {
                    OriginaleName = name,
                    LastName = lastName,
                };

            }).OrderBy(x => x.LastName).GroupBy(x => x.LastName[0]).ToList();

            foreach (var item in data)
            {
                Console.WriteLine(value: $"*{item.Key}");
                foreach (var nameinfo in item)
                {
                    Console.WriteLine(nameinfo.OriginaleName);
                }
            }
            Console.WriteLine("Nhập từ cần tìm");
            string find = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(find))
            {
                Console.WriteLine("Nà ní");
                return;
            }
            find = find.ToLower().Replace(" ", "");
            char[] findChar = find.ToCharArray();
            int length = findChar.Length;
            int count = 0;
            bool check = false;
            foreach (var item in lstName)
            {
                foreach (var c in findChar)
                {
                    if (item.ToLower().Contains(c))
                    {
                        count++;
                        continue;
                    }
                }
                if (count == length)
                {
                    Console.WriteLine(item);
                    check = true;
                }
                count = 0;
            }
            if(!check)
            {
                Console.WriteLine("Không thỏa mãn");
            }
            Console.ReadKey();
        }
    }
}
