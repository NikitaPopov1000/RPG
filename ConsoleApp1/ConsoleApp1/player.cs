namespace ConsoleApp1;

public class Player
{
    
    //core
    public int Id;
    public int Health = 100;
    public string? Name;
    public int Damage;
    public int Level = 1;
    public int NextLevel = 0;
    //stats
    public int FullHealth = 100;
    public static int MinDamage = 5;
    public static int MaxDamage = 30;
    public static uint Coins = 0;
    
    void LevelUpStats(ref int minDamage, ref int maxDamage)
    {
        minDamage += 10;
        maxDamage += 10;
    }
}