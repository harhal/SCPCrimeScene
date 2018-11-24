using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractiveObject : MonoBehaviour, IInteractiveObject
{
	private InteractionType CurrentState = InteractionType.Inactive;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
		Renderer renderer = GetComponent<Renderer>();
		
		switch (interactionType)
		{
			case(InteractionType.Inactive):
				renderer.material.color = Color.white; break;
			case(InteractionType.Focus):
				renderer.material.color = Color.blue; break;
			case(InteractionType.Active):
				renderer.material.color = Color.green; break;
			case(InteractionType.Released):
				print("Released"); break;
			case(InteractionType.Pressed):
				print("Pressed"); break;
		}
		CurrentState = interactionType;
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
