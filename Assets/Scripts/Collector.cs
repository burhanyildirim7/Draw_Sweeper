using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
	public GameObject goldCoin;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("collectible"))
		{
			DrawMeshSbi.instance.drawableRelase = true;
			other.transform.tag = "emptytag";
			other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GameObject coin = Instantiate(goldCoin, other.transform.position + new Vector3(0,0,2), Quaternion.identity);
			float time = Random.Range(.9f, 1.6f);
			coin.transform.DOMove(GameController.instance.goldTarget.position, time);
			coin.transform.DOScale(Vector3.one*.1f, 1.6f).OnComplete(() => 
			{ 
				GameController.instance.SetScore(10);
				Destroy(coin);
			}); 
			other.tag = "emptytag";
			GameController.instance.collectingCount++;
		}
	}
}
