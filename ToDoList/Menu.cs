namespace ToDoList;

public class Menu
{
    private readonly FilesStorage _files;
    private List<Note>  _notes;
    
    public Menu(FilesStorage files)
    {
        _files = files;
    }
    public void PreloadData()
    {
        //Check data on instance creation
        _notes = _files.GetNotes();
        if (_notes.Count == 0)
        {
            Console.WriteLine("No saved notes");
            Add();
            _files.SaveNotes(_notes);
        }
        else
        {
            Console.WriteLine("Data loaded");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    public void Run()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("---Menu---\n1 - Add note" +
                              "\n2 - Your notes" +
                              "\n3 - Exit");
            Input.MenuOption action = Input.GetMenuOption();
            switch (action)
            {
                case Input.MenuOption.Add: Add();
                    break;
                case Input.MenuOption.Show: ManageLoopNote();
                    break;
                case Input.MenuOption.Exit: return;
            }
        } while (true);
    }

    public void ManageLoopNote()
    {
        bool stayInMenu = true;
        while (stayInMenu)
        {
            Show();
            if (_notes.Count > 0)
            {
                stayInMenu = ChooseNote();
            }else break;
        }
    }
    
    public void Add()
    {
        Console.WriteLine();
        Console.WriteLine("Creating new note...");
        _notes.Add(new Note(Input.GetText("Input note title",20),Input.GetText("Input note content",50)));
        _files.SaveNotes(_notes);
        Console.WriteLine("Data saved");
    }
    public void Show()
    {
        Console.Clear();
        if (_notes.Count == 0)
        {
            Console.WriteLine("No notes");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        byte index = 0;
        foreach (Note note in _notes)
        {
            index++;
            Console.WriteLine($"{index}: {note}");
        }
        Console.WriteLine("0 - Exit");
    }

    public bool ChooseNote()
    {
        int index = Input.GetNumber("Select a note",0, _notes.Count);
        if (index == 0) return false;
        index -= 1;
        Console.Clear();
        _notes[index].DisplayNote(); //index - 1 for length of collection
        ActionToNote(index);
        return true;
    }

    public void ActionToNote(int index)
    {
        Console.WriteLine("\n1 - Change title" +
                          "\n2 - Change content" +
                          "\n3 - Delete"
                          +"\n4 - Back");
        switch (Input.GetNoteOption())
        {
            case Input.NoteOption.RenameTitle:Console.Clear(); Console.WriteLine("Note title");
                _notes[index].ChangeName(Input.GetText("Input new title",20));
                Console.WriteLine("Title changed");
                _files.SaveNotes(_notes);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            
            case Input.NoteOption.RenameContent: Console.Clear(); Console.WriteLine("Note content");
                _notes[index].ChangeText(Input.GetText("Input new note content",50));
                Console.WriteLine("Content changed");
                _files.SaveNotes(_notes);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            
            case Input.NoteOption.Delete:
                _notes.RemoveAt(index); 
                Console.WriteLine("Note deleted");
                _files.SaveNotes(_notes);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            
            case Input.NoteOption.Back:
                default: break;
        }
    }
    
}