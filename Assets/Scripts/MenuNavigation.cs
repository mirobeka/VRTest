using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject ui = null;

    private GameObject[] menuItems = null;
    private int childCount = 0;

    void Awake(){
        childCount = ui.transform.childCount;
        menuItems = new GameObject[childCount];

        for ( int i=0; i < childCount; i++ )
        {
            menuItems[i] = ui.transform.GetChild(i).gameObject;
        }
    }

    void Start()
    {
        GoTo(0);
    }

    public void GoTo(int index)
    {
        for (int i = 0; i < childCount; i++)
        {
            menuItems[i].SetActive( i == index);
        }
    }
}
