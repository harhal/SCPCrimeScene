using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
	private CipherSwitch Cipher;

	private IIntValueProvider ValueProvider;
	
	[SerializeField] private Sprite[] KeySprites;
	private SpriteRenderer Renderer;

	private void Awake()
	{
		Renderer = GetComponent<SpriteRenderer>();
		Cipher = GetComponent<CipherSwitch>();
		ValueProvider = GetComponent<IIntValueProvider>();
		UpdateImage();
	}

	public void UpdateImage()
	{
		Renderer.sprite = KeySprites[ValueProvider.GetValue()];
	}
}
