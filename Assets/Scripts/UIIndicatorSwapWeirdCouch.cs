using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIndicatorSwapWeirdCouch : MonoBehaviour
{
    public GameObject ColorButton;
    public GameObject ColorButton1;
    public GameObject ColorButton2;
    public GameObject ColorButton3;
    public Material material;
    public Material material1;
    public Material material2;
    public Material material3;

    /*public void Awake()
    {
        GameObject ColorButton = GameObject.Find("Canvas/SelectionInfo/ColorSelection/ColorButton");
        GameObject ColorButton1 = GameObject.Find("Canvas/SelectionInfo/ColorSelection/ColorButton1");
        GameObject ColorButton2 = GameObject.Find("Canvas/SelectionInfo/ColorSelection/ColorButton2");
        GameObject ColorButton3 = GameObject.Find("Canvas/SelectionInfo/ColorSelection/ColorButton3");
    }*/




    //Function to take 4 game objects and change the material they have to show in the UI
    public void setUIMaterial()
    {


        ColorButton.GetComponent<Image>().material = material;
        ColorButton1.GetComponent<Image>().material = material1;
        ColorButton2.GetComponent<Image>().material = material2;
        ColorButton3.GetComponent<Image>().material = material3;

    }
}
