using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoolValueProvider
{
	bool GetValue();
}

public class CipherValidator : MonoBehaviour, IBoolValueProvider
{
	public int ValidValue;

	private IIntValueProvider IntValueProvider;

	private void Awake()
	{
		IntValueProvider = GetComponent<IIntValueProvider>();
	}

	public bool GetValue()
	{
		return IntValueProvider.GetValue() == ValidValue;
	}
}
