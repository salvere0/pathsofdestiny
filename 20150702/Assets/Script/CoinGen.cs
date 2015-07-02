using UnityEngine;
using System.Collections;

public class CoinGen : MonoBehaviour {
	public int autoCoins;

	//private int coinCount;
	//private float elapseTime;

	// Use this for initialization
	void Start () {
		//coinCount = 0;
		this.StartCoroutine ("AutoGeneration");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && autoCoins > 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitObject;
			Physics.Raycast(ray, out hitObject);
			GameObject coin = Resources.Load("Coin") as GameObject;
			Instantiate(coin,hitObject.point, Quaternion.identity);
		}
	}

	IEnumerator AutoGeneration(){
		GameObject coin = Resources.Load("Coin") as GameObject;
		for (int i = 0; i < autoCoins; ++i)
		{
			Instantiate(coin, new Vector3(-0.5f,2f,-3f),Random.rotation);
			yield return new WaitForSeconds(0.2f);
		}
	}
}