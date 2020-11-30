using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseGrid : MonoBehaviour
{
    [SerializeField]
    int number;

    bool spawn = false;
    public int Number
    {
        get { return number; }
    }

    public void SetNumber(int gridPlaceList)
    {
        if(!spawn)
        {
            number = gridPlaceList;
        }
    }
}
