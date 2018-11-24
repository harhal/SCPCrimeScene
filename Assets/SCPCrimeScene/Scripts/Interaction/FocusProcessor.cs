using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusProcessor : MonoBehaviour
{
	private GameObject LastFocus;
	
	void Update ()
	{
		HitInfo hitInfo;
		Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0) / 2;
		hitInfo = Raycaster.RaycastFromScreenPoint(screenCenter);
		if (!hitInfo.HasHit)
		{
			UpdateLastFocus(null);
			return;
		}

		IInteractiveObject[] interactiveObjects = hitInfo.Victim.GetComponents<IInteractiveObject>();

		bool isInteractiveObjectsValid = false;

		foreach (var interactiveObject in interactiveObjects)
		{
			if (!interactiveObject.IsEnabled() || interactiveObject.ValidateNormalOffset(Vector3.Dot(hitInfo.Normal, -hitInfo.HitDirection)))
			{
				continue;
			}
			
			interactiveObject.InteractWithObject(InteractionType.Focus, hitInfo);
			isInteractiveObjectsValid = true;
		}

		UpdateLastFocus(isInteractiveObjectsValid ? hitInfo.Victim : null);
	}

	void UpdateLastFocus(GameObject newFocus)
	{
		if (LastFocus != null)
		{
			IInteractiveObject[] interactiveObjects = LastFocus.GetComponents<IInteractiveObject>();
			
			foreach (var interactiveObject in interactiveObjects)
			{
				interactiveObject.InteractWithObject(InteractionType.LoseFocus, new HitInfo());
			}
		}

		LastFocus = newFocus;
	}
}
