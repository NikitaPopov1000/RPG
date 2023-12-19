namespace ConsoleApp1;

public abstract class BuyItems
{
    internal static void Shop(Items sword, Potions potion)
    {
        Console.WriteLine("Добро пожаловать в магазин");
        Console.WriteLine("Чтобы посмотреть предметы - нажмите 1");
        Console.WriteLine("Чтобы выйти из магазина - 2");
        Console.WriteLine("Если хотите увидеть зелья - введите 3");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
    
                Console.WriteLine($"{sword.Name} - {sword.Price} рублей, дает +2 к урону");
                Console.WriteLine("Если хотите купить прдемет - введите 1");
                var buy = Console.ReadLine();
                if (buy == "1")
                {
                    if (Player.Coins >= sword.Price)
                    {
                        Player.Coins -= 5;
                        Player.MaxDamage += 2;
                        Player.MinDamage += 2;
                    }
                    else if (Player.Coins < sword.Price)
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                    
                }
    
                break;
    
    
            case "2":
                Console.WriteLine("Вы вышли из магазина");
                break;
            case "3":
                Console.WriteLine(" В наличие есть зелье лечения, оно лечит на 50 здоровья и стоит 10 монет, желаете купить? ");
                Console.WriteLine("Если хотите купить - введите 1");
                var buyPoison = Console.ReadLine();
                if (buyPoison == "1")
                { 
                    if (Player.Coins >= 10)
                    {
                        Player.Coins -= 10;
                        potion.Count += 1;
                    }
                    else if (Player.Coins < potion.Price)
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    
                    }
    
                    
                }
    
                break;
    
            default:
                Console.WriteLine("Вы ввели неверный ввод");
                break;
        }
    
       
    
    
    }
}