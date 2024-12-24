using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledBulletObjects;
    public List<GameObject> pooledLevelObjects;
    public GameObject bulletObjectToPool;
    public GameObject[] levelObjectToPool;
    public int bulletAmountToPool;
    public int levelAmountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        pooledBulletObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < bulletAmountToPool; i++)
        {
            temp = Instantiate(bulletObjectToPool);
            temp.SetActive(false);
            pooledBulletObjects.Add(temp);
        }

        pooledLevelObjects = new List<GameObject>();
        GameObject temp2;
        for (int i = 0; i < levelAmountToPool; i++)
        {
            temp2 = Instantiate(levelObjectToPool[i]);
            temp2.SetActive(false);
            pooledLevelObjects.Add(temp2);
        }
    }

    public GameObject GetPooledBulletObject()
    {
        for (int i = 0; i < bulletAmountToPool; i++)
        {
            if (!pooledBulletObjects[i].activeInHierarchy)
            {
                return pooledBulletObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledLevelObject()
    {
        for (int i = 0; i < levelAmountToPool; i++)
        {
            if (!pooledLevelObjects[i].activeInHierarchy)
            {
                return pooledLevelObjects[i];
            }
        }
        return null;
    }
}
