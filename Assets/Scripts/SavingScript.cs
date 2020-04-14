using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SavingScript : MonoBehaviour
{
    //not all variables are accounted for yet
    public GameObject SaveSlot;
    public InputField iField;

    //a variable for the file location reserved for the vile location assigned to this specific button

    public void SaveToSlot()
    {
        //insert code that will perform the saving operation, may need another method as well

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
