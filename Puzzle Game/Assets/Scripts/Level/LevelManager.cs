using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    CaseController caseController;

    CaseGrid caseGrid;
    int CaseNumber;

    Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);



    void Start()
    {
        
    }

    void Update()
    {
        TouchController();
    }

    private void TouchController()
    {
        if (!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                caseGrid = caseController.TryGetGrid(TouchRay);
                //BuildPlayerController(gridPlace);
                CaseNumber = caseGrid.Number;
                Debug.Log($"Номер тайла :{CaseNumber}");
                //Destroy(caseGrid.gameObject);
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
