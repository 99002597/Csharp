using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cust
    {
        public Cust(int Custid, string name, string address, double salary)
        {
            CustID = Custid;
            Name = name;
            Address = address;
            Salary = salary;
        }

        public int CustID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }
    interface ICustManager
    {
        bool AddCust(Cust cu);
        bool DeleteCust(int id);
        Cust[] FindCust(string title);
        bool UpdateCust(int id);
        bool ViewAllCust();
    }
    class CustManager : ICustManager
    {
        HashSet<Cust> custs = new HashSet<Cust>();
        public bool AddCust(Cust cu)
        {
            return custs.Add(cu);
        }

        public bool DeleteCust(int id)
        {
            foreach (Cust cu in custs)
            {
                if (cu.CustID == id)
                {
                    custs.Remove(cu);
                    return true;
                }
            }
            return false;
        }

        public Cust[] FindCust(string name)
        {
            List<Cust> findlist = new List<Cust>();
            foreach (Cust cu in custs)
            {
                if (cu.Name.Contains(name))
                {
                    findlist.Add(cu);
                }
            }
            return findlist.ToArray();
        }

        public bool UpdateCust(int id)
        {
            foreach (Cust cu in custs)
            {
                if (cu.CustID == id)
                {
                    Console.Write("Enter Name: ");
                    string new_name = Console.ReadLine();
                    Console.Write("Enter the Address: ");
                    string new_address = Console.ReadLine();
                    Console.Write("Enter the Salary: ");
                    double new_salary = double.Parse(Console.ReadLine());
                    cu.Name = new_name;
                    cu.Address = new_address;
                    cu.Salary = new_salary;
                    return true;
                }
            }
            return false;
        }
        public bool ViewAllCust()
        {
            foreach (var cu in custs)
            {
                
                Console.WriteLine($"Customer ID: {cu.CustID}");
                Console.WriteLine($"Customer Name: {cu.Name}");
                Console.WriteLine($"Customer Address: {cu.Address}");
                Console.WriteLine($"Customer Salary: {cu.Salary}");
                
            }
            return true;
        }
    }

    class CollectionCustManager
    {
        static void Main(string[] args)
        {
            Cust cu1 = new Cust(108, "Gaurav", "Shillong", 30000);
            Cust cu2 = new Cust(112, "Priya", "Bhilai", 25000);
            Cust cu3 = new Cust(300, "Neville", "New York", 58000);
            CustManager mg = new CustManager();
            mg.AddCust(cu1);
            mg.AddCust(cu2);
            mg.AddCust(cu3);
            mg.ViewAllCust();
            mg.UpdateCust(300);
            mg.ViewAllCust();
            Cust[] temp = mg.FindCust("Gaurav");
            foreach (var item in temp)
            {
                Console.WriteLine(item.CustID);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Salary);
            }
        }

    }
}