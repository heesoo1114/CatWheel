using UnityEngine;

public class StageData
{
    public int StageNumber = 1;

    [Header("Map")]
    public float Frequency = 2.7f;
    public float MoveSpeed = 0f;

    [Header("Obstacle")]
    public float SpawnInterval = 10f;
    public int SpawnCount = 3;

    public void StageUp()
    {
        StageNumber++;
        Debug.Log(StageNumber);

        Frequency += 0.23f;
        MoveSpeed += 0.025f;
        SpawnInterval -= 0.05f;

        // 15스테이지 마다
        if ((StageNumber % 15) == 0)
        {
            SpawnCount++;
        }
    }

}
