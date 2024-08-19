using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : ShootableTank // it should be an Interface ..... or GunAndWheelsRotation 
{
    private float _timer;
    protected override void Move()
    {
        throw new System.NotImplementedException();
    }




    // Update is called once per frame
    void Update()
    {
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (_timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                _timer = _reloadSpeed;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
