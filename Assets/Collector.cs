using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("collectible"))
		{
			other.tag = "emptytag";
			GameController.instance.collectingCount++;
			Debug.Log("collectionCount : " + GameController.instance.collectingCount);
		}
	}
}
