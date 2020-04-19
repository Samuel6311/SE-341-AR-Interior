using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[System.Serializable]
public class SavingScript
{
    //not all variables are accounted for yet
    public FurniturePlacer ToBeSaved;
    private List<GameObject> Furniture;
    public GameObject SaveSlot;
    public InputField iField;

    //a variable for the file location reserved for the vile location assigned to this specific button

    public void SaveToSlot()
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveslot.models";
        FileStream stream = new FileStream(path, FileMode.Create);

        Furniture = ToBeSaved.GetFurniture();

        Formatter.Serialize(stream, ToBeSaved.GetFurniture());
        stream.Close();

        //change the text of the button
        SaveSlot.GetComponent<Text>().text = iField.text;
        ResetText();
    }

    public void ResetText()
    {
        iField.text = "";
    }

    public void ErasePreviousData()
    {
        //if there is already something saved here, this method will erase it so that it can be saved over
    }
}
