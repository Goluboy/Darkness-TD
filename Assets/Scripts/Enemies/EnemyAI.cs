using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LevelConditions _levelConditions;
    private NavMeshAgent _agent;
    private EnemyController _controller;
    private Enemy _enemy;

    private void OnEnable()
    {
        GlobalEventManager.OnLevelEnd.AddListener(LevelEnd);
    }

    private void LevelEnd(bool isWin)
    {
        if (_agent.isActiveAndEnabled)
            _agent.isStopped = true;
    }

    private void Awake()
    {
        _controller = FindObjectOfType<EnemyController>();
        _agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _enemy.EnemySettings.Speed;

        _agent.Warp(_controller.EnemySpawner.transform.position);
        _agent.SetDestination(_controller.EnemySpawner.DestinationPoint.position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _agent.destination) < _agent.stoppingDistance )
        {
            GlobalEventManager.SendOnEnemyReachedEnd(_enemy);
            _enemy.SetAlive(false);
        }
    }
}
