using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Price < 25000)
                    .Union(db.Phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
                Console.WriteLine("result:");
                var result = db.Phones.Select(p => new { Name = p.Name })
                    .Union(db.Companies.Select(c => new { Name = c.Name }));
                foreach (var item in result)
                    Console.WriteLine(item.Name);
                //Пересечение
                Console.WriteLine("Пересечение:");
                var phones2 = db.Phones.Where(p => p.Price < 25000)
                    .Intersect(db.Phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
                //Разность
                Console.WriteLine("Разность:");
                var selector1 = db.Phones.Where(p => p.Price < 25000); // Samsung Galaxy S4, Samsung Galaxy S4, iPhone S4
                var selector2 = db.Phones.Where(p => p.Name.Contains("Samsung")); // Samsung Galaxy S4, Samsung Galaxy S4
                var phones3 = selector1.Except(selector2); // результат -  iPhone S4

                foreach (var item in phones3)
                    Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
