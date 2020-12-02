using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Buble_Damage_Dealler : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeDelay;
    private Player_Controller _player;
    private DateTime _lastincounter;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if ((DateTime.Now - _lastincounter).TotalSeconds < 0.1f)
            return;

        _lastincounter = DateTime.Now;

        _player = info.GetComponent<Player_Controller>();

        if (_player != null)
        {
            _player.TakeTamage(_damage);
        }


    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if (_player == info.GetComponent<Player_Controller>())
            _player = null;
    }

    private void Update()
    {
        if (_player != null && (DateTime.Now - _lastincounter).TotalSeconds > _timeDelay)
        {
            _player.TakeTamage(_damage);
            _lastincounter = DateTime.Now;
        }
    }
}
