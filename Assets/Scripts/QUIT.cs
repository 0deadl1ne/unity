using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QUIT : MonoBehaviour
{
    [SerializeField] protected Button _quit;
    protected ServiceManager _serviceManager;
    protected virtual void Start()
    {
       
        _quit.onClick.AddListener(OnQuitClicked);
        
    }

    protected virtual void OnDestroy()
    {
        _quit.onClick.RemoveListener(OnQuitClicked);
       
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    private void OnQuitClicked()
    {
        Quit();
       
    }
}

