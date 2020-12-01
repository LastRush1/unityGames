using UnityEngine;
using System;
using System.Collections.Generic;


[CreateAssetMenu]
public class ClientsFactory : GameObjectFactory
{
	/*
     	[SerializeField]
	CasePrefab[] prefab = default;

    public CasePrefab GetBoard(int num)
	{
		CasePrefab instance = CreateGameObjectInstance(prefab[num]);
		instance.OriginFactory = this;
		instance.Initialize();
		return instance;
	}
	public void Reclaim(CasePrefab casePrefab)
	{
		Debug.Assert(casePrefab.OriginFactory == this, "Wrong factory reclaimed!");
		casePrefab.gameObject.SetActive(false);
	}
     * */
}
