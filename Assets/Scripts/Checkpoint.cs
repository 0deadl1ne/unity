using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private AudioSource _audioSourceCh;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        _audioSourceCh = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ServiceManager.Instanse.Checkpoint(gameObject);
        animator.SetBool("Fire", true);
        _audioSourceCh.enabled = true;
  



    }
}