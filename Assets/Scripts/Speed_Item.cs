using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Item : MonoBehaviour
{
  
    [SerializeField] private int _speedPlus;

  

    private void OnTriggerEnter2D(Collider2D info)
    {
        info.GetComponent<Movement_Controller>().SpeedMore(_speedPlus);
       
        gameObject.SetActive(false);
    }
}
