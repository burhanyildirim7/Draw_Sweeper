using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMesh : MonoBehaviour
{ 

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("�arp��ma alg�land�...");
		if (other.transform.CompareTag("singleMesh"))
		{
			//GetComponent<Collider>().enabled = false;
			DrawMeshSbi.instance.BreakMesh(other.transform.position);
		}
	}
}
