using dATABASE.Data;
using System;
using System.Linq;

namespace dATABASE
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Students.Add(new Student { FirstName = "Adam", LastName = "Antl" });
            db.Students.Add(new Student { FirstName = "Beáta", LastName = "Bodrá" });
            db.SaveChanges();
            foreach(Student i in db.Students.ToList()) 
            {
                Console.WriteLine(i.Id + " " + i.FirstName + " " + i.LastName + " ");
            }
            Console.ReadKey();
        }
    }
}
