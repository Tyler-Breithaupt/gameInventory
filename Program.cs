using System;

class VideoGame
{
    public string Title { get; set; }
    public int Quantity { get; set; }

    public VideoGame(string title, int quantity)
    {
        Title = title;
        Quantity = quantity;
    }

    // Unary operator overloading: ++
    public static VideoGame operator ++(VideoGame game)
    {
        game.Quantity++;
        return game;
    }

    // Comparison operator overloading: ==
    public static bool operator ==(VideoGame game1, VideoGame game2)
    {
        return game1.Title == game2.Title && game1.Quantity == game2.Quantity;
    }

    public static bool operator !=(VideoGame game1, VideoGame game2)
    {
        return !(game1 == game2);
    }

    // Binary operator overloading: +
    public static VideoGame operator +(VideoGame game1, VideoGame game2)
    {
        if (game1.Title != game2.Title)
            throw new InvalidOperationException("Cannot add different games.");

        return new VideoGame(game1.Title, game1.Quantity + game2.Quantity);
    }

    // Display method
    public override string ToString()
    {
        return $"{Title}: {Quantity}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        VideoGame game1 = new VideoGame("The Witcher 3", 2);
        VideoGame game2 = new VideoGame("Assassin's Creed Valhalla", 3);

        // Unary operator: ++
        Console.WriteLine($"Original quantity of game1: {game1.Quantity}");
        game1++;
        Console.WriteLine($"Quantity of game1 after increment: {game1.Quantity}");

        // Comparison operator: ==
        Console.WriteLine($"game1 == game2: {game1 == game2}");
        Console.WriteLine($"game1 != game2: {game1 != game2}");

        // Binary operator: +
        try
        {
            VideoGame newGame = game1 + game2;
            Console.WriteLine($"Combined quantity of game1 and game2: {newGame}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}