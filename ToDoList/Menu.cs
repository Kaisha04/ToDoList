namespace ToDoList;

public class Menu
{
    private readonly FilesStorage _files;
    private List<Note>  _notes;

    public Menu(FilesStorage files, List<Note> notes)
    {
        _files = files;
        _notes = notes;
    }
    public void PreloadData()
    {
        //Перевірка даних при створенні екземпляру
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
                              "\n2 - Your note" +
                              "\n3 - Exit");
            Input.MenuOption action = Input.GetMenuOption();
            switch (action)
            {
                case Input.MenuOption.Add: Add();
                    break;
                case Input.MenuOption.Show: Show();
                    if (_notes.Count > 0)
                    {
                        ChooseNote();
                    } break;
                case Input.MenuOption.Exit: return;
            }
        } while (true);
    }
    
    public void Add()
    {
        Console.WriteLine();
        Console.WriteLine("Creating new note...");
        _notes.Add(new Note(Input.GetText("Input note name",20),Input.GetText("Input note text",50)));
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
    }

    public void ChooseNote()
    {
        int index = Input.GetNumber("Select a note",1, _notes.Count);
        index -= 1;
        Console.Clear();
        _notes[index].DisplayNote(); ///index - 1 for length of collection
        ActionToNote(index);
    }

    public void ActionToNote(int index)
    {
        Console.WriteLine("\n1 - Change name" +
                          "\n2 - Change text" +
                          "\n3 - Delete"
                          +"\n4 - Back");
        switch (Input.GetNoteOption())
        {
            case Input.NoteOption.RenameMain:Console.Clear(); Console.WriteLine("Note name");
                _notes[index].ChangeName(Input.GetText("Input new name",20));
                Console.WriteLine("Name changed");
                _files.SaveNotes(_notes);
                break;
            
            case Input.NoteOption.RenameNote: Console.Clear(); Console.WriteLine("Note text");
                _notes[index].ChangeText(Input.GetText("Input new note text",50));
                _files.SaveNotes(_notes);
                break;
            
            case Input.NoteOption.Delete:
                _notes.RemoveAt(index); 
                _files.SaveNotes(_notes);
                break;
            
            case Input.NoteOption.Exit: break;
        }
    }
    
}