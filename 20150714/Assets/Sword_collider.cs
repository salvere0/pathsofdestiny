using UnityEngine;
using System.Collections;

public class Sword_collider : MonoBehaviour {

	public Transform hitPoint;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Spider") && playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
		{
			Debug.Log ("아야");
			GameObject effect = Resources.Load("Spark") as GameObject;
			Instantiate(effect,
			            hitPoint.position,
			            Quaternion.identity);
		}
	}
}