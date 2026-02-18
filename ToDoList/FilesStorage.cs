using System.Text.Json;

namespace ToDoList;

public class FilesStorage
{
    static readonly string _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoList");//Сам ставить слеші залежно від ОС
   

    public FilesStorage()
    {
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }if(!File.Exists(_directoryPath + @"\ToDoList.json"))
        {
            File.Create(_directoryPath + @"\ToDoList.json").Close();
        } 
    }

    /// <summary>
    /// method to load and return collection
    /// </summary>
    /// <returns></returns>
    public List<Note> GetNotes()
    {
        string data = File.ReadAllText(_directoryPath + @"\ToDoList.json");
        if (!string.IsNullOrEmpty(data) && !string.IsNullOrWhiteSpace(data))
        {
            try
            {
                return JsonSerializer.Deserialize<List<Note>>(data) ?? new List<Note>();
            }
            catch (JsonException)
            {
               return  new List<Note>();
            }
            catch (Exception)
            {
                return new List<Note>();
            }
        }
            return  new List<Note>();
    }
    
    
    /// <summary>
    /// method for data persistence
    /// </summary>
    /// <param name="list"></param>
    public void SaveNotes(List<Note> list)
    {
        string data = JsonSerializer.Serialize(list);
        File.WriteAllText(_directoryPath + @"\ToDoList.json", data);
    }
}