using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
// adding another abstract class to a parent hierarchy to separate meeleetanks from shootable
{
    [Header("Стрельба")]
    [SerializeField] private string _projectileTag;
    //[SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootingPoint; // using Transform class instead of Vector3 struction cus of data (ref, value) type difference
    [SerializeField] protected float _reloadSpeed = 0.5f; // protected cus we need that in child(inheritate) classes // 1f = 1sec
    private ObjectPool _objPooler;

    protected override void Start()
    {
        base.Start();
        _objPooler = ObjectPool.Instance;
    }

protected void Shoot()
    {
        //Instantiate(_projectile, _shootingPoint.position, transform.rotation);
        _objPooler.SpawnFromPool(_projectileTag, _shootingPoint.position, transform.rotation);
    }
}
    


