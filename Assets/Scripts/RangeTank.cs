using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTank : ShootableTank
{
    private Transform _target;
    private float _timer;
    [SerializeField] private float _distanceToPlayer = 5f; // max radius where rangetank needs to stop and focus on fire, rather then move

    private Player _player;
    protected override void Start()
    {
        base.Start();
        ////_target = GameObject.FindGameObjectWithTag("Player").transform; // try to NOT use FindTag, cus of easy misspeling right component
        //_target = GameObject.FindAnyObjectByType<Player>().transform; // FindType always better cus error will show if exist
        _player = Player.Instance;
        _target = _player.transform;
    }

    

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) > _distanceToPlayer)
        {
            Move();
        }
        SetAngle(_target.position);
        if (_timer < 0)
        {
            Shoot();
            _timer = _reloadSpeed;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
