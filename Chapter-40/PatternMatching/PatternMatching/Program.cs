bool done = false;

Potion current = Potion.Water;
Ingredient ingredient;

while (!done)
{
    Console.WriteLine($"You're potion is currently {current}." +
        $" What would you like to add?\n" +
        $"1) Stardust\n" +
        $"2) Snake Venom\n" +
        $"3) Dragon Breath\n" +
        $"4) Shadow Glass\n" +
        $"5) Eyeshine Gem\n");

    ingredient = Console.ReadLine() switch
    {
        "1" => Ingredient.Stardust,
        "2" => Ingredient.SnakeVenom,
        "3" => Ingredient.DragonBreath,
        "4" => Ingredient.ShadowGlass,
        "5" => Ingredient.EyeshineGem,
        _ => Ingredient.None,
    };

    current = Mix(current, ingredient);

    if (current == Potion.Ruined)
    {
        Console.WriteLine("You've ruined this potion. Try again?");
        current = Potion.Water;
    }
    else
    {
        Console.WriteLine("Would you like to continue?");
    }

    ConsoleKeyInfo response = Console.ReadKey();

    done = response.Key switch
    {
        ConsoleKey.Y or ConsoleKey.Enter => false,
        _ => true
    };
}

Potion Mix(Potion potion, Ingredient ingredient)
{
    return (potion, ingredient) switch
    {
        (Potion.Water, Ingredient.Stardust) => Potion.Elixir,
        (Potion.Elixir, Ingredient.SnakeVenom) => Potion.Poison,
        (Potion.Elixir, Ingredient.DragonBreath) => Potion.Flying,
        (Potion.Elixir, Ingredient.ShadowGlass) => Potion.Invisibility,
        (Potion.Elixir, Ingredient.EyeshineGem) => Potion.NightSight,
        (Potion.NightSight, Ingredient.ShadowGlass) => Potion.Cloudy,
        (Potion.Invisibility, Ingredient.EyeshineGem) => Potion.Cloudy,
        (Potion.Cloudy, Ingredient.Stardust) => Potion.Wraith,
        _ => Potion.Ruined
    };
}


public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem,
    None
}
public enum Potion
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    Cloudy,
    Wraith,
    Ruined
}