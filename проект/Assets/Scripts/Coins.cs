using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private ServiceManager _serviceManager;
 


    void Start()
    {

      
        _serviceManager = ServiceManager.Instanse;

    }


    private void OnTriggerEnter2D(Collider2D info)
    {
       
        _serviceManager.Score();
        Destroy(gameObject);
        
       
       
    }

   
}
