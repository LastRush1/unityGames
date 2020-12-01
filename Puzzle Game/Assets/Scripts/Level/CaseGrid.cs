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

    public bool empty = true;

    public void SetNumber(int gridPlaceList)
    {
        if(!spawn)
        {
            number = gridPlaceList;
        }
    }

    CaseFactory originFactory;
    public CaseFactory OriginFactory
    {
        get => originFactory;
        set
        {
            Debug.Assert(originFactory == null, "Redefined origin factory!");
            originFactory = value;
        }
    }

    public void Initialize()
    {

    }
}
