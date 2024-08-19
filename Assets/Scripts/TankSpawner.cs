using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tankList;
    [SerializeField] private List <Transform> _spawnPoints;
    [SerializeField] private float _tankSpawnTime = 2f;
    //[SerializeField] private string _tankTag;

    //private ObjectPool _objPooler;



    private void Start()
    {
        StartCoroutine(SpawnTank());
        //_objPooler = ObjectPool.Instance;
    }

    IEnumerator SpawnTank () 
    {
        int limit;
        if (Stats.Level > _tankList.Count)
            limit = Stats.Level;
        else
            limit = _tankList.Count;
        while (true)
        {
            //
            Instantiate(_tankList[Random.Range(0, Stats.Level)], _spawnPoints[Random.Range(0,_spawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(_tankSpawnTime);
        }
    }

        
}
