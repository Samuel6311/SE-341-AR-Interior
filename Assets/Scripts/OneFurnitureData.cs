using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class OneFurnitureData
{
    public Vector3 locationData;
    public Quaternion rotationData;
    public Vector3 scaleData;
    public MeshRenderer meshData;


    public OneFurnitureData(Transform trans, MeshRenderer mesh)
    {
        locationData = trans.localPosition;
        rotationData = trans.localRotation;
        scaleData = trans.localScale;
        meshData = mesh;

        //if (hasChildren(trans, mesh))
    }

    /*public void hasChildren(Transform trans, MeshRenderer mesh){
        //while trans.GetComponentsInChildren<GameObject>());
        
    }*/


}
