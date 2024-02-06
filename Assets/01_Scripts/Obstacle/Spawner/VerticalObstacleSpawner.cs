using UnityEngine;

public class VerticalObstacleSpawner : ObstaclSpawner
{
    protected override void SetRandomPosition()
    {
        randomPosition.x = transform.position.x;
        randomPosition.y = Random.Range(spawnRangeMin, spawnRangeMax + 1);
        randomPosition.z = 0;
    }
}
