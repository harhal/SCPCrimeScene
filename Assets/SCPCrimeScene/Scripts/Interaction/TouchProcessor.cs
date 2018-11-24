using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchProcessor : MonoBehaviour
{
	private HashSet<GameObject> activeObjects;

	void Awake()
	{
		activeObjects = new HashSet<GameObject>();
	}
	
	void Update ()
	{
		var currentHits = new Dictionary<GameObject, HitInfo>();
		if (Input.touchSupported)
		{
			foreach (Touch touch in Input.touches)
			{
				Vector3 touchLocation = new Vector3(touch.position.x, touch.position.y, 0);
				ProcessInput(touchLocation, ref currentHits);
			}
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				ProcessInput(Input.mousePosition, ref currentHits);
			}
		}

		ProcessActiveInput(currentHits);
		ProcessInactiveInput(currentHits);
	}

	void ProcessInput(Vector3 inputLocation, ref Dictionary<GameObject, HitInfo> currentHits)
	{
		HitInfo hit = Raycaster.RaycastFromScreenPoint(inputLocation);

		if (!hit.HasHit)
		{
			return;
		}

		if (IsHitedObjectInteractive(hit) && !currentHits.ContainsKey(hit.Victim))
		{
			currentHits.Add(hit.Victim, hit);
		}
	}

	bool IsHitedObjectInteractive(HitInfo hit)
	{
		IInteractiveObject[] interactiveObjects = hit.Victim.GetComponents<IInteractiveObject>();

		foreach (var interactiveObject in interactiveObjects)
		{
			if (interactiveObject.IsEnabled() &&
			    interactiveObject.ValidateNormalOffset(Vector3.Dot(hit.Normal, -hit.HitDirection)))
			{
				return true;
			}

		}

		return false;
	}

	void ProcessActiveInput(Dictionary<GameObject, HitInfo> currentHits)
	{
		foreach (var hit in currentHits)
		{
			InteractionType interactionType;
			if (activeObjects.Contains(hit.Key))
			{
				interactionType = InteractionType.Active;
			}
			else
			{
				interactionType = InteractionType.Pressed;
				activeObjects.Add(hit.Key);
			}
			
			IInteractiveObject[] interactiveObjects = hit.Key.GetComponents<IInteractiveObject>();

			foreach (var interactiveObject in interactiveObjects)
			{
				if (interactiveObject.IsEnabled())
				{
					interactiveObject.InteractWithObject(interactionType, hit.Value);
				}
			}
		}
	}

	void ProcessInactiveInput(Dictionary<GameObject, HitInfo> currentHits)
	{
		var newActiveObjects = new HashSet<GameObject>();
		
		foreach (var Object in activeObjects)
		{
			if (!currentHits.Keys.Contains(Object))
			{
			
				IInteractiveObject[] interactiveObjects = Object.GetComponents<IInteractiveObject>();

				foreach (var interactiveObject in interactiveObjects)
				{
					if (interactiveObject.IsEnabled())
					{
						interactiveObject.InteractWithObject(InteractionType.Released, new HitInfo());
					}
				}
			}
			else
			{
				newActiveObjects.Add(Object);
			}
		}

		activeObjects = newActiveObjects;
	}
}
