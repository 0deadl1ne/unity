using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvEnder : MonoBehaviour
{
    private Animator _caveAnimator;
    public static LvEnder Instanse;
    [SerializeField] private Collider2D _enderCollider;
    private AudioSource _audioSourceLV;
    public void EnderLevelStart ()
    {
        _caveAnimator.SetBool("Start", true);
        _audioSourceLV.enabled = true;
        _enderCollider.enabled = true;
    }

    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        _caveAnimator = GetComponent<Animator>();
        _audioSourceLV = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        
        ServiceManager.Instanse.EndLevel();
    }
}