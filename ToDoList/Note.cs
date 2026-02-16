namespace ToDoList;

public class Note
{
    public DateTime FirstCreate { get; set; }
    public DateTime? LastUpdate { get; set; }
    public string? NoteName { get; set; }
    public string? NoteText { get; set; }
    
    /// <summary>
    ///Конструктор для json.serializer
    /// </summary>
    public Note(){}

    /// <summary>
    /// Конструктор для створення нотатки
    /// </summary>
    /// <param name="nameOfNote"></param>
    /// <param name="noteText"></param>
    public Note(string nameOfNote, string noteText)
    {
        FirstCreate = DateTime.Now;
        NoteName = nameOfNote;
        NoteText = noteText;
    }

    public void ChangeName(string newName)
    {
        NoteName = newName;
        UpdateNote();
    }
    public void ChangeText(string newText)
    {
        NoteText = newText;
        UpdateNote();
    }

    public void UpdateNote()
    {
        LastUpdate = DateTime.Now;
    }
    public override string ToString()
    {
       return string.Format($"Час створення або редагування: {LastUpdate ?? FirstCreate}\nНазва нотатки: {NoteName}");
    }

    public void DisplayNote()
    {
        Console.WriteLine($"Дата створення: {FirstCreate}\nДата редагування: {LastUpdate?.ToString() ?? "Відсутня"}\nНазва нотатки: {NoteName}\nТекст нотатки: {NoteText}");
    }
}