using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WalkingMonster_Controller : EnemiesControllerBase
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _arrowSpeed;
    public override void TakeDamage(int damage, DamageType type = DamageType.Casual, Transform palyer = null)
    {
        if (type != DamageType.Projectile)

            return;

        base.TakeDamage(damage, type, palyer);
    }
  
    public void offHurt()
    {
        _enemyAnimator.SetBool(EnemyState.Hurt.ToString(), false);
    }
}
