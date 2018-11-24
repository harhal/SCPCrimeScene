using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBoard : MonoBehaviour
{
	public TagBoardSlot[] Slots;
	public int MixCycles = 6;

	public UnityEngine.UI.Button.ButtonClickedEvent OnOpen;
	
	void InitWeight()
	{
		for (int i = 0; i < Slots.Length; i++)
		{
			if (Slots[i].SlotContent != null)
			{
				Slots[i].SlotContent.Value = i;
			}
		}
	}

	void Mix()
	{
		for (int i = 0; i < MixCycles; i++)
		{
			int firstSlot = Random.Range(0, Slots.Length - 1);
			int secondSlot = Random.Range(0, Slots.Length - 1);
			print("Swap " + firstSlot.ToString() + " with " + secondSlot.ToString());
			Slots[firstSlot].Swap(Slots[secondSlot]);
		}
	}

	void UpdateParts()
	{
		foreach (var slot in Slots)
		{
			if (slot.SlotContent != null)
			{
				slot.SlotContent.UpdatePosition();
			}
		}	
	}

	public bool isPartsOrderValid()
	{
		for (int i = 0; i < Slots.Length; i++)
		{
			if (Slots[i].SlotContent == null)
			{
				continue;
			}

			if (Slots[i].SlotContent.Value != i)
			{
				return false;
			}
		}

		return true;
	}

	private void Start()
	{
		InitWeight();
		Mix();
		UpdateParts();
	}

	public void OnBoardUpdated()
	{
		if (isPartsOrderValid())
		{
			OnOpen.Invoke();
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
