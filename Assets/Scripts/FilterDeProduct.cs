using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterDeProduct : MonoBehaviour
{
    public GameObject ButtonParent;
    public Transform Dropdown;
    public RectTransform ScrollPanel;
    public Dropdown D;
    public string DropdownText;
    public int ItemSpace;

    // Start is called before the first frame update
    void Start()
    {
        ActivateAll();
        D.onValueChanged.AddListener(delegate {
            DropDownInput();
         });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateAll()
    {
        for (int i = 0; i < ButtonParent.transform.childCount; i++)
        {
            var child = ButtonParent.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(true);
        }

        SetScrolldownPanelSize(ButtonParent.transform.childCount * ItemSpace);
    }

    void DeactivateAll()
    {
        for (int i = 0; i < ButtonParent.transform.childCount; i++)
        {
            var child = ButtonParent.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }

    void ActivateByTag(string tag)
    {
        GameObject[] Tagged = GameObject.FindGameObjectsWithTag(tag);
        DeactivateAll();

        foreach (GameObject Product in Tagged)
        {
            Product.SetActive(true);
        }

        SetScrolldownPanelSize(Tagged.Length * ItemSpace);
    }

    void DropDownInput()
    {
        int Index = Dropdown.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> Options = Dropdown.GetComponent<Dropdown>().options;
        ActivateAll();
        DropdownText = Options[Index].text;

        if (Index != 0)
            ActivateByTag(DropdownText);
    }

    void SetScrolldownPanelSize(float bottom)
    {
        ScrollPanel.offsetMax = new Vector2(ScrollPanel.offsetMax.x, 0);
        ScrollPanel.offsetMin = new Vector2(ScrollPanel.offsetMin.x, bottom);
    }
}
