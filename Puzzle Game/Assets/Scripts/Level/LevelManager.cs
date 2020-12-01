using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    CaseController caseController= default;

    [SerializeField]
    ThingsController thingsController = default;

    CaseGrid caseGrid;
    int CaseNumber;

    //[HideInInspector]


    Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);



    void Start()
    {
        
    }

    void Update()
    {
        TouchController();
        thingsController.UseThing();
    }



    private void TouchController()
    {
        if (!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (thingsController.takeThing != null)
                {
                    caseGrid = caseController.TryGetGrid(TouchRay);
                    Debug.Log("Положил");
                    //BuildPlayerController(gridPlace);
                    CaseNumber = caseGrid.Number;
                    //Destroy(caseGrid.gameObject);
                    thingsController.takeThing.transform.position = caseGrid.transform.position;
                    thingsController.takeThing.UnUse();
                    thingsController.takeThing = null;
                }                
            }
        }
    }




    /// <summary>
    /// Не дает кликать и на UI и на 2d объект(UI важнее)
    /// </summary>
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
#if !ANDROID
        eventDataCurrentPosition.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
#else
        eventDataCurrentPosition.position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
#endif
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
