using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsController : MonoBehaviour
{
    [SerializeField]
    ThingsFactory thingsFactory = default;

    ThingsPlace thingsPlace;

    List<Thing> things = new List<Thing>();

    public Thing takeThing;

    private void Start()
    {
        thingsPlace = thingsFactory.GetBoard();
        for (int i = 0; i < thingsFactory.ThingCount; i++)
        {
            things.Add(thingsFactory.GetThing(i));
            things[things.Count - 1].transform.position = thingsPlace.transform.position;
        }
        //things.Add(thingsFactory.GetThing(0));
        //things[things.Count - 1].transform.position = thingsPlace.transform.position;
    }

    public void UseThing()
    {
        for (int i = 0; i < things.Count; i++)
        {
            if (things[i].Use)
            {
                takeThing = things[i];
            }
        }
    }

    public Thing TryGetThing(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1))
        {
            if (hit.collider == null)
                return null;
        }
        return null;
    }
}
