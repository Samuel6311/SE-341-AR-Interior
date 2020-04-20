using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[System.Serializable]
public class SavingScript : MonoBehaviour
{
    //not all variables are accounted for yet
    public FurniturePlacer ToBeSaved;
    private List<GameObject> Furniture;
    public Text SaveSlot;
    public Text LoadSlot;
    public InputField iField;
    public Text LoadConfirm;

    //a variable for the file location reserved for the vile location assigned to this specific button

    public void SaveToSlot()
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + SaveSlot.GetComponent<Text>().text + ".models";
        FileStream stream = new FileStream(path, FileMode.Create);

        Furniture = ToBeSaved.GetFurniture();

        Formatter.Serialize(stream, ToBeSaved.GetFurniture());
        stream.Close();
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

    public void LoadFromSlot()
    {
        string path = Application.persistentDataPath + "/" + SaveSlot.GetComponent<Text>().text + ".models";
        BinaryFormatter Formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        List<GameObject> LoadedList = Formatter.Deserialize(stream) as List<GameObject>;
        stream.Close();

        ToBeSaved.SetFurniture(LoadedList);
    }

    public void SetConfirmText()
    {
        LoadConfirm.GetComponent<Text>().text = "Are you sure you would like to load" + LoadSlot.GetComponent<Text>().text + "?";
    }
}
