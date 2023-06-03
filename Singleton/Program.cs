using System;

namespace Singleton
{
    class Singleton
    {
        private static readonly Singleton _singleton = new Singleton();

        private Singleton()
        {
            Console.WriteLine("Create Instance");
        }

        public static Singleton GetInstance() => _singleton;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var obj1 = Singleton.GetInstance();
            var obj2 = Singleton.GetInstance();
            Console.WriteLine($"二つは{(obj1 == obj2 ? "同じ" : "異なる")}インスタンスです");
            Console.WriteLine("End");
        }
    }
}