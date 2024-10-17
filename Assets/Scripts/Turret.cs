using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] private TargetManager _manager;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _ticksToShoot;
    [SerializeField] private Transform _parent;
    private int _count;

    private void FaceTheLeader()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _manager.Leader.transform.position - transform.position);
    }

    private void Shoot()
    {
        var clone = Instantiate(_bullet, _parent, true);
        clone.IsMooving = true;
        clone.gameObject.SetActive(true);
    }

    void Update()
    {
        FaceTheLeader();
        if (_count++ > _ticksToShoot)
        {
            _count = 0;
            Shoot();
        }
    }
}
