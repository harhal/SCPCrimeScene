using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CipherCilinder : MonoBehaviour
{
	private IIntValueProvider ValueProvider;

	public Transform SpinnerTransform;

	public Vector3 WheelAxis;

	public int ValuesCount = 1;

	private void Awake()
	{
		ValueProvider = GetComponent<IIntValueProvider>();
		UpdateRotation();
	}

	public void UpdateRotation()
	{
		SpinnerTransform.transform.localRotation = Quaternion.AngleAxis(360.0f / ValuesCount * ValueProvider.GetValue(), WheelAxis.normalized);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawLine(SpinnerTransform.transform.position, SpinnerTransform.transform.position + SpinnerTransform.transform.localToWorldMatrix.MultiplyVector(WheelAxis.normalized));
		Gizmos.DrawCube(SpinnerTransform.transform.localToWorldMatrix.MultiplyVector(WheelAxis.normalized), new Vector3(0.1f, 0.1f, 0.1f));
	}
}
