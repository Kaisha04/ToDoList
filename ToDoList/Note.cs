using System.Text.Json.Serialization;

namespace ToDoList;

public class Note
{
    [JsonInclude] //Attribute to include private property in JSON serialization
    public DateTime FirstCreate { get; private set; }
    [JsonInclude]
    public DateTime? LastUpdate { get; private set; }
    [JsonInclude]
    public string? Title { get; private set; }
    [JsonInclude]
    public string? Content { get; private set; }
    
    public Note(){}

    /// <summary>
    /// Constructor for create a new note
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
    public Note(string title, string content)
    {
        FirstCreate = DateTime.Now;
        Title = title;
        Content = content;
    }

    public void ChangeName(string newTitle)
    {
        Title = newTitle;
        UpdateNote();
    }
    public void ChangeText(string newContent)
    {
        Content = newContent;
        UpdateNote();
    }

    public void UpdateNote()
    {
        LastUpdate = DateTime.Now;
    }
    public override string ToString()
    {
        return $"Last Modified: {LastUpdate ?? FirstCreate}\nTitle: {Title}";
    }

    public void DisplayNote()
    {
        Console.WriteLine($"Created: {FirstCreate}\nLast Modified: {LastUpdate?.ToString() ?? "Never"}\nTitle: {Title}\nContent: {Content}");
    }
}