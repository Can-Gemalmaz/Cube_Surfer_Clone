using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Transform parentObject;
    [SerializeField] PoolableObject poolableObject;
    [SerializeField] int maxAmountPool;

    List<PoolableObject> _pooledObjects;

    private void Awake()
    {
        _pooledObjects = new List<PoolableObject>();

        for (int i = 0; i < maxAmountPool; i++) 
        {
            AddNewObject();
        }

    }

    private void AddNewObject()
    {
        GameObject newObject = Instantiate(poolableObject.gameObject, parentObject);
        newObject.SetActive(false);
        _pooledObjects.Add(newObject.GetComponent<PoolableObject>());
    }


    public PoolableObject GetPooledObject()
    {
        for (int i = 0; i < maxAmountPool; i++)
        {
            if (!_pooledObjects[i].gameObject.activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        AddNewObject();
        return _pooledObjects[^1];
    }
}
