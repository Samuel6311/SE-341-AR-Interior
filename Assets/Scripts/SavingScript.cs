using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Runtime.Serialization;
using System.Text;
using UnityEditor;

[System.Serializable]
public class SavingScript : MonoBehaviour
{
    //not all variables are accounted for yet
    public GameObject ToBeSaved;
    public Text SaveSlot;
    public Text LoadSlot;
    public InputField iField;
    public Text LoadConfirm;

    //a variable for the file location reserved for the vile location assigned to this specific button

    public void SaveToSlot(int slot)
    {


        string path = "";
        if (slot == 1)
            path = "Assets/Resources/Prefabs/Slot1.prefab";
        else if (slot == 2)
            path = "Assets/Resources/Prefabs/Slot2.prefab";
        else if (slot == 3)
            path = "Assets/Resources/Prefabs/Slot3.prefab";
        else if (slot == 4)
            path = "Assets/Resources/Prefabs/Slot4.prefab";
        else if (slot == 5)
            path = "Assets/Resources/Prefabs/Slot5.prefab";
        else if (slot == 6)
            path = "Assets/Resources/Prefabs/Slot6.prefab";

        bool outStringSucess;
        PrefabUtility.SaveAsPrefabAsset(ToBeSaved, path, out outStringSucess);
        Debug.Log(outStringSucess);

        //if (ToBeSaved != null)
        //Debug.Log("Hello There");

        //int OpID = ToBeSaved.GetInstanceID();
        //Debug.Log(a);
        //ObID = new ObjectIdentifier();
        //SLUtil = new SaveLoadUtility();
        // SceneObject SOToBeSaved = SLUtil.PackGameObject(ToBeSaved, ObID);
        // SaveLoad.SaveGameObject(SOToBeSaved, Application.persistentDataPath + "/", "Save" + slot + "FurnitureParent");

        //PrefabUtility.SaveAsPrefabAsset(ToBeSaved, path);


        /*BinaryFormatter Formatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/" + SaveSlot.GetComponent<Text>().text + ".prefab");
        string path = Application.persistentDataPath + "/" + SaveSlot.GetComponent<Text>().text + ".prefab";
        FileStream stream = new FileStream(path, FileMode.Create);

        Formatter.Serialize(stream, ToBeSaved.GetComponent<Transform>());
        stream.Close();*/


        /*DataContractSerializer bf = new DataContractSerializer(ToBeSaved.GetType());
        MemoryStream stream = new MemoryStream();

        //Serialize the file
        bf.WriteObject(stream, ToBeSaved);
        stream.Seek(0, SeekOrigin.Begin);

        //Save to disk
        file.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);

        // Close the file to prevent any corruptions
        file.Close();

        string result = XElement.Parse(Encoding.ASCII.GetString(stream.GetBuffer()).Replace("\0", "")).ToString();*/
    }

    public void SetSlotText()
    {
        SaveSlot.GetComponent<Text>().text = iField.text; //change the text of the button
        LoadSlot.GetComponent<Text>().text = iField.text; //change the text of the button
        ResetText();
    }

    public void ResetText()
    {
        iField.text = "";
    }

    public void LoadFromSlot(string slot)
    {
        //ToBeSaved = null;
        foreach (Transform child in ToBeSaved.transform)
            GameObject.Destroy(child.gameObject);

        string directory = "";
        if (slot == "1")
            directory = "Prefabs/Slot1";
        else if (slot == "2")
            directory = "Prefabs/Slot2";
        else if (slot == "3")
            directory = "Prefabs/Slot3";
        else if (slot == "4")
            directory = "Prefabs/Slot4";
        else if (slot == "5")
            directory = "Prefabs/Slot5";
        else if (slot == "6")
            directory = "Prefabs/Slot6";

        //path = "Assets/Resources/Prefabs/Slot1.prefab";
        var ToBeLoaded = Resources.Load(directory) as GameObject;

        GameObject ChildObject = Instantiate(ToBeLoaded) as GameObject;
        //ChildObject.transform.parent = ToBeSaved.transform.parent;
        for (int i = ChildObject.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = ChildObject.transform.GetChild(i);
            Debug.Log("moving object: " + child.name);
            child.SetParent(ToBeSaved.transform, false);
        }
        Destroy(ChildObject);


        //string path = Application.persistentDataPath + "/" + LoadSlot.GetComponent<Text>().text + ".prefab";
        /*BinaryFormatter Formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);



        //ToBeSaved = Formatter.Deserialize(stream) as Transform;

        stream.Close();

        foreach (Transform child in ToBeSaved.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        ObID = new ObjectIdentifier();
        SLUtil = new SaveLoadUtility();
        SceneObject SOToBeLoaded = SaveLoad.LoadGameObject("Save" + slot + "FurnitureParent", Application.persistentDataPath + "/");
        SLUtil.UnpackGameObject(SOToBeLoaded, ToBeSaved);*/
    }

    public void SetConfirmText()
    {
        LoadConfirm.GetComponent<Text>().text = "Are you sure you would like to load " + LoadSlot.GetComponent<Text>().text + "?";
    }
}
