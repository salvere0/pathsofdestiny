using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour {

	private Animator sami;

	private CharacterController charController;

	private Vector3 moveDirection = Vector3.zero;

	[SerializeField] private float rotateSpeed = 100.0f;
	[SerializeField] private float moveSpeed = 3.0f;
	[SerializeField] private float verticalSpeed = 0f;
	private float gravity = 9.0f;
	// Use this for initialization
	void Start () {
		sami = GetComponent<Animator> ();
		charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		sami.SetFloat ("Speed", v);
		sami.SetFloat ("Turn", h);

		Transform camtransform = Camera.main.transform;

		Vector3 forward = camtransform.TransformDirection (Vector3.forward);
		forward = forward.normalized;

		Vector3 right = new Vector3 (forward.z, 0f, -forward.x);

		Vector3 targerVector = v * forward + h * right;
		targerVector = targerVector.normalized;

		moveDirection = Vector3.RotateTowards (moveDirection, targerVector, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 500f);

		moveDirection = moveDirection.normalized;

		Vector3 grav = new Vector3 (0f, verticalSpeed, 0f);
		Vector3 movementAmount = (moveDirection * moveSpeed * Time.deltaTime) + grav;

		charController.Move (movementAmount);

		ApplyGravity ();
		BodyDirection ();
	}

	void ApplyGravity()
	{
		if (charController.isGrounded) {
			verticalSpeed = 0f;
		}
		else {
			verticalSpeed -= gravity * Time.deltaTime;
		}


	}

	void BodyDirection()
	{
		Vector3 HorizonalVelocity = charController.velocity;
		HorizonalVelocity.y = 0.0f;

		if (HorizonalVelocity.magnitude > 0.0f) {
			Vector3 tr = HorizonalVelocity.normalized;
			Vector3 targetVector = Vector3.Lerp(transform.forward, tr, 0.5f);
			if(targetVector != Vector3.zero)
			{
				transform.forward = targetVector;
			}
		}
	}


}
