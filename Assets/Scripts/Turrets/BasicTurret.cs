using Unity.VisualScripting;
using UnityEngine;

public class BasicTurret : Turret
{    
    protected override void Shoot()
    {
        GameObject bulletObject = Instantiate(_turretSettings.BulletPrefab, transform.position, Quaternion.identity, transform);

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        bullet.Shoot(_nearestEnemy, transform.position, _turretSettings.BulletSpeed, _turretSettings.BulletDamage);
    }
}
