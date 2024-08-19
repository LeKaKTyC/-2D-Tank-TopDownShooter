using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public string tag;
        public int size;
    }
    public List<Pool> pools; // list of pools (in our case - different bullets)

    public Dictionary<string, Queue<GameObject>> poolDictionary; // queue is our pool, string is a tag which represent exact bullet type

    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject> ();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab); // instantiate a prefab 
                obj.SetActive (false); // imidiately deactivate it 
                objectPool.Enqueue (obj); // adding to a que (pool of certain prefab bullets)
            }
            poolDictionary.Add (pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey (tag))
            return null;
        GameObject gameObjectToSpawn = poolDictionary[tag].Dequeue(); // ejecting first element 

        gameObjectToSpawn.SetActive (true);
        gameObjectToSpawn.transform.position = position;
        gameObjectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue (gameObjectToSpawn);

        return gameObjectToSpawn;
    }
}
