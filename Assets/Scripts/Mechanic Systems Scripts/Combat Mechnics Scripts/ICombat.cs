
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public abstract class ICombat : MonoBehaviour
{
	protected abstract TeamInstance Team {
		get;
	}

	//	public struct Offset
	//	{
	//		public float X;
	//		public float Y;
	//		public float Z;
	//
	//		public Offset (float x, float y, float z)
	//		{
	//			X = x;
	//			Y = y;
	//			Z = z;
	//		}
	//	}

	public struct DynamicLocation
	{
		public Vector3 CurrentWorldLocation ()
		{
			return RelativeLocation.TransformVector (Offset);
		}

		public Transform RelativeLocation;
		public Vector3 Offset;
		//		public

		public DynamicLocation (Transform trans, Vector3 offset)
		{
			RelativeLocation = trans;
			Offset = offset;
		}
	}

	public static readonly int None = 0;
	public static readonly int StopsAtWalls = 1 << 1;
	/// <summary>
	/// The flags: the bit flags associated with the ICombat unit.
	/// </summary>
	public int Flags;

	public abstract void OnInteraction_EnemyNPC (EntityState hit);

	public abstract void OnInteraction_NeutralNPC (EntityState hit);

	public abstract void OnInteraction_AllyNPC (EntityState hit);

	public abstract void OnInteraction_Enemy (EntityState hit);

	public abstract void OnInteraction_Ally (EntityState hit);

	public abstract void OnInteraction_Neutral_Contruct (EntityState hit);

	public abstract void OnInteraction_Ally_Contruct (EntityState hit);

	public abstract void OnInteraction_Enemy_Contruct (EntityState hit);


	/// <summary>
	/// The number of collisions: if 0 then infinite; else finite according to the var.
	/// </summary>
	public float NumberOfCollisions;

	/// <summary>
	/// The persistance: either the max distance of a ray to the duration a projectile lives for.
	/// </summary>
	public abstract float Persistance {
		get;
	}

	public float PersistanceProgress;



	public List<EntityState> TotalEnemiesHit;
	public List<EntityState> EnemiesHit;



	/// <summary>
	/// The hit refresh time: the time needed to clear the hit list; if 0 then NOClearing; else clears lists at time.
	/// </summary>
	public abstract float HitRefreshTime {
		get;
	}

	public float HitRefreshProgress;

	public abstract Vector3 LocalOffset{ get; }

	public void Interaction (EntityState hit)
	{
//		if (hit is EntityState) {
//			EntityState_Dynamic hit2 = (EntityState_Dynamic)hit;
//			if (hit2.Team == Team) {
//				OnInteraction_Ally (hit2);
//			} else {
//				OnInteraction_Enemy (hit2);
//			}
//		}
//		if (hit is CNPC) {
//			CNPC hit2 = (CNPC)hit;
//			if (hit2 is CNPC) {
//				if (Team != TeamInstance.Neutral) {
//					if (hit2.Team == TeamInstance.Neutral)
//						OnInteraction_NeutralNPC (hit2);
//					else if (hit2.Team == Team)
//						OnInteraction_AllyNPC (hit2);
//					else
//						OnInteraction_EnemyNPC (hit2);
//				} else
//					OnInteraction_EnemyNPC (hit2);
//				
////				else
////				OnInteraction_EnemyNPC (hit2);
//			}
//
//		}
//		if (hit is Construct) {
//			
//			Construct hit2 = (Construct)hit;
//			if (hit2.Team == TeamInstance.Neutral)
//				OnInteraction_Neutral_Contruct (hit2);
//			else if (hit2.Team == Team)
//				OnInteraction_Ally_Contruct (hit2);
//			else
//				OnInteraction_Enemy_Contruct (hit2);
//			
//		}
	}


	//	public void Sweep

	public void Update ()
	{
		if (HitRefreshProgress >= HitRefreshTime) {
			HitRefreshProgress = 0;
//			AlliesHit.Clear ();
			EnemiesHit.Clear ();
		} else {
			HitRefreshProgress = MathLambda.AddTillEqualTo (HitRefreshProgress, Time.deltaTime, HitRefreshTime);
		}
	}
}
//
public abstract class CombatHitScan : ICombat
{
	public Vector3 Direction;

	public new void Update ()
	{
		if (!(Persistance > 0)) {

			Destroy (gameObject);
		} else {
			if (PersistanceProgress >= Persistance)
				PersistanceProgress = MathLambda.AddTillEqualTo (PersistanceProgress, Time.deltaTime, Persistance);
		}


		base.Update ();

	}
}

/// <summary>
/// I combat aoe: a zone with a constant persistance or a single proccess.
/// </summary>
public abstract class CombatAoE : ICombat
{
	//TODO : Use Physic.OverlapSphere/OverlapBox
	public bool isAsquare;
	public float baseSize;
	public float endSize;

	public new void Update ()
	{



		base.Update ();
	}
}

/// <summary>
/// I combat killzone.
/// </summary>
public abstract class CombatKillzone<killzone>  : ICombat where killzone : Collider
{

	//TODO : Use Physic.OverlapSphere/OverlapBox but try to figure out triggers for this
	public killzone baseKillzone;
	public killzone endKillzone;
	public int extraSubDivisions;
	public Vector3 LocalEulerAngles;
	//TODO use the scene to grab gameobjects and then check if their colliders are the bounds of the Killzone




	//	public abstract void Interaction_Enemy (IState hit);
	//
	//	public abstract void Interaction_Ally (IState hit);
	//
	//	public abstract void Interaction_Wall ();

	public Vector3 endpoint;

	//	public

	//public Shape shape;
	//public float height;
	//public 2Dimensions StartDimensions;
	//public 2Dimensions EndDimensions;
	public Bounds[] KillzoneAreaReturn ()
	{
		Bounds[] list = new Bounds[extraSubDivisions + 2];
		list [0] = baseKillzone.bounds;
		list [extraSubDivisions + 1] = endKillzone.bounds;

//		for (int i = 0;; i++) {
//			
//		}
		return list;
	}


	//TODO: Look over this to make sure this works
	private void ProccessArea ()
	{
		Object[] tempList = Resources.FindObjectsOfTypeAll (typeof(GameObject));
		Dictionary<GameObject,EntityState> realList = new Dictionary<GameObject,EntityState> ();
		EntityState temp;
		GameObject temp2;

		foreach (Object obj in tempList) {
			if (obj is EntityState && obj is GameObject) {
				temp = (EntityState)obj;
				temp2 = (GameObject)obj;
//				if (temp is IDamagable)
				realList.Add (temp2, temp);
			}
		}
//		return realList;

		foreach (KeyValuePair<GameObject, EntityState> keyval in realList) {
			foreach (Bounds bound in KillzoneAreaReturn ())
				if (bound.Intersects (keyval.Key.GetComponent<Collider> ().bounds)) {
					Interaction (keyval.Value);
				}
		}
	}



	public new void Update ()
	{
		
	}
}

/// <summary>
/// I combat killzone.
/// </summary>
public abstract class CombatProjectile : ICombat
{
	//TODO : Use Physic.OverlapSphere/OverlapBox
	public static readonly int CrawlingEnd = 1 << 5;
	public static readonly int CrawlingStart = 1 << 6;

	//	public abstract void Interaction_Enemy (IState hit);
	//
	//	public abstract void Interaction_Ally (IState hit);
	//
	//	public abstract void Interaction_Wall ();

	public Vector3 Direction;

	public float Speed;


	//public Shape shape;
	//public float height;
	//public 2Dimensions StartDimensions;
	//public 2Dimensions EndDimensions;


	public new void Update ()
	{
		if (Persistance > 0) {

			Destroy (gameObject);
		} else {
			if (PersistanceProgress >= Persistance)
				PersistanceProgress = MathLambda.AddTillEqualTo (PersistanceProgress, Time.deltaTime, Persistance);
		}


		base.Update ();

	}

}

/// <summary>
/// I combat killzone.
/// </summary>
public abstract class CombatEntity : ICombat
{
	
	public static readonly int InteractWithTheOwner = 1 << 5;
	public static readonly int CrawlingStart = 1 << 6;

	//	public abstract void Interaction_Enemy (IState hit);
	//
	//	//	public abstract void Interaction_Enemy (IState hit);
	//
	//
	//	public abstract void Interaction_Ally (IState hit);
	//
	//	public abstract void Interaction_Wall ();

	public EntityState Entity;

	public Vector3 Direction;

	public float Speed;

	//public Shape shape;
	//public float height;
	//public 2Dimensions StartDimensions;
	//public 2Dimensions EndDimensions;

	public new void Update ()
	{
		if (Persistance > 0) {

			Destroy (gameObject);
		} else {
			if (PersistanceProgress >= Persistance)
				PersistanceProgress = MathLambda.AddTillEqualTo (PersistanceProgress, Time.deltaTime, Persistance);
		}


		base.Update ();

	}
}


/*
public abstract class Combat_Projectile : ICombat
{
	public Transform TargetStart;

	public MovementCommand Range;
	public Mesh PorjectileModel;
	public Collider collider;
	public float ColliderRadius;


	public ProjectileCollisionType coll;
	//public ProjectileInstance instance;
	//

	int CollisionCount;
	int currentCount;




	//
	public void Awake ()
	{


	}

	//
	public void Apply (Collision hit)
	{

		//		if (hit.gameObject.GetComponent<IState> () != null) {
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
		//		}
		Destroy (gameObject);

	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	//
	void OnCollisionEnter (Collision hit)
	{
		Debug.Log ("working");
		if (hit.gameObject.tag.Equals (tag)) {
			if (BasicFunction.FlagBool (Flags, InteractsWithEnemiesHit))
				Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
//			else
//				Apply ();

		}

		if (true) {
			if (BasicFunction.FlagBool (Flags, InteractsWithEnemiesHit)) {
				if (coll.Equals (ProjectileCollisionType.AllCollision)) {
					Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
					Debug.Log ("ignored");
				}
				if (coll.Equals (ProjectileCollisionType.SingleCollision)) {
					//Apply (hit);
					Debug.Log ("used");
					Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
					Destroy (gameObject);
				}
			}
		}
		if (hit.gameObject.tag.Equals ("Structure")) {
			if (!BasicFunction.FlagBool (Flags, StopsAtWalls)) {
				Physics.IgnoreCollision (hit.collider, GetComponent<Collider> ());
			} else {
				Destroy (this);
			}


		}
	}

	//	protected Combat_Projectile ()
	//	{
	//
	//	}
	//
	//	public static Builder Initialize ()
	//	{
	//		Builder temp = new Builder ();
	//		temp.create = new Combat_Projectile ();
	//		return temp;
	//	}
	//
	//	public class Builder
	//	{
	//		public Combat_Projectile create;
	//
	//		public Builder ()
	//		{
	//
	//		}
	//	}
}
	
//
public abstract class Combat_Collider: ICombat
{
	#region

	Transform location;
		
	public bool AoE;
	public bool Killzone;
	public Collider collider;

	#endregion

	//	protected Combat_Collider ()
	//	{
	//
	//	}
	//
	//	public static Builder Initialize ()
	//	{
	//		Builder temp = new Builder ();
	//		temp.create = new Combat_Collider ();
	//		return temp;
	//	}

	#region

	public class Builder
	{
		public Combat_Collider create;

	}

	#endregion
}

//
public abstract class Combat_Ray : ICombat
{
	//Variables

	#region

	End end;
	public float? range;
	public bool Ray;
	public bool RayAll;


	public RaycastHit hit;
	public RaycastHit[] hits;

	#endregion

	//Methods

	#region

	public void Use ()
	{
		
	}


	protected Combat_Ray ()
	{
		
	}

	#endregion

	//Internal Classes

	#region

	public class End
	{
		Transform endPosition;
		Vector3 endDirection;

		private End ()
		{

		}

		public End (Vector3 end)
		{
			endDirection = end;
		}

		public End (Transform end)
		{
			endPosition = end;
		}
	}

	#endregion

	//Builder

	#region

	//	public static Builder Declare ()
	//	{
	//		Builder temp = new Builder ();
	//		temp.ray = new Combat_Ray ();
	//		return temp;
	//	}
	//
	//	public class Builder
	//	{
	//		public Combat_Ray ray;
	//
	//		public Combat_Ray Initialize ()
	//		{
	//
	//			return ray;
	//		}
	//
	//
	//		public Builder Define_End_Direction (Vector3 val)
	//		{
	//			ray.end = new End (val);
	//			return this;
	//
	//		}
	//
	//		public Builder Define_End_Location (Transform val)
	//		{
	//			ray.end = new End (val);
	//			return this;
	//
	//		}
	//
	//		public Builder Define_Range_Finite (float val)
	//		{
	//			ray.range = val;
	//			return this;
	//
	//		}
	//
	//		public Builder Define_Range_Infinite ()
	//		{
	//			ray.range = 0;
	//			return this;
	//
	//		}
	//	}

	#endregion

}
*/