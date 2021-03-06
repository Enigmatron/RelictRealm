// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.EventSystems;
// using Damage;
// using StatisticSystem;

//using UnityEngine.Events;

//public interface IPassiveDamagable : IEventSystemHandler
//{
//	void RecieveAoEDamage (MasterDamage att);
//}
/*
/// <summary>
/// Interface Damagable: Dynamic. 
/// </summary>
public abstract class EntityState_Dynamic : EntityState
{


	#region

	public event StatusEffectResponseListner Status_Effect_Response_Handler;

	public StatusEffectResponseListner Return_Status_Effect_Response_Handler ()
	{
		return Status_Effect_Response_Handler;
	}

	public void Add_Status_Effect_Response_Handler (StatusEffectResponseListner add)
	{
		Status_Effect_Response_Handler += add;
	}

	public void Remove_Status_Effect_Response_Handler (StatusEffectResponseListner rev)
	{
		Status_Effect_Response_Handler -= rev;
	}

	#endregion

	#region

	public event CombatResponseListener Combat_Response_Listener_Handler;

	public CombatResponseListener Return_Combat_Response_Listener_Handler ()
	{
		return Combat_Response_Listener_Handler;
	}

	public void Add_Combat_Response_Listener_Handler (CombatResponseListener add)
	{
		Combat_Response_Listener_Handler += add;
	}

	public void Remove_Combat_Response_Listener_Handler (CombatResponseListener rev)
	{
		Combat_Response_Listener_Handler -= rev;
	}

	#endregion


	List<CombatRecord> damageLog = new List<CombatRecord> ();

	public event UpdateManager Update_Handler;
	public event UpdateManager Update_Pauseable_Handler;
	//	public event Damaged Damage_Listener_Handler;
	//	public event DamagedResponse Damage_Return_Listener_Handler;
	//	public event AttackLandedResponse Attack_Landed_Damage_Return_Listener_Handler;
	//	public event AttackLanded Attack_Landed_Listener_Handler;
	//	public event StatusEffectResponseListner Status_Effect_Response_Handler;
	//	public event Death Death_Handler;
	//	public event Death Pre_Death_Handler;

	#region

	public event ScoreListener Score_Handler;

	public ScoreListener Return_Score_Handler ()
	{
		return Score_Handler;
	}

	public void Add_Score_Handler (ScoreListener add)
	{
		Score_Handler += add;
	}

	public void Remove_Score_Handler (ScoreListener rev)
	{
		Score_Handler -= rev;
	}

	#endregion

	#region

	public event Score_IState_Listener Score_Sovereign_Handler;

	public Score_IState_Listener Return_Score_Sovereign_Handler ()
	{
		return Score_Sovereign_Handler;
	}

	public void Add_Score_Sovereign_Handler (Score_IState_Listener add)
	{
		Score_Sovereign_Handler += add;
	}

	public void Remove_Score_Sovereign_Handler (Score_IState_Listener rev)
	{
		Score_Sovereign_Handler -= rev;
	}

	#endregion

	//	public abstract void OnKill (EntityState_Dynamic other);
	//
	//
	//	public abstract void LandedAttack ();
	//
	//	//	void OnKill (IState other);
	//
	//	public abstract void LandedAttackResponse (int esr);
	//
	//
	//
	//
	//
	//
	//
	//	public EntityState_Dynamic[] GetOtherPlayers ()
	//	{
	//		return FindObjectsOfType<EntityState_Dynamic> ();
	//	}

	public abstract void ReceivedStatusEffect (StatusEffectPacket se);

	public enum StatusEffects
	{
		Snare,
		Deaccelerate,
		EnduranceSupression,
		DisplaceX,
		DisplaceY,

		DisplaceZ,

		CoordinationBlock,
		Motivate,
		Accelerate,
		Neutralize,
	}

	public struct StatusEffectSubPacker
	{
		public StatusEffects Type;
		public float Value;

		public class Builder
		{
			public static StatusEffectSubPacker CreateMotivation (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.Motivate;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateEnduranceSupression (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.EnduranceSupression;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateDeaccelerate (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.Deaccelerate;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateDisplaceX (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.DisplaceX;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateDisplaceY (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.DisplaceY;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateDisplaceZ (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.DisplaceZ;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateAcceletation (float val)
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.Accelerate;
				temp.Value = val;
				return temp;
			}

			public static StatusEffectSubPacker CreateNeutralize ()
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.Neutralize;
				temp.Value = 0;
				return temp;
			}

			public static StatusEffectSubPacker CreateSnare ()
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.Snare;
				temp.Value = 0;
				return temp;
			}

			public static StatusEffectSubPacker CreateCoordinationBlock ()
			{
				StatusEffectSubPacker temp;
				temp.Type = StatusEffects.CoordinationBlock;
				temp.Value = 0;
				return temp;
			}
		}
	}

	public class StatusEffectPacket
	{
		public StatusEffectSubPacker identification;
		//			public float Value;
		public float Duration;

		public  StatusEffectPacket (StatusEffectSubPacker type, float time)
		{
			identification = type;
			//				Value = value;
			Duration = time;
		}
	}

	List<StatusEffectPacket> statusEffectsList;

	public List<StatusEffectPacket> StatusEffectsList {
		get {
			if (statusEffectsList == null)
				statusEffectsList = new List<StatusEffectPacket> ();
			return statusEffectsList;
		}
	}

	#region

	int DefenseSuppressionCount;
	int DeaccelerateCount;
	int SnareCount;
	int DisplaceCount;
	int NeutralizeCount;
	int MotivateCount;
	int AccelerateCount;
	int CoordinationBlockCount;

	float slowValue;
	float enduranceSuppressValue;
	float motivateValue;
	float deacclValue;

	float acclValue;

	float advanceValue;
	float displaceValueX;
	float displaceValueY;
	float displaceValueZ;

	#endregion

	/* 
		 * Blindness
		 * Daze
		 * DefenseBypass
		 * DefenseSurpression
		 * KnockDown
		 * CoordinationBlock
		 * Neutralize
		 * Deaccelerate
		 * Snare
		 * Stagger
		 * Strike
		 * Neutralize
		 * Surge
		 * Suppress

	//		public void SetOwner (IState owns)
	//		{
	//			Owner = owns;
	//		}

		public void Add (IState state, IStatusEffect se)
		{
			if (se is StatusEffectFactory.Deaccelerate) {
				StatusEffectFactory.Deaccelerate cast = (StatusEffectFactory.Deaccelerate)se; 
				DeaccelerateCount++;
				slowValue += cast.value - cast.value * state.CompStat.Tenacity;
			}
			if (se is StatusEffectFactory.Snare) {
//				Snare cast = (Snare)se;
				SnareCount++;
			}
			if (se is StatusEffectFactory.Neutralize) {
//				Neutralize cast = (Neutralize)se;
				NeutralizeCount++;
			}
//			if(se is StatusEffectFactory.Knock_Down){
////				Knock_Down cast = (Knock_Down)se;
//				KnockDownCount++;
//
//			}
			if (se is StatusEffectFactory.Strike) {
//				Strike cast = (Strike)se;
				StrikeCount++;
//				strikeValue += cast.direction.Acceleration;
//				strikeDirection += cast.direction.Direction;

			}
			if (se is StatusEffectFactory.Defense_Supression) {
				StatusEffectFactory.Defense_Supression cast = (StatusEffectFactory.Defense_Supression)se;
				DefenseSuppressionCount++;
				defenseSuppressValue += cast.value;

			}
			if (se is StatusEffectFactory.Defense_Bypass) {
//				Defense_Bypass cast = (Defense_Bypass)se;
				DefenseBypassCount++;

			}
			if (se is StatusEffectFactory.Suppress) {
//				Suppress cast = (Suppress)se;
				SuppressCount++;

			}
			if (se is StatusEffectFactory.Blindness) {
				StatusEffectFactory.Blindness cast = (StatusEffectFactory.Blindness)se;
				BlindnessCount++;
				blindnessValue += cast.value;

			}
			if (se is StatusEffectFactory.Daze) {
				StatusEffectFactory.Daze cast = (StatusEffectFactory.Daze)se;
				DazeCount++;
				dazeValue += cast.value;
			}
			if (se is StatusEffectFactory.CoordinationBlock) {
//				CoordinationBlock cast = (CoordinationBlock)se;
				CoordinationBlockCount++;
			}
			if (se is StatusEffectFactory.Neutralize) {
//				Neutralize cast = (Neutralize)se;
				NeutralizeCount++;
			}
			if (se is StatusEffectFactory.Stagger) {
//				Stagger cast = (Stagger)se;
				StaggerCount++;
			}
			if (se is StatusEffectFactory.Surge) {
//				Surge cast = (Surge)se;
				SurgeCount++;
			}
			StatusEffectsList.Add (se, state);

			Owner.ReceivedStatusEffect (se);
		}

		//
		public void Remove (IStatusEffect se)
		{
			if (se is StatusEffectFactory.Deaccelerate) {
				StatusEffectFactory.Deaccelerate cast = (StatusEffectFactory.Deaccelerate)se;
				DeaccelerateCount--;
				slowValue -= cast.value;
			}
			if (se is StatusEffectFactory.Snare) {
//				Snare cast = (Snare)se;
				SnareCount--;
			}
			if (se is StatusEffectFactory.Neutralize) {
//				Neutralize cast = (Neutralize)se;
				NeutralizeCount--;
			}
//			if(se is StatusEffectFactory.Knock_Down){
////				Knock_Down cast = (Knock_Down)se;
//				KnockDownCount--;
//
//			}
			if (se is StatusEffectFactory.Strike) {
//				Strike cast = (Strike)se;
				StrikeCount--;
//				strikeValue -= cast.direction.Acceleration;
//				strikeDirection -= cast.direction.Direction;

			}
			if (se is StatusEffectFactory.Defense_Supression) {
				StatusEffectFactory.Defense_Supression cast = (StatusEffectFactory.Defense_Supression)se;
				DefenseSuppressionCount--;
				defenseSuppressValue -= cast.value;

			}
			if (se is StatusEffectFactory.Defense_Bypass) {
//				Defense_Bypass cast = (Defense_Bypass)se;
				DefenseBypassCount--;

			}
			if (se is StatusEffectFactory.Suppress) {
//				Suppress cast = (Suppress)se;
				SuppressCount--;

			}
			if (se is StatusEffectFactory.Blindness) {
				StatusEffectFactory.Blindness cast = (StatusEffectFactory.Blindness)se;
				BlindnessCount--;
				blindnessValue -= cast.value;

			}
			if (se is StatusEffectFactory.Daze) {
				StatusEffectFactory.Daze cast = (StatusEffectFactory.Daze)se;
				DazeCount--;
				dazeValue -= cast.value;
			}
			if (se is StatusEffectFactory.CoordinationBlock) {
//				CoordinationBlock cast = (CoordinationBlock)se;
				CoordinationBlockCount--;
			}
			if (se is StatusEffectFactory.Neutralize) {
//				Neutralize cast = (Neutralize)se;
				NeutralizeCount--;
			}
			if (se is StatusEffectFactory.Stagger) {
//				Stagger cast = (Stagger)se;
				StaggerCount--;
			}
			if (se is StatusEffectFactory.Surge) {
//				Surge cast = (Surge)se;
				SurgeCount--;
			}
			StatusEffectsList.Remove (se);
		}
*

	#region

	#region

	public bool isCoordinationBlock {
		get {
			return CoordinationBlockCount > 0;
		}
	}

	UnityEvent OnSustainCoordinationBlock;

	public void AddToSustainCoordinationBlock (UnityAction call)
	{
		OnSustainCoordinationBlock.AddListener (call);	
	}

	public void RemoveFromSustainCoordinationBlock (UnityAction call)
	{
		OnSustainCoordinationBlock.RemoveListener (call);	

	}

	public void CallSustainCoordinationBlock ()
	{
		if (OnSustainCoordinationBlock != null) {
			OnSustainCoordinationBlock.Invoke ();
		}
	}

	UnityEvent OnAddCoordinationBlock;

	public void AddToAddCoordinationBlock (UnityAction call)
	{
		OnAddCoordinationBlock.AddListener (call);	
	}

	public void RemoveFromAddCoordinationBlock (UnityAction call)
	{
		OnAddCoordinationBlock.RemoveListener (call);	

	}

	public void CallAddCoordinationBlock ()
	{
		if (OnAddCoordinationBlock != null) {
			OnAddCoordinationBlock.Invoke ();
		}
	}

	UnityEvent OnRemoveCoordinationBlock;

	public void AddToRemoveCoordinationBlock (UnityAction call)
	{
		OnRemoveCoordinationBlock.AddListener (call);	
	}

	public void RemoveFromRemoveCoordinationBlock (UnityAction call)
	{
		OnRemoveCoordinationBlock.RemoveListener (call);	

	}

	public void CallRemoveCoordinationBlock ()
	{
		if (OnRemoveCoordinationBlock != null) {
			OnRemoveCoordinationBlock.Invoke ();
		}
	}

	#endregion

	#region

	public bool isDisplaced {
		get {
			return DisplaceCount > 0;
		}
	}

	UnityEvent OnSustainDisplaced;

	public void AddToSustainDisplace (UnityAction call)
	{
		OnSustainDisplaced.AddListener (call);	
	}

	public void RemoveFromSustainDisplace (UnityAction call)
	{
		OnSustainDisplaced.RemoveListener (call);	

	}

	public void CallSustainDisplace ()
	{
		if (OnSustainDisplaced != null) {
			OnSustainDisplaced.Invoke ();
		}
	}

	UnityEvent OnAddDisplaced;

	public void AddToAddDisplaced (UnityAction call)
	{
		OnAddDisplaced.AddListener (call);	
	}

	public void RemoveFromAddDisplaced (UnityAction call)
	{
		OnAddDisplaced.RemoveListener (call);	

	}

	public void CallAddDisplaced ()
	{
		if (OnAddDisplaced != null) {
			OnAddDisplaced.Invoke ();
		}
	}

	UnityEvent OnRemoveDisplaced;

	public void AddToRemoveDisplaced (UnityAction call)
	{
		OnRemoveDisplaced.AddListener (call);	
	}

	public void RemoveFromRemoveDisplaced (UnityAction call)
	{
		OnRemoveDisplaced.RemoveListener (call);	

	}

	public void CallRemoveDisplaced ()
	{
		if (OnRemoveDisplaced != null) {
			OnRemoveDisplaced.Invoke ();
		}
	}

	#endregion

	#region

	public bool isSnare {
		get {
			return SnareCount > 0;
		}
	}

	UnityEvent OnSustainSnare;

	public void AddToSustainSnare (UnityAction call)
	{
		OnSustainSnare.AddListener (call);	
	}

	public void RemoveFromSustainSnare (UnityAction call)
	{
		OnSustainSnare.RemoveListener (call);	

	}

	public void CallSustainSnare ()
	{
		if (OnSustainSnare != null) {
			OnSustainSnare.Invoke ();
		}
	}

	UnityEvent OnAddSnare;

	public void AddToAddSnare (UnityAction call)
	{
		OnAddSnare.AddListener (call);	
	}

	public void RemoveFromAddSnare (UnityAction call)
	{
		OnAddSnare.RemoveListener (call);	

	}

	public void CallAddSnare ()
	{
		if (OnAddSnare != null) {
			OnAddSnare.Invoke ();
		}
	}

	UnityEvent OnRemoveSnare;

	public void AddToRemoveSnare (UnityAction call)
	{
		OnRemoveSnare.AddListener (call);	
	}

	public void RemoveFromRemoveSnare (UnityAction call)
	{
		OnRemoveSnare.RemoveListener (call);	

	}

	public void CallRemoveSnare ()
	{
		if (OnRemoveSnare != null) {
			OnRemoveSnare.Invoke ();
		}
	}

	#endregion

	#region

	public bool isNeutralize {
		get {
			return NeutralizeCount > 0;
		}
	}

	UnityEvent OnSustainNeutralize;

	public void AddToSustainNeutralize (UnityAction call)
	{
		OnSustainNeutralize.AddListener (call);	
	}

	public void RemoveFromSustainNeutralize (UnityAction call)
	{
		OnSustainNeutralize.RemoveListener (call);	

	}

	public void CallSustainNeutralize ()
	{
		if (OnSustainNeutralize != null) {
			OnSustainNeutralize.Invoke ();
		}
	}

	UnityEvent OnAddNeutralize;

	public void AddToAddNeutralize (UnityAction call)
	{
		OnAddNeutralize.AddListener (call);	
	}

	public void RemoveFromAddNeutralize (UnityAction call)
	{
		OnAddNeutralize.RemoveListener (call);	

	}

	public void CallAddNeutralize ()
	{
		if (OnAddNeutralize != null) {
			OnAddNeutralize.Invoke ();
		}
	}

	UnityEvent OnRemoveNeutralize;

	public void AddToRemoveNeutralize (UnityAction call)
	{
		OnRemoveNeutralize.AddListener (call);	
	}

	public void RemoveFromRemoveNeutralize (UnityAction call)
	{
		OnRemoveNeutralize.RemoveListener (call);	

	}

	public void CallRemoveNeutralize ()
	{
		if (OnRemoveNeutralize != null) {
			OnRemoveNeutralize.Invoke ();
		}
	}

	#endregion

	#region

	public bool isDeaccelerate {
		get {
			return DeaccelerateCount > 0;
		}
	}

	UnityEvent OnSustainDeaccelerate;

	public void AddToSustainDeaccelerate (UnityAction call)
	{
		OnSustainDeaccelerate.AddListener (call);	
	}

	public void RemoveFromSustainDeaccelerate (UnityAction call)
	{
		OnSustainDeaccelerate.RemoveListener (call);	

	}

	public void CallSustainDeaccelerate ()
	{
		if (OnSustainDeaccelerate != null) {
			OnSustainDeaccelerate.Invoke ();
		}
	}

	UnityEvent OnAddDeaccelerate;

	public void AddToAddDeaccelerate (UnityAction call)
	{
		OnAddDeaccelerate.AddListener (call);	
	}

	public void RemoveFromAddDeaccelerate (UnityAction call)
	{
		OnAddDeaccelerate.RemoveListener (call);	

	}

	public void CallAddDeaccelerate ()
	{
		if (OnAddDeaccelerate != null) {
			OnAddDeaccelerate.Invoke ();
		}
	}

	UnityEvent OnRemoveDeaccelerate;

	public void AddToRemoveDeaccelerate (UnityAction call)
	{
		OnRemoveDeaccelerate.AddListener (call);	
	}

	public void RemoveFromRemoveDeaccelerate (UnityAction call)
	{
		OnRemoveDeaccelerate.RemoveListener (call);	

	}

	public void CallRemoveDeaccelerate ()
	{
		if (OnRemoveDeaccelerate != null) {
			OnRemoveDeaccelerate.Invoke ();
		}
	}

	#endregion

	#region

	public bool isMotivate {
		get {
			return MotivateCount > 0;
		}
	}

	UnityEvent OnSustainMotivate;

	public void AddToSustainMotivate (UnityAction call)
	{
		OnSustainMotivate.AddListener (call);	
	}

	public void RemoveFromSustainMotivate (UnityAction call)
	{
		OnSustainMotivate.RemoveListener (call);	

	}

	public void CallSustainMotivate ()
	{
		if (OnSustainMotivate != null) {
			OnSustainMotivate.Invoke ();
		}
	}

	UnityEvent OnAddMotivate;

	public void AddToAddMotivate (UnityAction call)
	{
		OnAddMotivate.AddListener (call);	
	}

	public void RemoveFromAddMotivate (UnityAction call)
	{
		OnAddMotivate.RemoveListener (call);	

	}

	public void CallAddMotivate ()
	{
		if (OnAddMotivate != null) {
			OnAddMotivate.Invoke ();
		}
	}

	UnityEvent OnRemoveMotivate;

	public void AddToRemoveMotivate (UnityAction call)
	{
		OnRemoveMotivate.AddListener (call);	
	}

	public void RemoveFromRemoveMotivate (UnityAction call)
	{
		OnRemoveMotivate.RemoveListener (call);	

	}

	public void CallRemoveMotivate ()
	{
		if (OnRemoveMotivate != null) {
			OnRemoveMotivate.Invoke ();
		}
	}

	#endregion

	#region

	public bool isEndurance_Supression {
		get {
			return DefenseSuppressionCount > 0;
		}
	}

	UnityEvent OnSustainEnduranceSupression;

	public void AddToSustainEnduranceSupression (UnityAction call)
	{
		OnSustainEnduranceSupression.AddListener (call);	
	}

	public void RemoveFromSustainEnduranceSupression (UnityAction call)
	{
		OnSustainEnduranceSupression.RemoveListener (call);	

	}

	public void CallSustainEnduranceSupression ()
	{
		if (OnSustainEnduranceSupression != null) {
			OnSustainEnduranceSupression.Invoke ();
		}
	}

	UnityEvent OnAddEnduranceSupression;

	public void AddToAddEnduranceSupression (UnityAction call)
	{
		OnAddEnduranceSupression.AddListener (call);	
	}

	public void RemoveFromAddEnduranceSupression (UnityAction call)
	{
		OnAddEnduranceSupression.RemoveListener (call);	

	}

	public void CallAddEnduranceSupression ()
	{
		if (OnAddEnduranceSupression != null) {
			OnAddEnduranceSupression.Invoke ();
		}
	}

	UnityEvent OnRemoveEnduranceSupression;

	public void AddToRemoveEnduranceSupression (UnityAction call)
	{
		OnRemoveEnduranceSupression.AddListener (call);	
	}

	public void RemoveFromRemoveEnduranceSupression (UnityAction call)
	{
		OnRemoveEnduranceSupression.RemoveListener (call);	

	}

	public void CallRemoveEnduranceSupression ()
	{
		if (OnRemoveEnduranceSupression != null) {
			OnRemoveEnduranceSupression.Invoke ();
		}
	}

	#endregion

	#region

	public bool isAccelerate {
		get {
			return AccelerateCount > 0;
		}
	}

	UnityEvent OnSustainAccelerate;

	public void AddToSustainAccelerate (UnityAction call)
	{
		OnSustainAccelerate.AddListener (call);	
	}

	public void RemoveFromSustainAccelerate (UnityAction call)
	{
		OnSustainAccelerate.RemoveListener (call);	

	}

	public void CallSustainAccelerate ()
	{
		if (OnSustainAccelerate != null) {
			OnSustainAccelerate.Invoke ();
		}
	}

	UnityEvent OnAddAccelerate;

	public void AddToAddAccelerate (UnityAction call)
	{
		OnAddAccelerate.AddListener (call);	
	}

	public void RemoveFromAddAccelerate (UnityAction call)
	{
		OnAddAccelerate.RemoveListener (call);	

	}

	public void CallAddAccelerate ()
	{
		if (OnAddAccelerate != null) {
			OnAddAccelerate.Invoke ();
		}
	}

	UnityEvent OnRemoveAccelerate;

	public void AddToRemoveAccelerate (UnityAction call)
	{
		OnRemoveAccelerate.AddListener (call);	
	}

	public void RemoveFromRemoveAccelerate (UnityAction call)
	{
		OnRemoveAccelerate.RemoveListener (call);	

	}

	public void CallRemoveAccelerate ()
	{
		if (OnRemoveAccelerate != null) {
			OnRemoveAccelerate.Invoke ();
		}
	}

	#endregion

	#endregion

	#region

	public float Deaccelerate_Value {

		get {
			return slowValue;
		}
	}

	public float Accelerate_Value {

		get {
			return advanceValue;
		}
	}

	public float Endurance_Supression_Value {
		get {
			return enduranceSuppressValue;
		}
	}

	public float Motivate_Value {
		get {
			return motivateValue;
		}
	}

	#region

	public float Displace_ValueX {
		get {
			return displaceValueX;
		}
	}

	public float Displace_ValueY {
		get {
			return displaceValueY;
		}
	}

	public float Displace_ValueZ {
		get {
			return displaceValueZ;
		}
	}

	#endregion

	#endregion

	/*
		 * 
		 *

	#region

	#endregion

	public void RefreshSE ()
	{
		if (isDisplaced)
			CallSustainDisplace ();
		if (isNeutralize)
			CallSustainNeutralize ();
		if (isSnare)
			CallSustainSnare ();
		if (isAccelerate)
			CallSustainAccelerate ();
		if (isDeaccelerate)
			CallSustainDeaccelerate ();
		if (isEndurance_Supression)
			CallSustainEnduranceSupression ();
		if (isMotivate)
			CallSustainMotivate ();
		if (isCoordinationBlock)
			CallSustainCoordinationBlock ();

		foreach (StatusEffectPacket keyval in statusEffectsList) {
			keyval.Duration = BasicFunction.SubtractTillZero (keyval.Duration, Time.deltaTime);
			if (keyval.Duration == 0)
				Remove (keyval);
		}
	}

	public void Clense ()
	{
		StatusEffectsList.Clear ();
		SnareCount = 0;
		NeutralizeCount = 0;
		MotivateCount = 0;
		DisplaceCount = 0;
		DefenseSuppressionCount = 0;
		DeaccelerateCount = 0;
		CoordinationBlockCount = 0;
		AccelerateCount = 0;
		displaceValueZ = 0;
		displaceValueY = 0;
		displaceValueX = 0;
		deacclValue = 0;
		advanceValue = 0;
		acclValue = 0;
		slowValue = 0;
		motivateValue = 0;
		enduranceSuppressValue = 0;
	}

	public void Add (StatusEffectPacket packet)
	{
		StatusEffectsList.Add (packet);
		switch (packet.identification.Type) {
		case StatusEffects.Accelerate:
			AccelerateCount++;
			acclValue += packet.identification.Value;
			break;

		case StatusEffects.CoordinationBlock:
			CoordinationBlockCount++;
			//					acclValue += packet.identification.Value;
			break;

		case StatusEffects.Deaccelerate:
			DeaccelerateCount++;
			deacclValue += packet.identification.Value;
			break;

		case StatusEffects.DisplaceX:
			DisplaceCount++;
			displaceValueX += packet.identification.Value;
			break;

		case StatusEffects.DisplaceY:
			DisplaceCount++;
			displaceValueY += packet.identification.Value;
			break;

		case StatusEffects.DisplaceZ:
			DisplaceCount++;
			displaceValueZ += packet.identification.Value;
			break;

		case StatusEffects.EnduranceSupression:
			DefenseSuppressionCount++;
			enduranceSuppressValue += packet.identification.Value;
			break;

		case StatusEffects.Motivate:
			MotivateCount++;
			motivateValue += packet.identification.Value;
			break;

		case StatusEffects.Neutralize:
			NeutralizeCount++;
			//					acclValue += packet.identification.Value;
			break;

		case StatusEffects.Snare:
			SnareCount++;
			//					acclValue += packet.identification.Value;
			break;

		}
	}

	public void Remove (StatusEffectPacket packet)
	{
		switch (packet.identification.Type) {
		case StatusEffects.Accelerate:
			AccelerateCount--;
			acclValue -= packet.identification.Value;
			break;

		case StatusEffects.CoordinationBlock:
			CoordinationBlockCount--;
			//					acclValue += packet.identification.Value;
			break;

		case StatusEffects.Deaccelerate:
			DeaccelerateCount--;
			deacclValue -= packet.identification.Value;
			break;

		case StatusEffects.DisplaceX:
			DisplaceCount--;
			displaceValueX -= packet.identification.Value;
			break;

		case StatusEffects.DisplaceY:
			DisplaceCount--;
			displaceValueY -= packet.identification.Value;
			break;

		case StatusEffects.DisplaceZ:
			DisplaceCount--;
			displaceValueZ -= packet.identification.Value;
			break;

		case StatusEffects.EnduranceSupression:
			DefenseSuppressionCount--;
			enduranceSuppressValue -= packet.identification.Value;
			break;

		case StatusEffects.Motivate:
			MotivateCount--;
			motivateValue -= packet.identification.Value;
			break;

		case StatusEffects.Neutralize:
			NeutralizeCount--;
			//					acclValue += packet.identification.Value;
			break;

		case StatusEffects.Snare:
			SnareCount--;
			//					acclValue += packet.identification.Value;
			break;

		}
		StatusEffectsList.Remove (packet);
	}

	public EntityState_Dynamic[] GetOtherEntities ()
	{
//		FindObjectsOfType<IDamagable_Dynamic> ();
		return FindObjectsOfType<EntityState_Dynamic> ();
	}
}
*/