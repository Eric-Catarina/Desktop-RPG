using System;

public class Character{
    public string name;
    public float max_health, current_health, attack_points, defense_points;
    public List<Item> itens;

    public Character(){
        name = "Unknown";
        max_health = 20;
        current_health = max_health;
        attack_points = 1;
        defense_points = 0;
    }

    public Character(string name, float max_health, float attack_points, float defense_points)
    {
        name = name;
        max_health = max_health;
        current_health = max_health;
        attack_points = attack_points;
        defense_points = defense_points;
        
    }

    public Item ReceiveItem(Item item){
        itens.Add(item);
        return item;
    }

    public void PrintStats(){
        Console.Clear();
        Console.WriteLine("NAME: " + name);
        Console.WriteLine("HP: " + current_health + "/" + max_health);
        Console.WriteLine("ATK: " + attack_points);
        Console.WriteLine("DEF: " + defense_points);

    }
}
public enum ItemType{
    Healing,
    Poison,
    IncreaseATK,
    IncreaseDEF,
}
public class Item{


    private string name, id, type;

    
    private float max_health, current_health, attack_points, defense_points;

}

public class Consumable: Item{

    public Consumable(ItemType type, float value){
        this.type = type;
        this.value = value;
    }



    public ItemType type;
    public float value;

    public void Drink(){
    }
}


public class ItemFactory{
    public Item GiveItem(ItemType type, float value, Character target){
            return target.ReceiveItem(new Consumable(type, value)) ;
        }
    }




public class Battle{
    public void StartBattle(){

    }
    public void EndBattle(){

    }

}

public class Game{
    
    public static void Main()
    {
        Console.Clear();
        Game game = new Game();
        game.DisplayWelcome();
        game.PrintControls();
        char input = Console.ReadLine()[0];
        game.HandleInput(input);
    }

    public Character CreateCharacter(string name){
        Character characterInstance = new Character();
        characterInstance.name = name;
        return characterInstance;
    }

    public void AddItem(){

    }

    public void ShowWorld(){

    }

    public void DisplayWelcome( ){

        Console.WriteLine("Welcome to Desktop-RPG!");
        Console.WriteLine("Create your character");
        Console.WriteLine("What will be your name?");
        string playerName = Console.ReadLine();
        Character player = this.CreateCharacter(playerName);

        player.PrintStats();
    }

    public void PrintControls(){
        Console.Write("Enter ");
        Console.Write("g/G to KEEP GOING!");
        Console.Write(" || ");
        Console.Write("h/H to HELP");
        Console.Write(" || ");
        Console.Write("q/Q to QUIT");
        Console.WriteLine("");
        
    }

    public void HandleInput(char key){
        if(key == 'h' || key == 'H'){
            this.PrintControls();
        }

        if(key == 'h' || key == 'H'){
            this.PrintControls();
        }

        if(key == 'q' || key == 'Q'){
            Console.WriteLine("Quitting...");
            return;
        }
    }
}
