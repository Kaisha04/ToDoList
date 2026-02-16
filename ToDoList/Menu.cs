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
            Console.WriteLine("Немає збережень");
            Add();
            _files.SaveNotes(_notes);
        }
        else
        {
            Console.WriteLine("Дані завантажено");
            Console.WriteLine("Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
    public void Run()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("---Меню---\n1 - Добавити нотатку" +
                              "\n2 - Переглянути нотатки" +
                              "\n3 - Вийти з програми");
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
        Console.WriteLine("Створення нотатки");
        _notes.Add(new Note(Input.GetText("Введіть назву нотатки",20),Input.GetText("Введіть запис",50)));
        _files.SaveNotes(_notes);
        Console.WriteLine("Дані збережено");
    }
    public void Show()
    {
        Console.Clear();
        if (_notes.Count == 0)
        {
            Console.WriteLine("Немає нотаток");
            Console.WriteLine("Натисність будь-яку клавішу...");
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
        int index = Input.GetNumber("Оберіть нотатку",1, _notes.Count);
        index -= 1;
        Console.Clear();
        _notes[index].DisplayNote(); ///index - 1 щоб не бути поза діапазоном колекції
        ActionToNote(index);
    }

    public void ActionToNote(int index)
    {
        Console.WriteLine("\n1 - Змінити заголовок" +
                          "\n2 - Змінити текст" +
                          "\n3 - Видалити"
                          +"\n4 - Вийти");
        switch (Input.GetNoteOption())
        {
            case Input.NoteOption.RenameMain:Console.Clear(); Console.WriteLine("Зміна назви нотатки");
                _notes[index].ChangeName(Input.GetText("Введіть назву нотатки",20));
                Console.WriteLine("Заголовок змінено");
                _files.SaveNotes(_notes);
                break;
            
            case Input.NoteOption.RenameNote: Console.Clear(); Console.WriteLine("Зміна тексту нотатки");
                _notes[index].ChangeText(Input.GetText("Введіть назву нотатки",50));
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