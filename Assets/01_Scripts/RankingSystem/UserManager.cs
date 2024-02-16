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
        // 데이터 변환
        UserData user = new(name, score);
        string json = JsonUtility.ToJson(user);

        // 레퍼런스 선언 및 데이터 저장
        DatabaseReference reference = rootReference.Child(userType);
        reference.Child(name).SetRawJsonValueAsync(json);

        // 삭제
        // reference.Child(name).RemoveValueAsync();
    }

    public void ReadUser()
    {
        IsLoaded = false;
        UserDatas.Clear();

        // 지역 레퍼런스 선언
        DatabaseReference reference = rootReference.Child(userType);

        // 데이터 Score 기준 오름차순 정렬 후 조회
        reference.OrderByChild("Score").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("read fail");
                return;
            }

            // DataSnapShot: 조회한 데이터를 저장하는 단위
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
