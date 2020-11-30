using System;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]
[Serializable]
public class ContentSO : ScriptableObject
{
    [Header("Название вещи")]
    [SerializeField]
    protected new string name = "";

    public string Name
    {
        get
        {
            return name;
        }
    }


    [Header("id вещи")]
    [SerializeField]
    protected int id = default;

    public int Id
    {
        get
        {
            return id;
        }
    }
}
