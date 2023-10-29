using System;
using System.Collections.Generic;

public class Character
{
    public string name;
    public float max_health, current_health, attack_points, defense_points;
    public List<Item> items;

    public Character()
    {
        name = "Unknown";
        max_health = 20;
        current_health = max_health;
        attack_points = 1;
        defense_points = 0;
        items = new List<Item>();
    }

    public Character(string name, float max_health, float attack_points, float defense_points)
    {
        this.name = name;
        this.max_health = max_health;
        this.current_health = max_health;
        this.attack_points = attack_points;
        this.defense_points = defense_points;
        items = new List<Item>();
    }

    public Item ReceiveItem(Item item)
    {
        items.Add(item);
        return item;
    }

    public void PrintStats()
    {
        Console.WriteLine("NAME: " + name);
        Console.WriteLine("HP: " + current_health + "/" + max_health);
        Console.WriteLine("ATK: " + attack_points);
        Console.WriteLine("DEF: " + defense_points);
    }
}

public enum ItemType
{
    Healing,
    Poison,
    IncreaseATK,
    IncreaseDEF,
}

public class Item
{
    public string name;
    public ItemType type;
    public float effect;

    public Item(string name, ItemType type, float effect)
    {
        this.name = name;
        this.type = type;
        this.effect = effect;
    }
}

public class Battle
{
    public void Attack(Character attacker, Character defender)
    {
        float damage = Math.Max(attacker.attack_points - defender.defense_points, 0);
        defender.current_health -= damage;
    }
}

public class Game
{
    private List<Character> characters;

    public Game()
    {
        characters = new List<Character>();
    }

    public static void Main()
    {
        Console.Clear();
        Game game = new Game();
        game.DisplayWelcome();
        game.PrintControls();

        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                char key = input[0];
                game.HandleInput(key);
            }
        }
    }

    public Character CreateCharacter(string name)
    {
        Character characterInstance = new Character(name, 100, 10, 5); // Valores de exemplo
        characters.Add(characterInstance);
        return characterInstance;
    }

    public void AddItem()
    {
    }

    public void ShowWorld()
    {
    }

    public void DisplayWelcome()
    {
        Console.WriteLine("Welcome to Desktop-RPG!");
        Console.WriteLine("Create your character");
        Console.WriteLine("What will be your name?");
        string playerName = Console.ReadLine();
        Character player = CreateCharacter(playerName);
        player.PrintStats();
    }

    public void PrintControls()
    {
        Console.WriteLine("Enter 'g' or 'G' to KEEP GOING!");
        Console.WriteLine("Enter 'h' or 'H' for HELP");
        Console.WriteLine("Enter 'q' or 'Q' to QUIT");
    }

    public void HandleInput(char key)
    {
        if (key == 'h' || key == 'H')
        {
            PrintControls();
        }

        if (key == 'q' || key == 'Q')
        {
            Console.WriteLine("Quitting...");
            Environment.Exit(0);
        }

        if (key == 'g' || key == 'G')
        {
            StartBattle();
        }

    }

    public void StartBattle()
    {
        Console.WriteLine("Select a character to start a battle:");
        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {characters[i].name}");
        }

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= characters.Count)
        {
            Character player = characters[choice - 1];
            Character enemy = CreateCharacter("Enemy"); // Cria um inimigo com nome "Enemy"
            enemy.max_health = 30;
            enemy.current_health = enemy.max_health;
            Battle battle = new Battle();
            Console.WriteLine($"{player.name} vs. {enemy.name}");

            while (player.current_health > 0 && enemy.current_health > 0)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Flee");
                int action;
                if (int.TryParse(Console.ReadLine(), out action))
                {
                    switch (action)
                    {
                        case 1:
                            battle.Attack(player, enemy);
                            battle.Attack(enemy, player);
                            Console.WriteLine($"{player.name} HP: {player.current_health}, {enemy.name} HP: {enemy.current_health}");
                            break;
                        case 2:
                            Console.WriteLine("You fled from the battle.");
                            return;
                        default:
                            Console.WriteLine("Invalid action.");
                            break;
                    }
                }
            }

            if (player.current_health <= 0)
            {
                Console.WriteLine("You were defeated!");
            }
            else
            {
                Console.WriteLine("You defeated the enemy!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
}
