using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
	[SerializeField] protected GameObject[] KeyFields;
	[SerializeField] private List<IBoolValueProvider> _keyFields;

	public UnityEngine.UI.Button.ButtonClickedEvent OnOpen;
	
	// Use this for initialization
	void Start () 
	{
		_keyFields = new List<IBoolValueProvider>();
		
		foreach (var keyField in KeyFields)
		{
			var valueProvider = keyField.GetComponent<IBoolValueProvider>();
			if (valueProvider != null)
			{
				_keyFields.Add(valueProvider);
			}
		}
		
		TryOpen();
	}

	public void TryOpen ()
	{
		int validKeysCount = 0;
		foreach (var keyField in _keyFields)
		{
			if (keyField.GetValue())
			{
				validKeysCount++;
			}
		}

		if (validKeysCount >= _keyFields.Count)
		{
			OnOpen.Invoke();
			enabled = false;
		}
	}
}
