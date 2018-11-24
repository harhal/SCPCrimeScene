using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBoardPart : MonoBehaviour, IInteractiveObject
{
	public int Value;

	public TagBoardSlot SlotOwner;

	private void Awake()
	{
		TagBoardSlot slotOwner = transform.parent.GetComponent<TagBoardSlot>();
		if (slotOwner == null)
		{
			return;
		}
        
		SlotOwner = slotOwner;
		SlotOwner.SlotContent = this;
	}

	public void UpdatePosition()
	{
		transform.SetParent(SlotOwner.transform, false);
	}

	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
		if (SlotOwner == null || interactionType != InteractionType.Pressed)
		{
			return;
		}

		SlotOwner.MoveContentToFree();
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
