using UnityEngine;
using System;
using System.Collections.Generic;


//[CreateAssetMenu]
public class CaseFactory : GameObjectFactory
{
	[SerializeField]
	CasePrefab[] prefab = default;

	[SerializeField]
	CaseGrid grid = default;


	public CasePrefab[] CasePrefabs
	{
		get { return prefab; }
	}

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

	/////////////////////////////////////////////////////////////////////////////////////////////////////////

	public CaseGrid GetGrid(int num)
	{
		CaseGrid instance = CreateGameObjectInstance(grid);
		instance.OriginFactory = this;
		instance.SetNumber(num);
		instance.Initialize();
		return instance;
	}
	public void Reclaim(CaseGrid caseGrid)
	{
		Debug.Assert(caseGrid.OriginFactory == this, "Wrong factory reclaimed!");
		caseGrid.gameObject.SetActive(false);
	}
}
