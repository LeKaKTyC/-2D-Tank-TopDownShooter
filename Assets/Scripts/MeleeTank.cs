using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int _damage = 5;
    private Transform _target; // Transform = Class = (ref) instead of Vector3 = struct = value
    private float _hitCooldown = 1f;
    private float _timer;


    private Player _player;

    

    protected override void Start() // overriding base start method in Tank class and launching it in overrided Start()
    {
        base.Start();
        ////_target = GameObject.FindGameObjectWithTag("Player").transform;
        //_target = GameObject.FindAnyObjectByType<Player>().transform;
        _player = Player.Instance;
        _target = _player.transform;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ( collision.gameObject.GetComponent<Player>() != null && _timer <=0 )
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
            _timer = _hitCooldown;
        }                                                                                                                                           
    }

    

    private void Update()
    {
        if ( _timer < 0 ) 
        {
            Move();
            SetAngle(_target.position);
        }
        else
        {
            _timer -= Time.deltaTime;
        }
        
    }
}
