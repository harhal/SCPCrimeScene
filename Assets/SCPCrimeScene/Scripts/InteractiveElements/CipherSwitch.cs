using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public interface IIntValueProvider
{
	int GetValue();
}

public class CipherSwitch : InteractiveButton, IIntValueProvider
{
	public int KeyValue;

	public int CipherCount = 1;

	public override void ProcessClick()
	{
		AddValue();
		base.ProcessClick();
	}

	public void AddValue()
	{
		KeyValue = (KeyValue + 1) % CipherCount;
	}

	public int GetValue()
	{
		return KeyValue;
	}
}
