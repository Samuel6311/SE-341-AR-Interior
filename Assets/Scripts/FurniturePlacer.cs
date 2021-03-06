﻿//Hissamuddin Shaikh
//13831236
//Furniture Placement and Position Controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FurniturePlacer : MonoBehaviour
{
    //Public Variables for Proper Placement and Indication of Placement
    public Transform PlacementIndicator;
    public GameObject SelectionUI;

    //Private Variables to keep track of placed objects
    private List<GameObject> Furniture = new List<GameObject>();
    private GameObject CurrentSelected; 
    
    private Camera Cam;
    public Material mat;

    //UI Variables
    //public GameObject barstoolButton;
    public UIIndicatorSwapBarstool barstoolSwapper;
    public UIIndicatorSwapChest chestSwapper;
    public UIIndicatorSwapClubChair clubChairSwapper;
    public UIIndicatorSwapWeirdCouch weirdCouchSwapper;
    public UIIndicatorSwapCouch couchSwapper;

    void Start()
    {
        Cam = Camera.main;
        SelectionUI.SetActive(false);
        barstoolSwapper = FindObjectOfType(typeof(UIIndicatorSwapBarstool)) as UIIndicatorSwapBarstool;
        //barstoolSwapper = barstoolButton.GetComponent<UIIndicatorSwapBarstool>();
        chestSwapper = FindObjectOfType(typeof(UIIndicatorSwapChest)) as UIIndicatorSwapChest;
        clubChairSwapper = FindObjectOfType(typeof(UIIndicatorSwapClubChair)) as UIIndicatorSwapClubChair;
        weirdCouchSwapper = FindObjectOfType(typeof(UIIndicatorSwapWeirdCouch)) as UIIndicatorSwapWeirdCouch;
        couchSwapper = FindObjectOfType(typeof(UIIndicatorSwapCouch)) as UIIndicatorSwapCouch;

    }

    //Management of Selection and Deselection of Objects, all those that have been placed in the Environment
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            Ray ray = Cam.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider != null && Furniture.Contains(hit.collider.gameObject))
                {
                    if (CurrentSelected != null && hit.collider.gameObject != CurrentSelected)
                    {
                        Select(hit.collider.gameObject);
                    }
                    else if (CurrentSelected == null)
                    {
                        Select(hit.collider.gameObject);
                        //Add reassignment of ui material
                    }
                }
                else
                    Deselect(); 
            }

        }

        if(CurrentSelected != null && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            MoveSelected();
        }
    }
    
    //Furniture to Place a Selected Piece of Furniture into the Environment
    public void PlaceFurniture (GameObject prefab)
    {
        GameObject Obj = Instantiate(prefab, PlacementIndicator.position, Quaternion.identity);
        Furniture.Add(Obj);
        Select(Obj);
        SetParent(Obj);
    }

    //Functions to allow for Selection of an Object, works with Deselect Function to allow for switching between different Objects.
    void Select (GameObject Selected)
    {
        if (CurrentSelected != null)
            ToggleSelectionVisual(CurrentSelected, false);
        CurrentSelected = Selected;
        ToggleSelectionVisual(CurrentSelected, true);
        if (CurrentSelected.tag == "Barstool")
        {
            //Change UI Indicators for Barstool
            //Material yourMaterial = Resources.Load("Wood", typeof(Material)) as Material;
            //ColorButtonA.GetComponent<Image>().material = material1;
            if (barstoolSwapper == null)
            {
                barstoolSwapper = FindObjectOfType(typeof(UIIndicatorSwapBarstool)) as UIIndicatorSwapBarstool;
                barstoolSwapper.setUIMaterial();
            }
            else
                barstoolSwapper.setUIMaterial();
            //SelectionUI.SetActive(true);
            //Debug.Log("Hello: ");

        }
        if (CurrentSelected.tag == "ClubChair")
        {
            //Change UI Indicators for ClubChair
            //changer.setUIMaterial();
            if (clubChairSwapper == null)
            {
                clubChairSwapper = FindObjectOfType(typeof(UIIndicatorSwapClubChair)) as UIIndicatorSwapClubChair;
                clubChairSwapper.setUIMaterial();
            }
            else
                clubChairSwapper.setUIMaterial();
        }
        if (CurrentSelected.tag == "Couch")
        {
            //Change UI Indicators for Couch
            //changer.setUIMaterial();
            if (couchSwapper == null)
            {
                couchSwapper = FindObjectOfType(typeof(UIIndicatorSwapCouch)) as UIIndicatorSwapCouch;
                couchSwapper.setUIMaterial();
            }
            else
                couchSwapper.setUIMaterial();
        }
        if (CurrentSelected.tag == "WeirdCouch")
        {
            //Change UI Indicators for WeirdCouch
            //changer.setUIMaterial();
            if (weirdCouchSwapper == null)
            {
                weirdCouchSwapper = FindObjectOfType(typeof(UIIndicatorSwapWeirdCouch)) as UIIndicatorSwapWeirdCouch;
                weirdCouchSwapper.setUIMaterial();
            }
            else
                weirdCouchSwapper.setUIMaterial();

        }
        if (CurrentSelected.tag == "Chest")
        {
            //Change UI Indicators for Chest
            //changer.setUIMaterial();
            if (chestSwapper == null)
            {
                chestSwapper = FindObjectOfType(typeof(UIIndicatorSwapChest)) as UIIndicatorSwapChest;
                chestSwapper.setUIMaterial();
            }
            else
                chestSwapper.setUIMaterial();
        }
        SelectionUI.SetActive(true);

        
    }

    //Functio to allow for Deselection of an Object, works with Select Function to allow for switching between different Objects.
    void Deselect ()
    {
        if (CurrentSelected != null)
            ToggleSelectionVisual(CurrentSelected, false);

        CurrentSelected = null;
        SelectionUI.SetActive(false); 
    }

    //Put spawned object in to an empty gameobject
    void SetParent(GameObject Selected)
    {
        Transform Parent = GameObject.Find("FurnitureParent").GetComponent<Transform>();
        Selected.GetComponent<Transform>().SetParent(Parent);
    }

    //Function to handle the Visual feedback of Selection and the switching between Select and Deselect.
    void ToggleSelectionVisual (GameObject Obj, bool Toggle)
    {
        Obj.transform.Find("Selected").gameObject.SetActive(Toggle);

    }

    //Function to allow the movement of a placed object in the Environment
    void MoveSelected()
    {
        Vector3 CurrentPosition = Cam.ScreenToViewportPoint(Input.touches[0].position);
        Vector3 PreviousPosition = Cam.ScreenToViewportPoint(Input.touches[0].position - Input.touches[0].deltaPosition);

        Vector3 TouchDirection = CurrentPosition - PreviousPosition;


        Vector3 CameraRight = Cam.transform.right;
        CameraRight.y = 0;
        CameraRight.Normalize();

        Vector3 CameraForward = Cam.transform.forward;
        CameraForward.y = 0;
        CameraForward.Normalize();

        CurrentSelected.transform.position += (CameraRight * TouchDirection.x + CameraForward * TouchDirection.y);



    }

    //Function to allow the scaling of a selected object (Up or Down)
    public void ScaleSelected(float Rate)
    {
        CurrentSelected.transform.localScale += Vector3.one * Rate;
    }

    //Function to allow the rotation of a selected object
    public void RotateSelected (float Rate)
    {
        CurrentSelected.transform.eulerAngles += Vector3.up * Rate;
    }

    //Change the colour of a Selected Object
    public void SetColour (int ButtonNum)
    {
        MaterialEditor Editor = CurrentSelected.GetComponent<MaterialEditor>();

        Editor.SetGroupMaterial(ButtonNum);

        /*
        MeshRenderer[] MeshRenderers = CurrentSelected.GetComponentsInChildren<MeshRenderer>();

        foreach(MeshRenderer MR in MeshRenderers)
        {
            if (MR.gameObject.name == "Selected")
                continue;
            
            MR.material.color = ButtonImage.color;
        }
        */
    }

    //Delete a Selected Object
    public void DeleteSelected()
    {
        Furniture.Remove(CurrentSelected);
        Destroy(CurrentSelected);
        Deselect();
    }
}
