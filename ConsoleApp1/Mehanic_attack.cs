
namespace ConsoleApp1;
//механики боя
public abstract class MehanicAttack
{
    
    internal static int CriticalAttack(Player obj)
    {
        Random damage = new Random();
        int diceRoll = damage.Next(1, 10);
        Console.WriteLine("Бросается кубик");
        Console.WriteLine($"Выпало число {diceRoll}");
        if(diceRoll % 2 == 0)
        {
            var criticalAttack = obj.Damage * 2;
            Console.WriteLine($"Критическая атака");
            return criticalAttack;
        }
        else
        {
            Console.WriteLine($"Не прошла критическая атака");
        }
        return obj.Damage;
    }
}