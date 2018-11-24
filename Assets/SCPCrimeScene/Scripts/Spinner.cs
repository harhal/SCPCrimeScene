using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour, IInteractiveObject 
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
	}

	public bool IsEnabled()
	{
		return enabled;
	}

	public bool ValidateNormalOffset(float normalOffsetCos)
	{
		return normalOffsetCos > 0.6f;
	}
	
	
}
