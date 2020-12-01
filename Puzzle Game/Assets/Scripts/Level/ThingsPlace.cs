using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsPlace : MonoBehaviour
{

    ThingsFactory originFactory;
    public ThingsFactory OriginFactory
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
