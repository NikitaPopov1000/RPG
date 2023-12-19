namespace ConsoleApp1;

public class MehanicFight
{
    static void Regeneration(Player bob)
    {
        for (var i = 0; i < bob.FullHealth; i++)
        {
            ++bob.Health;
        }

        if (bob.Health > bob.FullHealth)
        {
            bob.Health = bob.FullHealth;
        }
    }

    static void Heal(Player bob, Potions potion)
    {
        if (potion.Count > 0)
        {
            {

            }
            potion.Count -= 1;
            bob.Health += 50;
            Console.WriteLine($"Вы лечились, у вас осталось {bob.Health} Hp");
            if (bob.Health > bob.FullHealth)
            {
                bob.Health = bob.FullHealth;
            }
        } else if (potion.Count <= 0)
        {
            Console.WriteLine("У вас нет зелья? выполните другое действие");
        }
        Console.WriteLine($"У вас осталось {potion.Count} банок зелья");
    }

    public static void Fight(Player bob, Potions potion)
    {
    
        Console.WriteLine(
            $"Вы вошли на поле боя, ваш противник: {Spider._name}, у него {Spider.HealthSpider} HP и {Spider.Damage_Spider} урона");
        Console.WriteLine("Бой начинается");
        while (bob.Health > 0 && Spider.HealthSpider > 0)
        {
            string? heal;
            Console.WriteLine("Паук атакует");
            bob.Health -= Spider.Damage_Spider;
            Console.WriteLine($"Вас атаковал {Spider._name}, у вас осталось {bob.Health} Hp");
            Console.WriteLine("Ваш ход, что вы выберете? Введите a, чтобы ударить и h, чтобы вылечиться");
            heal = Console.ReadLine();
            if (heal == "a")
            {
                Console.WriteLine($"Бросается кубик, если выпадет число 2 или 4 - произойдет критическая атака");
                Spider.HealthSpider -= MehanicAttack.CriticalAttack(bob);
           
                Console.WriteLine($"Вы атаковали {Spider._name}, у противника осталось {Spider.HealthSpider} Hp");
            } else if (heal == "h")
            {
                Heal(bob, potion);
            }
        
        }

        if (bob.Health > 0 && Spider.HealthSpider <= 0)
        {
            Console.WriteLine($"Вы вышли из поля боя, ваш противник побежден");
            Player.Coins += 5;
            Regeneration(bob);
            Spider.HealthSpider = Spider.fullHealthSpider;
        }
    }
}