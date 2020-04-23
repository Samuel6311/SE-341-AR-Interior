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

    //Preconditions: index of material to be applied
    public void SetGroupMaterial(int index)
    {
        Renderer[] children;
        children = MaterialGroupParent.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = GroupMaterial[index];
            }
            rend.materials = mats;
        }
    }
}
