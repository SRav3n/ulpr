interface IChess
{
    abstract void SecondName();
    abstract void Weight();
    abstract void Colored();
    abstract void PrintInfo();
}

abstract class ChessPiece : IChess
{
    public string Color { get; set; }
    public abstract void SecondName();
    public abstract void Weight();
    public abstract void Colored();
    public abstract void PrintInfo();

    public ChessPiece(string color)
    {
        Color = color;
    }

    ~ChessPiece()
    {
        Console.WriteLine("чета происходит...");
    }
}

abstract class LightPiece : ChessPiece
{
    public LightPiece(string color) : base(color) { }
}

abstract class HeavyPiece : ChessPiece
{
    public HeavyPiece(string color) : base(color) { }
}

class Pawn : LightPiece
{
    public Pawn(string color) : base(color) { }

    public override void Weight()
    {
        Console.WriteLine("Легкая фигура");
    }

    public override void Colored()
    {
        if (Color == "Белая" || Color == "Черная")
        {
            Console.WriteLine($"{Color} фигура");
        }
        else
        {
            Console.WriteLine("Неверно указан цвет");
        }
    }

    public override void SecondName()
    {
        Console.WriteLine("Русскоязычное название: Пешка");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[ Pawn ]");
    }
}

class King : HeavyPiece
{
    public King(string color) : base(color) { }

    public override void Weight()
    {
        Console.WriteLine("Тяжелая фигура");
    }

    public override void Colored()
    {
        if (Color == "Белая" || Color == "Черная")
        {
            Console.WriteLine($"{Color} фигура");
        }
        else
        {
            Console.WriteLine("Неверно указан цвет");
        }
    }

    public override void SecondName()
    {
        Console.WriteLine("Русскоязычное название: Король");
    }

    public override void PrintInfo()
    {
        Console.WriteLine("[ King ]");
    }
}

class Bishop : LightPiece
{
    public Bishop(string color) : base(color) { }

    public override void Weight()
    {
        Console.WriteLine("Легкая фигура");
    }

    public override void Colored()
    {
        if (Color == "Белая" || Color == "Черная")
        {
            Console.WriteLine($"{Color} фигура");
        }
        else
        {
            Console.WriteLine("Неверно указан цвет");
        }

    }

    public override void SecondName()
    {
        Console.WriteLine("Русскоязычное название: Слон");
    }

    public override void PrintInfo()
    {
        Console.WriteLine("[ Bishop ]");
    }
}

class Rook : HeavyPiece
{
    public Rook(string color) : base(color) { }

    public override void Colored()
    {
        if (Color == "Белая" || Color == "Черная")
        {
            Console.WriteLine($"{Color} фигура");
        }
        else
        {
            Console.WriteLine("Неверно указан цвет");
        }
    }

    public override void Weight()
    {
        Console.WriteLine("Тяжелая фигура");
    }

    public override void SecondName()
    {
        Console.WriteLine("Русскоязычное название: Ладья");
    }

    public override void PrintInfo()
    {
        Console.WriteLine("[ Rook ]");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите цвет [ Pawn ] (Белая / Черная): ");
            string pawn_color = Console.ReadLine();

            Console.WriteLine("Введите цвет [ Bishop ] (Белая / Черная): ");
            string bishop_color = Console.ReadLine();

            Console.WriteLine("Введите цвет [ Rook ] (Белая / Черная): ");
            string rook_color = Console.ReadLine();

            Console.WriteLine("Введите цвет [ King ] (Белая / Черная): ");
            string king_color = Console.ReadLine();

            ChessPiece[] chessPieces =
            [
                new Pawn(pawn_color),
                new Bishop(bishop_color),
                new Rook(rook_color),
                new King(king_color)
            ];

            foreach (var piece in chessPieces)
            {
                piece.PrintInfo();
                piece.Colored();
                piece.Weight();
                piece.SecondName();
                Console.WriteLine();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Что-то пошло не так :(");
        }
    }
}