namespace ConsoleApp1;

public class Player
{
    Random damage = new Random();
    
    //core
    internal int Id;
    internal int Health = 100;
    internal string? Name;
    internal int Damage;
    internal int Level = 1;
    internal int NextLevel = 0;
    //stats
    internal int FullHealth = 100;
    internal static int MinDamage = 5;
    internal static int MaxDamage = 30;
    internal static uint Coins = 0;
    
}