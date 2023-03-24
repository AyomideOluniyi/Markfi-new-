using SQLite;

public class Question
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Category { get; set; }
    public string Difficulty { get; set; }
    public string QuestionText { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public string Option4 { get; set; }
    public string CorrectAnswer { get; set; }
}
