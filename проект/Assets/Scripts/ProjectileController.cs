using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D info)
    {
        EnemiesControllerBase enemy = info.GetComponent<EnemiesControllerBase>();
        if (enemy != null)
            enemy.TakeDamage(_damage, DamageType.Projectile);
        Destroy(gameObject);
    }
}