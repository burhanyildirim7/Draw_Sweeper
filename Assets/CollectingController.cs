using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (transform.CompareTag("finishkova"))
		{
			// Finish kovas� ise...
			if (other.CompareTag("uc"))
			{		
				other.transform.parent.transform.position = new(0, other.transform.parent.transform.position.y, other.transform.parent.transform.position.z);
				GameController.instance.FinalEvents();
				Debug.Log("de�iyor...");
				Destroy(this);
			}
		}
		else if(transform.CompareTag("midkova"))
		{
			// ortalardaki kovalardan biri ise..
			if (other.CompareTag("uc"))
			{
				other.transform.parent.transform.position = new(0, other.transform.parent.transform.position.y, other.transform.parent.transform.position.z);
				GameController.instance.CheckCollector();
			}
		}
		
	}

}
