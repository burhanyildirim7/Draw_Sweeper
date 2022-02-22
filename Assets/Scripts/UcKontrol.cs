using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcKontrol : MonoBehaviour
{
	public static UcKontrol instance;
	public bool isEnable = true;

	private void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("finishkova"))
		{

			other.GetComponent<Collider>().enabled = false;
			Destroy(other.gameObject);
			transform.parent.position = new(0,transform.parent.position.y,transform.parent.position.z);
			if(isEnable)GameController.instance.FinalEvents();
			isEnable = false;
			Debug.Log("deðiyor...");
			
		}
		else if (other.CompareTag("midkova"))
		{
			transform.parent.position = new(0, transform.parent.position.y, transform.parent.position.z);
			GameController.instance.CheckCollector();		
		}

	}
}
