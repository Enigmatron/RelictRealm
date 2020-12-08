using UnityEngine;
using System.Collections;

public class ExperimentalMovement : MonoBehaviour
{
	Rigidbody rigid;
	CapsuleCollider moveCollider;
	Vector3 MoveVector;
	Vector3 angleX;
	public bool isGrounded;
	Collider currentGrounded;
	RaycastHit groundHit;

	// Use this for initialization
	void Start ()
	{
		rigid = GetComponent<Rigidbody> ();
		moveCollider = GetComponent<CapsuleCollider> ();
	}



	void OnCollisionStay (Collision collisionInfo)
	{
//		Debug.Log("working");
		if (collisionInfo.contacts.Length > 0) {
			ContactPoint contact = collisionInfo.contacts [0];
			if (Vector3.Dot (contact.normal, Vector3.up) > 0.5) {
				isGrounded = true;
//				Debug.Log ("Grounded");
				currentGrounded = collisionInfo.collider;

			}
		} 
//		else {
//			isGrounded = false;
//			Debug.Log ("Ungrounded");
//
//		}
//		if(collisionInfo.gameObject.name == "Terrain")
//		{
//			isGrounded = true;
//			Debug.Log("hit");
//		}
//		if (collisionInfo.gameObject.tag == "Terrain") {
//			isGrounded = true;
//		}
	}

	void OnCollisionExit (Collision collisionInfo)
	{
		if (collisionInfo.collider == currentGrounded) {
			isGrounded = false;
		}
	}




	void FixedUpdate ()
	{
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0)
			MoveVector = new Vector3 (Input.GetAxisRaw ("Horizontal") * 6, 0, Input.GetAxisRaw ("Vertical") * 6);
		else
			MoveVector = Vector3.zero;	

		MoveVector.y = rigid.velocity.y;
		if (isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				MoveVector.y = 14;
				Debug.Log ("Jump: " + MoveVector.y);
			}		
		}
			
		rigid.velocity = transform.TransformDirection (MoveVector);

	}

}