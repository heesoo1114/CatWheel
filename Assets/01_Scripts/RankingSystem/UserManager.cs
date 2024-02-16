using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class UserManager : MonoSingleton<UserManager>
{
    private DatabaseReference rootReference;

    private string userType = "UserData";

    public List<UserData> UserDatas { get; private set; } = new ();
    public UserData myData { get; private set; }
    public bool IsLoaded { get; private set; }

    public override void Init()
    {
        rootReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void UpdateUser(string name, int score)
    {
        // ������ ��ȯ
        UserData user = new(name, score);
        string json = JsonUtility.ToJson(user);

        // ���۷��� ���� �� ������ ����
        DatabaseReference reference = rootReference.Child(userType);
        reference.Child(name).SetRawJsonValueAsync(json);

        // ����
        // reference.Child(name).RemoveValueAsync();
    }

    public void ReadUser()
    {
        IsLoaded = false;
        UserDatas.Clear();

        // ���� ���۷��� ����
        DatabaseReference reference = rootReference.Child(userType);

        // ������ Score ���� �������� ���� �� ��ȸ
        reference.OrderByChild("Score").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("read fail");
                return;
            }

            // DataSnapShot: ��ȸ�� �����͸� �����ϴ� ����
            DataSnapshot snapshot = task.Result;

            foreach (DataSnapshot data in snapshot.Children)
            {
                string name = data.Child("Name").Value.ToString();
                int score = int.Parse(data.Child("Score").Value.ToString());

                UserData userData = new UserData(name, score);
                UserDatas.Add(userData);
            }

            IsLoaded = true;
        });
    }
}
