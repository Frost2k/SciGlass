using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabLoad : MonoBehaviour
{
    public GameObject Triton;
    public GameObject Frog;
    public GameObject Lenny;

    // Start is called before the first frame update
    void Start()
    {
	if	(GlobalInfo.LabType == "Reptile")
	{
	    Triton.SetActive(true);
	    Frog.SetActive(true);
	    Lenny.SetActive(true);
	}
	else if (GlobalInfo.LabType == "Chem")
	{

	}
	else if (GlobalInfo.LabType == "Wine")
	{

	}
	else if (GlobalInfo.LabType == "Bio")
	{

	}
    }
}
