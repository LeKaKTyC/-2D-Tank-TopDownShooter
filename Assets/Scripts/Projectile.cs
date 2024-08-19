using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private string _myTag = ""; // to except friendlyfire logic further on

    [SerializeField] private float despawnTimer = 3f;
    [SerializeField] private float reactivate = 3f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tank>() != null && collision.gameObject.tag != _myTag)
        {
            collision.gameObject.GetComponent<Tank>().TakeDamage(_damage);
            //Destroy(gameObject); 
            gameObject.SetActive(false); // using ObjPool is way better for performance
        }
    }

    private void FixedUpdate()
    {
        
        if (despawnTimer < 0)
        {
            gameObject.SetActive(false);
            despawnTimer = reactivate;
        }
        else
        {
            despawnTimer -= Time.deltaTime;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime); // using Vector3.down cus of PREFAB ICON !!! 
    }
}
