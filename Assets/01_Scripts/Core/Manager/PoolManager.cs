using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private PoolingListSO poolingListSO;

    private Dictionary<string, Pool<PoolableMono>> pools = new Dictionary<string, Pool<PoolableMono>>();

    public override void Init()
    {
        CreatePool();    
    }

    private void CreatePool()
    {
        var poolingList = poolingListSO.PoolList;
        foreach (var pair in poolingList)
        {
            var pool = new Pool<PoolableMono>(pair.Prefab, transform, pair.Count);
            pools.Add(pair.Prefab.name, pool);
        }
    }

    public PoolableMono Pop(string prefabName)
    {
        if (false == pools.ContainsKey(prefabName))
        {
            Debug.LogError($"Prefab does not exist on pool : {prefabName}");
            return null;
        }

        PoolableMono item = pools[prefabName].Pop();
        return item;
    }

    public void Push(PoolableMono prefab)
    {
        pools[prefab.name].Push(prefab);
    }
}