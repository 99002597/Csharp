using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    [Serializable]
    public class SerialBinary
    {
        public void DoSerialize()
        {
            ClassSerialization cs = new ClassSerialization();
            FileStream file = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, cs);
            file.Close();
        }
        public void DoDeSerialize()
        {
            ClassSerialization cs = new ClassSerialization();
            FileStream file = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            cs = (ClassSerialization)bf.Deserialize(file);
            Console.WriteLine(cs.name);
            file.Close();
        }
        public static void Main(string[] args)
        {
            SerialBinary sb = new SerialBinary();
            sb.DoSerialize();
            sb.DoDeSerialize();
        }
    }
    public class ClassSerialization
    {
        public int age;
        public string name;
        public string companyname;
        public int Age
        {
            get
            { return age; }
            set
            { age = value; }
        }
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }
        public string CompanyName
        {
            get
            { return companyname; }
            set
            { companyname = value; }
        }
    }
}