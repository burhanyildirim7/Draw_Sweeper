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
			StartCoroutine(CoinAnimation(other.transform.position));
			other.tag = "emptytag";
			GameController.instance.collectingCount++;
		}
	}


	IEnumerator CoinAnimation(Vector3 position)
	{
		yield return new WaitForSeconds(1.5f);
		GameObject coin = Instantiate(goldCoin, position + new Vector3(0, 0, 1), Quaternion.identity);
		float time = Random.Range(.9f, 1.6f);
		//coin.transform.DOJump(position,5,1,2);
		//coin.transform.DORotate(new Vector3(179,0,0),2);
		//coin.transform.DOScale(Vector3.one * 2f, 1f).
		//	OnComplete(() => { coin.transform.DOScale(Vector3.one * .2f,1f); });
		coin.transform.DOMove(GameController.instance.goldTarget.position, time);
		coin.transform.DOScale(Vector3.one * .01f, 1.6f).OnComplete(() =>
		{
			GameController.instance.SetScore(10);
			Destroy(coin);
		});
	}
}
