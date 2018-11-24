using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButton : MonoBehaviour , IInteractiveObject
{
	public UnityEngine.UI.Button.ButtonClickedEvent OnClick;
	
	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
		if (interactionType == InteractionType.Pressed)
		{
			ProcessClick();
		}
	}

	public virtual void ProcessClick()
	{
		OnClick.Invoke();
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
