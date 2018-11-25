using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CipherCilinder : MonoBehaviour
{
	private IIntValueProvider ValueProvider;

	public Vector3 WheelAxis;

	public int ValuesCount = 1;

	private void Awake()
	{
		ValueProvider = GetComponent<IIntValueProvider>();
		UpdateRotation();
	}

	public void UpdateRotation()
	{
		transform.rotation = Quaternion.AngleAxis(360.0f / ValuesCount * ValueProvider.GetValue(), WheelAxis.normalized);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawLine(transform.position, transform.position + transform.localToWorldMatrix.MultiplyVector(WheelAxis.normalized));
		Gizmos.DrawCube(transform.localToWorldMatrix.MultiplyVector(WheelAxis.normalized), new Vector3(0.1f, 0.1f, 0.1f));
	}
}
