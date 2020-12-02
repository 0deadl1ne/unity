using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
   private ServiceManager _serviceManager;
    [SerializeField] private int _maxHP;
    private int _currentHP;

    [SerializeField] Slider _HPslider;

    Movement_Controller _playerMovement;
    public static Player_Controller Instanse;

    Vector2 _startPosition;
    private bool _canBeDamaged = true;

    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        _playerMovement = GetComponent<Movement_Controller>();
        _playerMovement.OnGetHurt += OnGetHurt;
        _HPslider.maxValue = _maxHP;
        _HPslider.value = _maxHP;
        _currentHP = _maxHP;
        _startPosition = transform.position;
        _serviceManager = ServiceManager.Instanse;
        
    }

    
    public void TakeTamage(int damage, DamageType type = DamageType.Casual, Transform enemy = null)
        
    {
       
        if (!_canBeDamaged)
            return;

        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            OnDeath();
        }

        switch(type)
        {
            case DamageType.PowerStrike:
                _playerMovement.GetHurt(enemy.position);
                break;
        }

        _HPslider.value = _currentHP;


    }

    public void RestoreHP(int hp)
    {
        _currentHP += hp;

        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }


        _HPslider.value = _currentHP;

    }

     public void CheckpointHP()
    {
        _currentHP = _maxHP;
    }
 

    private void OnGetHurt(bool caBeDamaged)
    {
        _canBeDamaged = caBeDamaged;
    }

    public void OnDeath()
    {
   
        _serviceManager.Respown(gameObject);
        
        _playerMovement.ToDefaultSpeed();
        _currentHP = _maxHP;
        
    }
}