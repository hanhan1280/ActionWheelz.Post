using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpooling : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    // Start is called before the first frame update
    public List<Pool> pools;
    public static objectpooling Instance;

    #region Singleton
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obstacle = Instantiate(pool.prefab);
                obstacle.SetActive(false);
                objectPool.Enqueue(obstacle);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // Update is called once per frame
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objecttoSpawn = poolDictionary[tag].Dequeue();
        objecttoSpawn.SetActive(true);
        objecttoSpawn.transform.position = position;

        poolDictionary[tag].Enqueue(objecttoSpawn);

        return objecttoSpawn;
    }
}
