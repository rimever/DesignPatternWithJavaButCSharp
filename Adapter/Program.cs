using System;

namespace Adapter
{
    internal class Show
    {
        public void ShowText(string text)
        {
            Console.WriteLine($"*{text}*");
        }

        public void ShowNumber(int value)
        {
            Console.WriteLine($"inputted number={value}");
        }
    }

    internal interface IPrint
    {
        /// <summary>
        /// 画面に文字を表示するメソッド
        /// </summary>
        /// <param name="text"></param>
        public void PrintText(string text);

        /// <summary>
        /// 入力された数値を表示するメソッド
        /// </summary>
        /// <param name="value"></param>
        public void PrintNumber(int value);
    }

    internal class PrintAdapter : Show, IPrint
    {
        public void PrintText(string text)
        {
            Console.WriteLine("=============");
            ShowText(text);
            Console.WriteLine("=============");
        }

        public void PrintNumber(int value)
        {
            Console.WriteLine("--------------");
            ShowNumber(value);
            Console.WriteLine("--------------");
        }
    }

    /// <summary>
    /// 委譲を使ったパターン
    /// </summary>
    internal class PrintAdapter2 : IPrint
    {
        private Show _show = new Show();

        public void PrintText(string text)
        {
            Console.WriteLine("=============");
            _show.ShowText(text);
            Console.WriteLine("=============");
        }

        public void PrintNumber(int value)
        {
            Console.WriteLine("--------------");
            _show.ShowNumber(value);
            Console.WriteLine("--------------");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Version1");
            var version1 = new Show();
            version1.ShowText("Hello World");
            version1.ShowNumber(100);

            Console.WriteLine();
            Console.WriteLine("Version2");

            var version2 = new PrintAdapter();
            version2.PrintText("Hello World");
            version2.PrintNumber(100);

            var version2_1 = new PrintAdapter2();
            version2_1.PrintText("Hello World");
            version2_1.PrintNumber(100);
        }
    }
}