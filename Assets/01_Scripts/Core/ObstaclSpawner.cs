using System.Collections;
using UnityEngine;

public abstract class ObstaclSpawner : Observer<GameController>
{
    [SerializeField] private string spawnObjectPoolID;

    [Header("Spawn")]
    [SerializeField] private float spawnInterval;
    [SerializeField] protected float spawnRangeMax;
    [SerializeField] protected float spawnRangeMin;

    [SerializeField] protected int spawnCount;

    private Coroutine currentCoroutine = null;

    protected Vector3 randomPosition; 

    public sealed override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            StopCurrentSpawnRoop();
            currentCoroutine = StartCoroutine(SpawnRoopCor());
        }
        else
        {
            StopCurrentSpawnRoop();
        }
    }

    private void Awake()
    {
        SetUp();
    }

    protected abstract void SetRandomPosition();

    private void SpawnObject()
    {
        PoolableMono clone = PoolManager.Instance.Pop(spawnObjectPoolID);
        clone.transform.SetPositionAndRotation(randomPosition, clone.transform.localRotation);
    }

    private IEnumerator SpawnRoopCor()
    {
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SetRandomPosition();
                SpawnObject();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void StopCurrentSpawnRoop()
    {
        if (null != currentCoroutine)
        {
            StopCoroutine(currentCoroutine);
        }
    }
}
