using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))] // automaticaly adds Rb2D to object if component is missing
public abstract class Tank : MonoBehaviour
{
    [Header("Общие характеристики")]
    [SerializeField] private int _maxHealth = 30;
    [SerializeField] protected float _movementSpeed = 3f;
    [SerializeField] protected float _angleOffset = 90f;
    [SerializeField] protected float _rotationSpeed = 20f;
    [SerializeField] private int _points;
    protected Rigidbody2D _rigidbody;
    protected int _currentHealth;
    protected UI _ui;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    public virtual void TakeDamage (int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Stats.Score += _points;
            _ui.UpdateLvlAndScore();
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg; // atan ?
        Quaternion angle = Quaternion.Euler(0f,0f,angleZ + _angleOffset); // quaternion.euler ?
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed); // quaternion.lerp ?
    }
}

