using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank // right click -> fast solutions -> initialize abstract members of parent class !!!
{
    private float _timer;

    public static Player Instance;
    [Header("Звук Хила")]
    [SerializeField] protected AudioSource _healthPickup;


    public void Awake()
    {
        Instance = this;
    }
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _ui.UpdateHP(_currentHealth);
        if (_currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected override void Move()
    {
        //OLD VER 

        //Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //_rigidbody.velocity = direction.normalized * _movementSpeed; // normalize is clamping direction to 1.0 if we moving diagonally to prevent speed bonus

        // Better (appropriate) tank movement 
        transform.Translate(Vector2.down * Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime); // Vector2.down cus sprite directtion
        transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MedKitCrate") 
        {
            _currentHealth += 10;
            _healthPickup.Play();
            Debug.Log("MedKitIsUp");
            collision.gameObject.SetActive(false);
        }
    }


    private void Update()
    {
        
        Move();
        //SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition)); // point OnScreen to point InGame
        //if (_timer <= 0)
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        Shoot();
        //        _timer = _reloadSpeed;
        //    }   
        //} 
        //else
        //{
        //    _timer -= Time.deltaTime;
        //}
        
    }


}
