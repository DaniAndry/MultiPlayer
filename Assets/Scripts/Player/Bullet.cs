using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _shootPoint;

    private Vector2 _target;

    public void Init(Transform shootPoint)
    {
        _shootPoint = shootPoint;
    }

    private void Start()
    {
        _target.x = _shootPoint.transform.position.x;
        _target.y = _shootPoint.transform.position.y + 90;
    }

    private void Update()
    {
        transform.Translate(_target * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.TryGetComponent(out Player player))
        {
          player.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
