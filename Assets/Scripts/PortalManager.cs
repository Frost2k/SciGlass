using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
	public GameObject MainCamera;
	public GameObject Sponza;
	public GameObject Derg;

	private Material[] SponzaMaterials;
	private Material[] DergMaterials;

    	// Start is called before the first frame update
    	void Start()
    	{
		SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
		DergMaterials = Derg.GetComponent<Renderer>().sharedMaterials;
    	}

    	// Update is called once per frame
    	void OnTriggerStay(Collider collider)
   	{
       		Vector3 camPosInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position); 

		if (camPosInPortalSpace.y < 0.5f)
		{
			// disable stencil test when about to enter building
			for (int i = 0; i < SponzaMaterials.Length; i++)
			{
				SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
			}

			for (int i = 0; i < DergMaterials.Length; i++)
			{
				DergMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
			}
		}
		else
		{
			// enable stencil test
			for (int i = 0; i < SponzaMaterials.Length; i++)
			{
				SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
			}

			for (int i = 0; i < DergMaterials.Length; i++)
			{
				DergMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
			}
		}
    	}
}
