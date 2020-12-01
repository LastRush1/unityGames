using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    bool interactive = true;

    bool use = false;

    public bool Use
    {
        get { return use; }
    }

    public bool Interactive
    {
        get { return interactive; }
    }

    public void InteractiveOff()
    {
        interactive = false;
    }



    public void UnUse()
    {
        use = false;
    }

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

    private void OnMouseDown()
    {
        if (interactive)
        {
            use = true;
            Debug.Log("Попал");
        }
    }
}
