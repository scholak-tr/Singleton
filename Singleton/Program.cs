using System;

public class Person
{
    private static Person instance; // Статическое поле для хранения единственного экземпляра
    private int health;

    // Приватный конструктор — запрет на создание объектов вне класса
    private Person()
    {
        health = 100; // Начальное здоровье
    }

    // Свойство Instance для получения единственного экземпляра
    public static Person Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Person();
            }
            return instance;
        }
    }

    // Метод получения урона
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        Console.WriteLine($"Получен урон: {amount}. Текущее здоровье: {health}");
    }

    // Метод лечения
    public void Heal(int amount)
    {
        health += amount;
        if (health > 100) health = 100;
        Console.WriteLine($"Получено лечение: {amount}. Текущее здоровье: {health}");
    }

    // Метод получения текущего здоровья
    public int GetHealth()
    {
        return health;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Person player = Person.Instance;

        player.TakeDamage(30); // -30 HP
        player.Heal(20);       // +20 HP
        Console.WriteLine($"Финальное здоровье: {player.GetHealth()}");

        // Попробуем создать ещё одного персонажа
        Person another = Person.Instance;
        another.TakeDamage(10); // повлияет на того же самого игрока

        Console.WriteLine($"Текущее здоровье (через другой объект): {player.GetHealth()}");
        Console.ReadKey();
    }
}
