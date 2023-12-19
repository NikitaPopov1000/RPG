namespace ConsoleApp1;

public abstract class StartGame
{
    internal  static  void Game(Player bob)
    {
        Console.WriteLine($"Добро пожалвоать в игру, ваш персонаж: вас зовут: {bob.Name}, у вас {bob.Health} hp, ваш урон: минимальный: {Player.MinDamage}, максимальный: {Player.MaxDamage}");
    }

    internal  static void NamePlayer(Player bob)
    {
        Console.Write("Введите ваше имя: ");
        string? name = Console.ReadLine();
        bob.Name = name;
    }
}