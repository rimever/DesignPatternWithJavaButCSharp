using System;
using System.Collections.Generic;

namespace Prototype
{
    internal interface IItem
    {
        public void Get();
        public void Use();
        public IItem CreateClone();
    }

    internal class Manager
    {
        private readonly Dictionary<string, IItem> _itemMap = new();

        public void Register(string name, IItem item)
        {
            _itemMap.Add(name, item);
        }

        public IItem Create(string itemName)
        {
            var item = _itemMap[itemName];
            return item.CreateClone();
        }
    }

    internal class Potion : IItem
    {
        private readonly string _name;

        public Potion(string name)
        {
            _name = name;
        }

        public void Get()
        {
            Console.WriteLine($"{_name}を獲得しました。");
        }

        public void Use()
        {
            Console.WriteLine($"{_name}を使いました。");
        }

        public IItem CreateClone()
        {
            return new Potion(_name);
        }
    }

    internal class Sword : IItem
    {
        private readonly string _name;

        public Sword(string name)
        {
            _name = name;
        }

        public void Get()
        {
            Console.WriteLine($"{_name}を獲得しました。");
        }

        public void Use()
        {
            Console.WriteLine($"{_name}で攻撃しました");
        }

        public IItem CreateClone()
        {
            return new Sword(_name);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var manager = new Manager();
            var redPotion = new Potion("赤いポーション");
            manager.Register("redPotion", redPotion);
            var orangePotion = new Potion("オレンジのポーション");
            manager.Register("orangePotion", orangePotion);
            var copperSword = new Sword("銅の剣");
            manager.Register("copperSword", copperSword);

            var sword1 = manager.Create("copperSword");
            sword1.Get();
            sword1.Use();

            var potion1 = manager.Create("redPotion");
            potion1.Get();
            potion1.Use();

            var potion2 = manager.Create("orangePotion");
            potion2.Get();
            potion2.Use();
        }
    }
}