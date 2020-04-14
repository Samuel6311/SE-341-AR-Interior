using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject MenuObject;
    public GameObject MenuObject2;
    public GameObject MenuObject3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {

        MenuObject.SetActive(true);
           
    }

    public void CloseMenu()
    {
        MenuObject.SetActive(false);
        if (MenuObject2 != null)
        {
            MenuObject2.SetActive(false);
            if (MenuObject3 != null)
                MenuObject3.SetActive(false);
        }
    }
}
