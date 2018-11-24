using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBoardPart : MonoBehaviour, IInteractiveObject
{
	public int Value;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
		throw new System.NotImplementedException();
	}

	public bool IsEnabled()
	{
		throw new System.NotImplementedException();
	}

	public bool ValidateNormalOffset(float normalOffsetCos)
	{
		throw new System.NotImplementedException();
	}
}
