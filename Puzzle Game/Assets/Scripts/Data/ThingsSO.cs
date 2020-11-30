using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/CreateThing/NewThing", fileName = "Name/Id Thing")]
[Serializable]
public class ThingsSO : ContentSO
{
    [Header("Размер вещи")]
    [SerializeField, TextArea(3, 5)]
    string scale = default;

    public string Scale
    {
        get
        {
            return scale;
        }
    }

    [Header("Skin вещи")]
    [SerializeField]
     Sprite sprite = default;

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
}
