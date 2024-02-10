using UnityEngine;

public class StageData
{
    public int StageNumber = 1;

    [Header("Map")]
    public float Frequency = 4f;
    public float MoveSpeed = 0f;

    [Header("Obstacle")]
    public float SpawnInterval = 10f;
    public int SpawnCount = 3;

    public void StageUp()
    {
        StageNumber++;

        Frequency += 0.02f;
        MoveSpeed += 0.025f;
        SpawnInterval -= 0.5f;

        // 20 스테이지 마다
        if ((StageNumber % 20) == 0)
        {
            SpawnCount++;
        }
    }

}
