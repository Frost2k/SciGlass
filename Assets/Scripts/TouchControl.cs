using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

using GoogleARCore;


public class TouchControl : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		// Only want to execute when screen is touched
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				// construct ray from current touch coords
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

				// destroy obj
				if (Physics.Raycast(ray, out hit))
				{
					GameObject obj = hit.collider.gameObject;

					// If object isn't already selected, "pick it up" and set it as selected
					// otherwise move it back to its original location
					if (!obj.GetComponent<Data>().IsSelected)	
					{
						obj.GetComponent<Data>().OriginalPosition = obj.transform.position;
						obj.GetComponent<Data>().OriginalRotation = obj.transform.rotation;
						obj.transform.position = ray.GetPoint(0.5f);
						obj.GetComponent<Data>().IsSelected = true;	

						GlobalInfo.SelectedObject = obj;
					}
					else
					{
						obj.transform.position = obj.GetComponent<Data>().OriginalPosition;
						obj.transform.rotation = obj.GetComponent<Data>().OriginalRotation;
						obj.GetComponent<Data>().IsSelected = false;	

						GlobalInfo.SelectedObject = null;
					}
				}
			}
		}
	}
}
