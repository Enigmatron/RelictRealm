
/*
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using StatisticSystem;
using Damage;





public class Info<I>
{
	public Sprite ProfileImage;
	public string Name;
	public I Item;
}


//public class CollectionNode_Out :CollectionNode
//{
//
//	public CollectionNode_Out (object item, IState to)
//	{
//		base.Item = item;
//		base.Send = to;
//	}
//}
//
//public class CollectionNode_In : CollectionNode
//{
//
//
//	public CollectionNode_In (object item, IState from)
//	{
//		base.Item = item;
//		base.Send = from;
//	}
//}

/*
 
/// <summary>
/// Sovereign state.
/// </summary>
public class TestState : EntityState_Dynamic
{

	public override void ReceivedStatusEffect (StatusEffectPacket se)
	{
		throw new NotImplementedException ();
	}

	public override TeamInstance Team {
		get {
			throw new NotImplementedException ();
		}
	}
	//	TeamInstance team;
	//
	//	public override TeamInstance Team {
	//		get {
	//			return team;
	//		}
	//	}
	public override LifeResource Life {
		get {
			throw new NotImplementedException ();
		}
	}



	#region//StatisticVariables

	//	Dictionary<IStatusEffect, IState> statusEffectsList;
	//
	//	public Dictionary<IStatusEffect, IState> StatusEffectManagerList {
	//		get {
	//
	//			return statusEffectsList;
	//		}
	//	}

	SovereignController control;

	public SovereignController Control {
		get {
			return Control;
		}
	}

	SovereignComponent component;

	public CharacterStatistic BaseStat {
		get {
			return component.BaseStats;
		}
	}
	//	public BaseOptimizationMutators BaseOpt {
	//		get{
	//			return component.BaseOpt;
	//		}
	//	}
	//	//
	//	List<StableOptimizationProfile[]> unstableStat = new List<StableOptimizationProfile[]>();
	//	public List<StableOptimizationProfile[]> UnstableStat{
	//		get{
	//			return unstableStat;
	//		}
	//	}
	//	StableOptimizationProfile stableStat;
	//
	//	CompiledOptimizationProfile statistics;
	//	public CompiledOptimizationProfile CompStat{
	//		get{
	//			return statistics;
	//		}
	//	}
	//	CompiledStatistics statistics;

	//	public CompiledStatistics CompStat {
	//		get {
	//			return statistics;
	//		}
	//	}
	//
	//	StatusEffectManager statusEffectVariables = new StatusEffectManager ();
	//
	//	public StatusEffectManager StatusEffectVariables {
	//		get {
	//			return statusEffectVariables;
	//		}
	//	}
	//	public readonly NetworkPlayer ID;
	//	public TeamInstances TeamID;
	//	public TeamState Team;
	//
	//	public bool Visible;
	//	public bool VisibleToEnemy {
	//		get {
	//			return Team.ForcedVisibility || (!Cloaked && Visible);
	//		}
	//	}
	//	//

	//	//
	//	List<CollectionNode_In> ins = new List<CollectionNode_In> ();
	//
	//	public List<CollectionNode_In> In {
	//		get {
	//			return ins;
	//		}
	//	}
	//
	//	//
	//	List<CollectionNode_Out> outs = new List<CollectionNode_Out> ();
	//
	//	public List<CollectionNode_Out> Out {
	//		get {
	//			return outs;
	//		}
	//	}


	//

	//	List<MovementCommand> moveCommands;

	public List<MovementCommand> MoveCommands {
		get {
			return component.MovementCommands;
		}
	}

	/*
	//	List<DistributableObjectNode> se = new List<DistributableObjectNode> ();
	//	public List<DistributableObjectNode> StatusEffectManager {
	//		get{
	//			return copies;
	//		}
	//	}
	////	List<RegisterableObjectNode> register = new List<RegisterableObjectNode> ();
	//	public List<RegisterableObjectNode> Registers {
	//		get{
	//			return register;
	//		}
	//	}

	public void DistributeCopy(IState from, ISendable collect){
		/// add code checking 
		if (this.AccessCopy (collect.ID) != null) {
			this.AccessCopy (collect.ID);
		}
		else{
			this.Collects.Add (new ICollectObjectNode (collect, this, from));

		}
	}


	#endregion

	#region


	StateStatus status = new StateStatus ();

	public StateStatus Status {
		get {
			return status;
		}
	}

	public bool In_Combat {
		get {
			return false;
		}
	}

	List<CombatRecord> damageLog = new List<CombatRecord> ();

	public List<CombatRecord> DamageLog {
		get {
			return damageLog;
		}
	}
	//
	//	public bool Rending;
	//
	//	public bool Steeled;
	//	//
	//	public bool Shield_Shatter_1, Shield_Shatter_2, Shield_Shatter_3;
	//	public bool Shields_Shattered {
	//		get {
	//			return Shield_Shatter_1 && Shield_Shatter_2 && Shield_Shatter_3;
	//		}
	//	}
	//	//
	//	public bool Armor_Shatter{
	//		get{
	//			return true;
	//		}
	//	}
	//	public bool Out_Of_Health{
	//		get{
	//			return true;
	//		}
	//	}
	//
	//
	public bool Invincible;
	public bool Immune_To_Status_Efects;


	#endregion

	#region//Access Method


	//	public void AddCollectible(){
	//
	//	}
	//	public Collectible AccessCollectible (string key)
	//	{
	//		Collectible temp = new Collectible ();
	//		CollectibleLibrary.TryGetValue (key, out temp);
	//		return temp;
	//	}
	//
	//	public Collectible AccessCollectible (CollectibleLibrary.Instances key)
	//	{
	//		Collectible temp = new Collectible ();
	//		CollectibleLibrary.TryGetValue (Enum.GetName (typeof(CollectibleLibrary), (int)key), out temp);
	//		return temp;
	//	}

	#endregion

	#region//GamePlay Methods

	/// <summary>
	/// Recieves the damage profiles from other players.
	/// </summary>
	/// <param name="att">Att.</param>
	public override void RecieveDamage (Damage.Return att)
	{
		if (Invincible)
			return;
		
//		att.AttachState (CompStat);

		if (Return_Damage_Listener_Handler () != null)
			Return_Damage_Listener_Handler () (); 
		
		ProcessDamage (att.Dealer, att.Name, att.TotalDamage);

		if (component [LifeAccessor.CurrentHealth] <= 0)
			OnPreDeath (att.Dealer);
	}

	/*
//	public void RecieveAoEDamage(Damage.DamageProfile att){
//		if (Invincible)
//			return;
////		att.state.LandedAttack ();
//		if (Damage_Listener_Handler != null)
//			Damage_Listener_Handler ();
//		ProcessDamage (att.state, att.name, att.TotalDamage, CompStat.Endurance);
//	}


	//
	public void ProcessDamage (EntityState state, string name, int InputDamage)
	{
		int deltaHealth;
		deltaHealth = 0;
		int HealthDamage = Mathf.RoundToInt ((component [StatAccessor.Endurance] * 0.7f) * InputDamage);
		int ShieldDamage = Mathf.RoundToInt ((component [StatAccessor.Vigor] * 0.35f) * InputDamage);


		if (!status.Shield_Shattered) {
			component [LifeAccessor.CurrentShield] = BasicFunction.SubtractTillZero (component [LifeAccessor.CurrentShield], ShieldDamage);
			if (Return_Damage_Return_Listener_Handler () != null)
				Return_Damage_Return_Listener_Handler () (ShieldDamage);
		} else if (!status.Out_Of_Health) {
			component [LifeAccessor.CurrentHealth] = BasicFunction.SubtractTillZero (component [LifeAccessor.CurrentHealth], ShieldDamage);

			if (Return_Damage_Return_Listener_Handler () != null)
				Return_Damage_Return_Listener_Handler () (HealthDamage);
		}

//		if (Damage_Return_Listener_Handler != null)
//			Damage_Return_Listener_Handler (OutputDamage);
		DamageLog.Add (new CombatRecord (state, name, InputDamage));
		if (state is EntityState_Dynamic) {
			EntityState_Dynamic state2 = (EntityState_Dynamic)state;
			state2.LandedAttackResponse (deltaHealth);
	
		}
	}

	public void OnPreDeath (EntityState state)
	{
		if (Return_Pre_Death_Handler () != null)
			Return_Pre_Death_Handler ();
		if (component [LifeAccessor.CurrentHealth] <= 0)
			OnDeath (state);
	}

	public void OnDeath (EntityState state)
	{
		if (Return_Death_Handler () != null)
			Return_Death_Handler ();

		if (state is EntityState_Dynamic) {
			EntityState_Dynamic state2 = (EntityState_Dynamic)state;
			state2.OnKill (this);
		}
	}

	public override void OnKill (EntityState_Dynamic other)
	{
		//		
//		if (Score_Sovereign_Handler != null && other is SovereignState) {
//			SovereignState other2 = (SovereignState)other;
//			Score_Sovereign_Handler (other2);
//		} else
//			Score_Handler (other);
	
	}

	public override void LandedAttackResponse (int resp)
	{
//		if (Attack_Landed_Damage_Return_Listener_Handler != null) {
//			Attack_Landed_Damage_Return_Listener_Handler (resp);
//		}
	}

	public override void LandedAttack ()
	{
//		if (Attack_Landed_Listener_Handler != null) {
//			Attack_Landed_Listener_Handler ();
//		}
	}

	//	public override void ReceivedStatusEffect (IStatusEffect se)
	//	{
	//		if (Status_Effect_Response_Handler != null) {
	//			Status_Effect_Response_Handler (se);
	//		}
	//	}

	#endregion

	#region

	//	public SovereignState(SovereignComponent inst){
	//		component = inst;
	//		stableStat = new StableOptimizationProfile (0,0,0,0,0,0,0,0,0);
	//		statistics = new CompiledOptimizationProfile (BaseStat, stableStat, BaseOpt);
	//	}

	//		public SovereignState(SovereignComponent inst){
	//			Attack_Landed_Damage_Return_Listener_Handler += ReceiveDamageResponse;
	//			component = inst;
	//
	//
	//			stableStat = new StableStatistics_Flat (0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
	//			StatusEffectVariables.SetOwner (this);
	//			statistics = new CompiledStatistics (BaseStat, stableStat);
	//		}

	//
	public void Awake ()
	{
//		component = new Blossom (this);
//		moveCommands = new List<MovementCommand> ();
	}

	//
	public void Update ()
	{
//		if (Update_Handler != null)
//			Update_Handler ();

	}

	#endregion
}
*/