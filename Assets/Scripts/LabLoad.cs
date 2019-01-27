using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabLoad : MonoBehaviour
{
    public GameObject Portal;

    public GameObject Lab;

    public GameObject ReptileLab;
    public GameObject ChemLab;
    public GameObject BioLab;
    public GameObject WineLab;

    private string lastLabType;

    void Start()
    {
		// Lab should be hidden at start
		Lab.SetActive(false);
		GlobalInfo.LabType = "Hidden";
    }

    // called every frame update
    void Update()
    {
	if (lastLabType == GlobalInfo.LabType) return;

	// Reptile image is top left
	if	(GlobalInfo.LabType == "Reptile")
	{
		Lab.SetActive(true);

		ReptileLab.SetActive(true);
		ChemLab.SetActive(false);
		BioLab.SetActive(false);
		WineLab.SetActive(false);
	}

	// Chem image is top right
	else if (GlobalInfo.LabType == "Chem")
	{
		Lab.SetActive(true);

		ReptileLab.SetActive(false);
		ChemLab.SetActive(true);
		BioLab.SetActive(false);
		WineLab.SetActive(false);
	}

	// Wine image is bottom left
	else if (GlobalInfo.LabType == "Wine")
	{
		Lab.SetActive(true);

		ReptileLab.SetActive(false);
		ChemLab.SetActive(false);
		BioLab.SetActive(false);
		WineLab.SetActive(true);
	}

	// Bio image is bottom right
	else if (GlobalInfo.LabType == "Bio")
	{
		Lab.SetActive(true);
		ReptileLab.SetActive(false);
		ChemLab.SetActive(false);
		BioLab.SetActive(true);
		WineLab.SetActive(false);
	}
	else if (GlobalInfo.LabType == "Hidden")
	{
		Lab.SetActive(false);
		ReptileLab.SetActive(false);
		ChemLab.SetActive(false);
		BioLab.SetActive(false);
		WineLab.SetActive(false);
	}

	lastLabType = GlobalInfo.LabType;
	//Lab.transform.position = Camera.main.transform.position;
	//Lab.transform.rotation = Camera.main.transform.rotation;

	/*
	Vector3 cameraPosition = Camera.transform.position;
	cameraPosition.y = Portal.transform.position.y;
	Portal.transform.LookAt(cameraPosition, Portal.transform.up);
	Portal.transform.parent = GlobalInfo.anchor.transform;
	*/
    }
}
