using ToDoList;
FilesStorage files = new FilesStorage();

Menu menu = new Menu(files);
menu.PreloadData();
menu.Run();
Console.Clear();
Console.WriteLine("Finished");