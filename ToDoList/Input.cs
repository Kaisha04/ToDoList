namespace ToDoList;

public class Input
{
    public static string GetText(string textForWhat,int lengthOfText)
    {
        string? result;
        do
        {
            Console.Write($"{textForWhat}: ");
            result = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(result) && result.Length <= lengthOfText)
            {
                return result;
            }
            if(string.IsNullOrWhiteSpace(result) || result == "") Console.WriteLine("Input cannot be empty.");
            else if(result.Length > lengthOfText)Console.WriteLine("Out of range.");
        } while (true);
    }
    public static int GetNumber(string textForWhat,int min, int max)
    {
        int number;
        do
        {
            Console.Write($"{textForWhat}: ");
            bool parseNumber = Int32.TryParse(Console.ReadLine(), out number);
            if (parseNumber)
            {
                if (number >= min && number <= max)
                {
                    return number;
                } else Console.WriteLine("Out of range.");
            }else Console.WriteLine("Wrong input.");
            
        } while (true);
    }

    public static MenuOption GetMenuOption()
    {
        do
        {
            Console.Write("Select an option: ");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1: return MenuOption.Add;
                case ConsoleKey.D2: return MenuOption.Show;
                case ConsoleKey.D3: return MenuOption.Exit;
            }

            Console.WriteLine();
            Console.WriteLine("Try again");
        } while (true);
    }
    public static NoteOption GetNoteOption()
    {
        do
        {
            Console.Write  
                 ("Select an option: ");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1: return NoteOption.RenameMain;
                case ConsoleKey.D2: return NoteOption.RenameNote;
                case ConsoleKey.D3: return NoteOption.Delete;
                case ConsoleKey.D4: return NoteOption.Exit;
            }
            
            Console.WriteLine("Try again");
        } while (true);
    }

    public enum MenuOption : byte
    {
        Add = 1,
        Show,
        Exit   
    }
    public enum NoteOption : byte
    {
        RenameMain = 1,
        RenameNote,
        Delete,
        Exit   
    }
}
