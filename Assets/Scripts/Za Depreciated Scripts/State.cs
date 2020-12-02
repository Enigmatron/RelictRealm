// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.EventSystems;
// using Damage;
// using StatisticSystem;

// //using UnityEngine.Events;

// //public interface IPassiveDamagable : IEventSystemHandler
// //{
// //	void RecieveAoEDamage (MasterDamage att);
// //}

// public struct CombatRecord
// {
// 	public EntityState attacker;
// 	public string attackName;
// 	public int damageRecieved;

// 	public CombatRecord (EntityState att, string name, int damage)
// 	{
// 		attacker = att;
// 		attackName = name;
// 		//		tacticType = tacType;
// 		damageRecieved = damage;
// 	}
// }
// /*
/*
public abstract class State : EntityState_Dynamic
{
	 
	List<CombatRecord> damageLog = new List<CombatRecord> ();

	public List<CombatRecord> DamageLog {
		get {
			return damageLog;
		}
	}
	//	CompiledOptimizationProfile CompStat{ get; }
	//	StateStatus Status { get; }
	//
	//	CompiledStatistics CompStat{ get; }
	//
	//	StatusEffectManager StatusEffectVariables{ get; }

	public TeamInstance team;

	public override TeamInstance Team {
		get {
			return team;
		}
	}
		public event UpdateManager Update_Handler;
		public event UpdateManager Update_Pauseable_Handler;
		public event Damaged Damage_Listener_Handler;
		public event DamagedResponse Damage_Return_Listener_Handler;
		public event AttackLandedResponse Attack_Landed_Damage_Return_Listener_Handler;
		public event AttackLanded Attack_Landed_Listener_Handler;
		public event StatusEffectResponseListner Status_Effect_Response_Handler;
		public event Death Death_Handler;
		public event Death Pre_Death_Handler;

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

		public abstract void OnKill (IState other);
	
	
		public abstract void LandedAttack ();
	
		//	void OnKill (IState other);
	
		public abstract void LandedAttackResponse (int esr);
	

	#region//GamePlay Methods

	/// <summary>
	/// Recieves the damage profiles from other players.
	/// </summary>
	/// <param name="att">Att.</param>
	public override void RecieveDamage (Damage.Return att)
	{
//		if (Invincible)
//			return;

		//		att.AttachState (CompStat);

		if (Return_Damage_Listener_Handler () != null)
			Return_Damage_Listener_Handler () (); 

//		int OutputDamage = ProcessDamage (att.Dealer, att.Name, att.TotalDamage);

		if (Return_Damage_Return_Listener_Handler () != null)
			Return_Damage_Return_Listener_Handler () (ProccessDamageProfile (att.Dealer, att.Name, att.TotalDamage));

//		if (component [LifeAccessor.CurrentHealth] <= 0)
		OnPreDeath (att.Dealer);
	}

	//
	public int ProccessDamageProfile (EntityState state, string name, int InputDamage)
	{
		int DeltaResource;
		DeltaResource = 0;
//		int HealthDamage = Mathf.RoundToInt ((component [StatAccessor.Endurance] * 0.7f) * InputDamage);
//		int ShieldDamage = Mathf.RoundToInt ((component [StatAccessor.Vigor] * 0.35f) * InputDamage);

		/*
		if (!status.Shield_Shattered) {
			component [LifeAccessor.CurrentShield] = BasicFunction.SubtractTillZero (component [LifeAccessor.CurrentShield], ShieldDamage);
			if (Return_Damage_Return_Listener_Handler () != null)
				Return_Damage_Return_Listener_Handler () (ShieldDamage);
		} else if (!status.Out_Of_Health) {
			component [LifeAccessor.CurrentHealth] = BasicFunction.SubtractTillZero (component [LifeAccessor.CurrentHealth], ShieldDamage);

			if (Return_Damage_Return_Listener_Handler () != null)
				Return_Damage_Return_Listener_Handler () (HealthDamage);
		}

		 
		DamageLog.Add (new CombatRecord (state, name, InputDamage));
		if (state is State) {
			State state2 = (State)state;
			state2.LandedAttackResponse (DeltaResource);

		}
		return DeltaResource;
	}

	public void OnPreDeath (EntityState state)
	{
		if (Return_Pre_Death_Handler () != null)
			Return_Pre_Death_Handler ();
//		if (component [LifeAccessor.CurrentHealth] <= 0)
		OnDeath (state);
	}

	public void OnDeath (EntityState state)
	{
		if (Return_Death_Handler () != null)
			Return_Death_Handler () ();

		if (state is State) {
			State state2 = (State)state;
			state2.OnKill (this);
		}
	}

	public void OnKill (State other)
	{
				
		if (Score_Sovereign_Handler != null) {
//			SovereignState other2 = (SovereignState)other;
			Score_Sovereign_Handler (other);
		} else
			Score_Handler (other);

	}

	public void LandedAttackResponse (int resp)
	{
		if (Return_Attack_Landed_Damage_Return_Listener_Handler () != null) {
			Return_Attack_Landed_Damage_Return_Listener_Handler () (resp);
		}
	}

	public void LandedAttack ()
	{
		if (Return_Attack_Landed_Listener_Handler () != null) {
			Return_Attack_Landed_Listener_Handler () ();
		}
	}

	public override void ReceivedStatusEffect (StatusEffectPacket se)
	{
		if (Return_Status_Effect_Response_Handler () != null) {
			Return_Status_Effect_Response_Handler () (se);
		}
	}

	#endregion

	public EntityState_Dynamic[] GetOtherPlayers ()
	{
		return FindObjectsOfType<EntityState_Dynamic> ();
	}
}
*/