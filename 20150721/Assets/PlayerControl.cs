using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private Animator animator;
	private Rigidbody2D rigidbody2d;

	[SerializeField]
	private float jumpPower;

	public enum PLAYERSTATE
	{
		Run,
		Jump,
		Jump2,
		Die,
	}
	private PLAYERSTATE state = PLAYERSTATE.Run;

	void SetState(PLAYERSTATE st)
	{
		state = st;
		switch (state) {
		case PLAYERSTATE.Run:
			animator.SetBool("Jump",false);
			break;
		case PLAYERSTATE.Jump:
			animator.SetBool("Jump",true);
			break;
		case PLAYERSTATE.Jump2:
			animator.SetBool("Jump2",true);
			rigidbody2d.velocity = Vector2.zero;
			rigidbody2d.AddForce(Vector2.up * jumpPower);
			break;
		case PLAYERSTATE.Die:
			break;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
