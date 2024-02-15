using System.Collections.Generic;
using System.Collections;
using Firebase.Database;
using UnityEngine;
using Firebase;

public class FirebaseManager : MonoSingleton<FirebaseManager>
{
    private DatabaseReference databaseReference;

    public override void Init()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // databaseReference.Child("UserData").RemoveValueAsync();
        UpdateUser("UserData", "Heesoo", GameManager.Instance.StageData.StageNumber);
    }

    private void UpdateUser(string userId, string name, int score)
    {
        UserData user = new (name, score);
        string json = JsonUtility.ToJson(user);
        databaseReference.Child(userId).SetRawJsonValueAsync(json);
    }
}
