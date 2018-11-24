using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyField : MonoBehaviour, IInteractiveObject
{
	public int KeyValue;

	[SerializeField] private Sprite[] KeySprites;

	[SerializeField] private int CorrectValue;

	private SpriteRenderer Renderer;
	
	public delegate void OnValueChangedDelegate(KeyField changedKeyField);

	public OnValueChangedDelegate OnKeyValueChanged;

	private void Awake()
	{
		Renderer = GetComponent<SpriteRenderer>();
	}

	public void AddValue()
	{
		if (KeySprites.Length <= 0)
		{
			return;
		}
			
		KeyValue = (KeyValue + 1) % KeySprites.Length;

		UpdateImage();
		
		OnKeyValueChanged(this);
	}

	public bool IsCorrect()
	{
		return KeyValue == CorrectValue;
	}

	public void UpdateImage()
	{
		Renderer.sprite = KeySprites[KeyValue];
	}

	public void InteractWithObject(InteractionType interactionType, HitInfo hitInfo)
	{
		if (interactionType != InteractionType.Pressed)
		{
			return;
		}

		AddValue();
	}

	public bool IsEnabled()
	{
		return enabled;
	}

	public bool ValidateNormalOffset(float normalOffsetCos)
	{
		return normalOffsetCos > .3f;
	}
}
