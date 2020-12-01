using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasePrefab : MonoBehaviour
{

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

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
