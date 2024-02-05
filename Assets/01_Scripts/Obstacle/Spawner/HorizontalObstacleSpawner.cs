using UnityEngine;

public class HorizontalObstacleSpawner : ObstaclSpawner
{
    protected override void SetRandomPosition()
    {
        randomPosition.x = Random.Range(spawnRangeMin, spawnRangeMax + 1);
        randomPosition.y = transform.position.y;
        randomPosition.z = 0;
    }
}
