using ToDoList;
List<Note> notes = new List<Note>();
FilesStorage files = new FilesStorage();

Menu menu = new Menu(files,notes);
menu.PreloadData();
menu.Run();
Console.Clear();
Console.WriteLine("Програму завершено");