using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour, IInteractiveObject
{
	[SerializeField] private Animator Box;
	
	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
		if (interactionType == InteractionType.Pressed)
		{
			Box.SetBool("Open", !Box.GetBool("Open"));
			
			print("Aaaand opeen!!!");

			//enabled = false;
		}
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
