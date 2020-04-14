using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEditor : MonoBehaviour
{
    public GameObject MaterialGroup1Parent;
    public GameObject MaterialGroup2Parent;
    public Material[] Group1Material = new Material[4];
    public Material[] Group2Material = new Material[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Preconditions: Parent of Objects to apply material to, New Material to be applied
    public void SetGroupMaterial(GameObject Parent, Material NewMaterial)
    {
        Transform[] children;
        children = Parent.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            child.GetComponent<MeshRenderer>().material = NewMaterial;
        }
    }
}
