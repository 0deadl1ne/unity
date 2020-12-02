﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Movement_Controller))]
public class PC_InputController : MonoBehaviour
{
    Movement_Controller _playerMovement;
    DateTime _strikeClickTime;


    float _move;
    bool _jump;
    bool _crawling;
    bool _canAtack;


    private void Start()
    {
        _playerMovement = GetComponent<Movement_Controller>();
    }
    void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonUp("Jump"))
        {
            _jump = true;
        }

        _crawling = Input.GetKey(KeyCode.C);

        if (Input.GetKey(KeyCode.E))
            _playerMovement.StartCasting();

        if (Input.GetKey(KeyCode.Mouse0))
            _playerMovement.StartAttack();
        if (!IsPointerOverUI())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _strikeClickTime = DateTime.Now;
                _canAtack = true;
            }
            
        }

        




    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_move, _jump, _crawling);
        _jump = false;
    }
    private bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
}