// See https://aka.ms/new-console-template for more information

var corn = new Corn();
var vanilla = new Vanilla(corn);
Console.WriteLine($"{vanilla.GetName()}:{vanilla.GetPrice()}");

var choco = new Chocolate(corn);
Console.WriteLine($"{choco.GetName()}:{choco.GetPrice()}");

var mix = new Chocolate(new Vanilla(corn));
Console.WriteLine($"{mix.GetName()}:{mix.GetPrice()}");


public abstract class IceCream
{
    public abstract int GetPrice();

    public abstract string GetName();
}

public class Corn : IceCream
{
    public override int GetPrice()
    {
        return 100;
    }

    public override string GetName()
    {
        return "アイスクリーム";
    }
}

public abstract class Ice : IceCream
{
    protected readonly IceCream IceCream;

    protected Ice(IceCream iceCream)
    {
        IceCream = iceCream;
    }
}

public class Vanilla : Ice
{
    private const int Price = 50;

    public Vanilla(IceCream iceCream) : base(iceCream)
    {
    }

    public override int GetPrice()
    {
        return Price + IceCream.GetPrice();
    }

    public override string GetName()
    {
        return $"バニラ {IceCream.GetName()}";

    }
}

public class Chocolate : Ice
{
    private const int Price = 70;

    public Chocolate(IceCream iceCream) : base(iceCream)
    {
    }

    public override int GetPrice()
    {
        return Price + IceCream.GetPrice();
    }

    public override string GetName()
    {
        return $"チョコ {IceCream.GetName()}";
    }
}