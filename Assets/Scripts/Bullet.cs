using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] TargetManager _manager;
    [SerializeField] float _speed;
    public bool IsMooving { get; set; } = false;  
    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (IsMooving)
            transform.position = Vector2.MoveTowards(transform.position, _manager.Leader.transform.position, _speed * Time.deltaTime);
    }
}
