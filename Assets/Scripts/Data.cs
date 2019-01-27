using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
	public bool IsSelected;
	public Vector3 OriginalPosition;
	public Quaternion OriginalRotation;
	public string DisplayText;

	void Update()
	{
		if (IsSelected)
		{
			// rotate
			Vector3 rotationDirection = new Vector3(0, 1, 0);
			GlobalInfo.SelectedObject.transform.Rotate(rotationDirection * Time.deltaTime * 100);
		}
	}
}
