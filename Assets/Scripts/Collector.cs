using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("collectible"))
		{
			other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GameController.instance.SetScore(10);
			other.tag = "emptytag";
			GameController.instance.collectingCount++;
		}
	}
}
