using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySettings _enemySettings;

    public EnemySettings EnemySettings => _enemySettings;

    private Animator _animator;
    private CircleCollider2D _circleCollider;
    private NavMeshAgent _navMeshAgent;
    private bool _isAlive = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _isAlive = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetAlive(bool isKilled)
    {
        _animator.SetBool("IsDeath", true);
        _circleCollider.enabled = false;
        _navMeshAgent.enabled = false;
        Invoke("Death", 1.0f);
        if (_isAlive && isKilled)
        {
            _isAlive = false;
            GlobalEventManager.SendOnEnemyKilled(this);
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
