//Hissamuddin Shaikh
//13831236

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager RayManager;
    private GameObject Visualizer;

    void Start ()
    {
        //Get the Necessary Components
        RayManager = FindObjectOfType<ARRaycastManager>();
        Visualizer = transform.GetChild(0).gameObject;

        //Hide the Visual Indicator when Plane not detected
        Visualizer.SetActive(false);
    }
    
    void Update ()
    {
        //Shoot out a Raycast from the Center of the Users Screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //When we hit an AR plane, update the position and rotation of the Visual Marker
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            //If the Visual Marker, was previously disabled, enavle upon detection.
            if(!Visualizer.activeInHierarchy)
                Visualizer.SetActive(true);
        }
    }
}