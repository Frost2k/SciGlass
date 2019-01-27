using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
	public GameObject MainCamera;
	//public GameObject Sponza;

	public GameObject LeftWall;
	public GameObject RightWall;
	public GameObject Floor;
	public GameObject Ceiling;

	//private Material[] SponzaMaterials;
	private Material[] LeftWall_Materials;
	private Material[] RightWall_Materials;
	private Material[] Floor_Materials;
	private Material[] Ceiling_Materials;

    	// Start is called before the first frame update
    	void Start()
    	{
		//SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
		/*
		LeftWall_Materials = LeftWall.GetComponent<Renderer>().sharedMaterials;
		RightWall_Materials = RightWall.GetComponent<Renderer>().sharedMaterials;
		Floor_Materials = Floor.GetComponent<Renderer>().sharedMaterials;
		Ceiling_Materials = Ceiling.GetComponent<Renderer>().sharedMaterials;
		*/
    	}

    	// Update is called once per frame
    	void Update()
   	{
       		//Vector3 camPosInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position); 

		/*
		if (camPosInPortalSpace.y < 0.5f)
		{
			// disable stencil test when about to enter building
			for (int i = 0; i < SponzaMaterials.Length; i++)
			{
				SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
			}
		}
		else
		{
			// enable stencil test
			for (int i = 0; i < SponzaMaterials.Length; i++)
			{
				SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
			}
		}
		*/

		/*
		foreach (var mat in LeftWall_Materials)		mat.SetInt("_StencilComp", (int)CompareFunction.Equal);
		foreach (var mat in RightWall_Materials)	mat.SetInt("_StencilComp", (int)CompareFunction.Equal);
		foreach (var mat in Floor_Materials)		mat.SetInt("_StencilComp", (int)CompareFunction.Equal);
		foreach (var mat in Ceiling_Materials)		mat.SetInt("_StencilComp", (int)CompareFunction.Equal);
		*/
    	}
}
