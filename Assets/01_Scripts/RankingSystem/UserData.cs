public class UserData
{
    public string Name;
    public int Score;

    public UserData(string userName, int score)
    {
        this.Name = userName;
        this.Score = score;
    }

    public void PropetyLog()
    {
        UnityEngine.Debug.Log(Name + " " + Score);
    }
}
