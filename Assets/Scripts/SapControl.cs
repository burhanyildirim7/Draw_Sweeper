using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapControl : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("engel"))
		{
			other.GetComponent<Collider>().enabled = false;
			GameController.instance.isContinue = false;
			DrawMeshSbi.instance.DeactivateDrawing();
			UIController.instance.ActivateLooseScreen();
		}


	}
}
