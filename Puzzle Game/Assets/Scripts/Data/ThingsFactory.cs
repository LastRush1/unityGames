using UnityEngine;
using System;
using System.Collections.Generic;


//[CreateAssetMenu]
public class ThingsFactory : GameObjectFactory
{
	[Header("Место появления интерактивных вещей")]
	[SerializeField]
	ThingsPlace thingsBoard = default;

	[Header("Все вещи")]
	[SerializeField]
	Thing[] thing = default;

	public int ThingCount
    {
		get { return thing.Length; }
    }




	public ThingsPlace GetBoard()
	{
		ThingsPlace instance = CreateGameObjectInstance(thingsBoard);
		instance.OriginFactory = this;
		instance.Initialize();
		return instance;
	}
	public void Reclaim(ThingsPlace casePrefab)
	{
		Debug.Assert(casePrefab.OriginFactory == this, "Wrong factory reclaimed!");
		casePrefab.gameObject.SetActive(false);
	}
	public Thing GetThing(int num)
	{
		Thing instance = CreateGameObjectInstance(thing[num]);
		instance.OriginFactory = this;
		instance.Initialize();
		return instance;
	}
	public void Reclaim(Thing casePrefab)
	{
		Debug.Assert(casePrefab.OriginFactory == this, "Wrong factory reclaimed!");
		casePrefab.gameObject.SetActive(false);
	}
}
