using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject MenuObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenMenu()
    {
        MenuObject.SetActive(true);
    }

    void CloseMenu()
    {
        MenuObject.SetActive(false);
    }
}
