using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseController : MonoBehaviour
{
    CasePrefab casePrefab;

    GameObject caseObject;

    [SerializeField]
    CaseFactory caseFactory = default;

    [SerializeField]
    Vector2Int caseSize = new Vector2Int(1,1);

    void Start()
    {
        casePrefab = caseFactory.GetBoard(0);
        caseObject = casePrefab.gameObject;
        caseObject.transform.localScale = new Vector2(caseSize.x, caseSize.y);
        SliceBoard();
    }

    void Update()
    {
        
    }

    [SerializeField]
    GameObject gridTileMap = default;

    [SerializeField]
    GameObject canvasTileMap = default;

    public Vector2Int SizeBoard
    {
        get { return caseSize; }
    }

    [SerializeField]
    CaseGrid gridPlacePrefab = default;

    List<CaseGrid> gridPlaceList = new List<CaseGrid>();

    public List<CaseGrid> GridPlaceList
    {
        get { return gridPlaceList; }
    }


    public GameObject Board
    {
        get { return caseObject; }
    }

    void TileMapSettings()
    {
        if (gridTileMap == null)
        {
            gridTileMap = Instantiate(loadTileMap, canvasTileMap.transform);
        }
        else
        {
            if (caseSize.x % 2 == 0)
            {
                gridTileMap.transform.position = new Vector3(gridTileMap.transform.position.x + 0.5f, gridTileMap.transform.position.y, gridTileMap.transform.position.z);
            }
            if (caseSize.y % 2 == 0)
            {
                gridTileMap.transform.position = new Vector3(gridTileMap.transform.position.x, gridTileMap.transform.position.y, gridTileMap.transform.position.z + 0.5f);
            }
        }
    }

    void SliceBoard()
    {
        float x, y;
        int num = 0;

        //TileMapSettings();
        for (int i = 0; i < caseSize.y; i++)
        {
            if (caseSize.y % 2 == 0)
            {
                y = (-caseSize.y + 1f) / 2 + i;
            }
            else
            {
                y = -caseSize.y / 2 + i;
            }
            for (int j = 0; j < caseSize.x; j++)
            {
                if (caseSize.x % 2 == 0)
                {
                    x = (-caseSize.x + 1f) / 2 + j;
                }
                else
                {
                    x = -caseSize.x / 2 + j;
                }

                createGrid(x, y, num);
                num++;
            }
        }
    }

    GameObject loadTileMap;
    public void LoadMap(bool LoadBoard, Vector2Int size, GameObject tileMap)
    {
        if (LoadBoard)
        {
            caseObject.transform.localScale = new Vector3(size.x, 1, size.y);
            caseSize.x = size.x;
            caseSize.y = size.y;
            loadTileMap = tileMap;
            Debug.Log($"Размер карты { caseSize.x} на { caseSize.y}");
            SliceBoard();


        }
        else
        {
            caseObject.transform.localScale = new Vector3(caseSize.x, 1, caseSize.y);
            SliceBoard();
        }

    }


    void createGrid(float x, float y, int num)
    {
        gridPlaceList.Add(caseFactory.GetGrid(num));
        gridPlaceList[gridPlaceList.Count - 1].transform.position = new Vector3(x, y, -0.1f);
        //gridPlaceList[num].NumberGrid = num;
    }

    public CaseGrid TryGetGrid(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1))
        {
            int x = (int)(hit.point.x + caseSize.x * 0.5f);
            int y = (int)(hit.point.y + caseSize.y * 0.5f);
            if (x >= 0 && x < caseSize.x && y >= 0 && y < caseSize.y)
            {
                return gridPlaceList[x + y * caseSize.x];
            }
        }
        return null;
    }
}
