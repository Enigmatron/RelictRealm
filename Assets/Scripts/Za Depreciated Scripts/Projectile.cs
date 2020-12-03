using UnityEngine;
using System.Collections;

// public enum ProjectileInstance
// {
// 	MercWeapon,
// 	Gungnir,
// 	GrenadeOut,
// 	MicroRockets,
// 	DragonFire,
// 	TidalPush,
// 	IcedIngots
// }

// public enum ProjectileMovementType
// {
// 	OverHead,
// 	StraightThrough,
// }

//public enum ProjectileCollisionType
//{
//	AllCollision,
//	AoEOnCollision,
//	SingleCollision
//}
//
//public class Projectile : MonoBehaviour
//{
//	public string enemyTag;
//
//	public	float speed;
//	public float decayRate;
//
//	public float timeAlive;
//
//	public ProjectileMovementType move;
//	public ProjectileCollisionType coll;
//	public ProjectileInstance instance;
//	//
//	public float AoERadius;
//	public bool Hostile;
//	public bool canGoThroughWalls;
//	public bool  isAffectedByGravity;
//	public bool decayingSpeed;
//
//
//	public void Awake(){
//		//this.tag = shooter.tag;
//		if (this.tag == "Gamma")
//				enemyTag = "Iota";
//		else if (this.tag == "Iota")
//			enemyTag = "Gamma";
//	}
//
//	public void Apply (Collision hit)
//	{
//		if (hit.gameObject.GetComponent<SovereignCharacter> () != null) {
//			/*
//			for(int i = 0; i< Mathf.Max (new float[]{statusEffects.Length, stacks.Length, buffs.Length}); i++)
//			{
//				if(statusEffects.Length != i || i < statusEffects.Length){
//					//hit.gameObject.GetComponent<Mercenary> ().SE.Add(statusEffects[i]);
//				}
//				if(stacks.Length != i || i < stacks.Length){
//					//hit.gameObject.GetComponent<Mercenary> ().AddStack(stacks[i]);
//				}
//				if(buffs.Length != i || i < buffs.Length){
//					//hit.gameObject.GetComponent<Mercenary> ().AddBuff(buffs[i]);
//				}
//			}
//		}  
//		else if (hit.gameObject.GetComponent<Fodder> () != null) {
//			for(int i = 0; i< Mathf.Max (new float[]{statusEffects.Length, stacks.Length, buffs.Length}); i++)
//			{
//				if(statusEffects.Length != i || i < statusEffects.Length){
//					//hit.gameObject.GetComponent<Fodder> ().SE.Add(statusEffects[i]);
//				}
//				if(stacks.Length != i || i < stacks.Length){
//					//hit.gameObject.GetComponent<Fodder> ().AddStack(stacks[i]);
//				}
//				if(buffs.Length != i || i < buffs.Length){
//					//hit.gameObject.GetComponent<Fodder> ().AddBuff(buffs[i]);
//				}
//			}
//			*/
//		}
//	}
//
//	// Use this for initialization
//	void Start ()
//	{
//	
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//
//	}
//
//	//
//	void OnCollisionEnter (Collision hit)
//	{
//		Debug.Log("working");
//		if (hit.gameObject.tag.Equals (tag)) {
//			if (Hostile)
//				Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
//
//		}
//
//		if (hit.gameObject.tag.Equals (enemyTag)) {
//			if (Hostile) {
//				if (coll.Equals (ProjectileCollisionType.AllCollision)) {
//					Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
//					Debug.Log("ignored");
//				}
//				if (coll.Equals (ProjectileCollisionType.SingleCollision)) {
//					//Apply (hit);
//					Debug.Log("used");
//					Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
//					Destroy (gameObject);
//				}
//			}
//		}
//		if (hit.gameObject.tag.Equals ("Structure")) {
//			if (canGoThroughWalls) {
//				Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
//			} else {
//				Destroy (this);
//			}
//
//
//		}
//		//Do stuff to the enemy here.
//	}
//}
//
