using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstaclSpawner : Observer<GameController>
{
    [SerializeField] private string spawnObjectPoolID;
    [SerializeField] private bool isOnce = false;

    [Header("Spawn")]
    [SerializeField] private float spawnInterval;
    [SerializeField] protected float spawnRangeMax;
    [SerializeField] protected float spawnRangeMin;

    [SerializeField] protected int spawnCount;

    private Coroutine currentCoroutine = null;

    private List<PoolableMono> clones = new ();

    protected Vector3 randomPosition;

    private StageData stageData;

    public sealed override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            SetData();
            StopCurrentSpawnRoop();
            currentCoroutine = StartCoroutine(SpawnRoopCor(isOnce));
        }
        else
        {
            StopCurrentSpawnRoop();
            ClearObject();
        }
    }

    private void Awake()
    {
        SetUp();
    }

    private void Start()
    {
        stageData = GameManager.Instance.StageData;
    }

    private void SetData()
    {
        if (isOnce)
        {
            spawnCount = stageData.SpawnCount;
        }
        else
        {
            spawnInterval = stageData.SpawnInterval;
        }
    }

    protected abstract void SetRandomPosition();

    private void SpawnObject()
    {
        PoolableMono clone = PoolManager.Instance.Pop(spawnObjectPoolID);
        clone.transform.SetParent(transform);
        clone.transform.SetPositionAndRotation(randomPosition, clone.transform.localRotation);

        clones.Add(clone);
    }

    private void ClearObject()
    {
        foreach (var clone in clones)
        {
            PoolManager.Instance.Push(clone);
        }
    }

    private IEnumerator SpawnRoopCor(bool isOnce)
    {
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SetRandomPosition();
                SpawnObject();
            }

            if (isOnce)
            {
                yield break;
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
