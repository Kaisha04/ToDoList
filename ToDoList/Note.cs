using System.Text.Json.Serialization;

namespace ToDoList;

public class Note
{
    [JsonInclude] //Attribute to include private property in JSON serialization
    public DateTime FirstCreate { get; private set; }
    [JsonInclude]
    public DateTime? LastUpdate { get; private set; }
    [JsonInclude]
    public string? NoteName { get; private set; }
    [JsonInclude]
    public string? NoteText { get; private set; }
    
    public Note(){}

    /// <summary>
    /// Constructor for create a new note
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
        return $"Last Modified: {LastUpdate ?? FirstCreate}\nTitle: {NoteName}";
    }

    public void DisplayNote()
    {
        Console.WriteLine($"Created: {FirstCreate}\nLast Modified: {LastUpdate?.ToString() ?? "Never"}\nTitle: {NoteName}\nContent: {NoteText}");
    }
}