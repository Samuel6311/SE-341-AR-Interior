using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEditor : MonoBehaviour
{
    public GameObject MaterialGroupParent;
    public Material[] GroupMaterial = new Material[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Preconditions: Parent of Objects to apply material to, New Material to be applied
    public void SetGroupMaterial(int index)
    {
        Transform[] children;
        children = MaterialGroupParent.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            child.GetComponent<MeshRenderer>().material = GroupMaterial[index];
        }
    }
}
