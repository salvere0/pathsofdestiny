using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animation))]
public class Samurai_ani : MonoBehaviour {

	private Animation anim;

	private static bool isattack;

	private static bool isjump;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();

		AnimationEvent actionEvent = new AnimationEvent ();
		actionEvent.functionName = "AttackStart";
		actionEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
		actionEvent.time = 12f / 30f;
		anim["Attack"].clip.AddEvent(actionEvent);
	}

	void AttackStart()
	{
		Debug.Log ("Attack!");
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.IsPlaying("Attack"))
		{
			isattack = true;
		}
		else
		{
			//anim.CrossFade("idle", 0.2f);
			isattack = false;
		}
		if (anim.IsPlaying ("Jump")) 
		{
			isjump = true;
		} 
		else 
		{
			//anim.CrossFade("idle",0.2f);
			isjump = false;
		}
		if (!isattack && !isjump)
		{
				if (Input.GetAxisRaw ("Vertical") != 0)
					{
						anim.CrossFade ("Walk", 0.2f);
						if (Input.GetKey (KeyCode.LeftShift)) 
				 		{
							anim.CrossFade ("Run", 0.2f);
						}
					} 
				else {
						anim.CrossFade ("idle", 0.2f);
					}
			}

		if (Input.GetMouseButtonDown(0) && !isjump) {
			anim.CrossFade("Attack", 0.2f);

		}
		if(Input.GetKey(KeyCode.Space) && !isattack)
		   {
			anim.CrossFade("Jump", 0.2f);
		}


	}
}
