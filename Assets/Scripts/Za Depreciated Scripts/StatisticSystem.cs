// using UnityEngine;
// using UnityEngine.Events;
// using System.Collections;
// using System.Collections.Generic;

//using ItemSystem;
/*
namespace StatisticSystem
{

	public class IValue
	{
		public delegate int  Value_Int ();

		public delegate float Value_Float ();

		public delegate bool Value_Bool ();

	}


	public class Return_Float_Compare: IValue
	{

		private Value_Float FloatsOne, FloatsTwo;

		public bool Return ()
		{
			return FloatsOne () == FloatsTwo () ? true : false;
		}

		public Return_Float_Compare (Value_Float val1, Value_Float val2)
		{
			FloatsOne = val1;
			FloatsTwo = val2;

		}
	}

	public class Return_Int_Compare: IValue
	{

		private Value_Int IntsOne, IntsTwo;

		public bool Return ()
		{
			return IntsOne () == IntsTwo () ? true : false;
		}

		public Return_Int_Compare (Value_Int val1, Value_Int val2)
		{
			IntsOne = val1;
			IntsTwo = val2;

		}
	}

	public class Return_Float : IValue
	{


		private Value_Float Floats;



		public Return_Float (Value_Float val)
		{
			Floats = val;
		}




		public float Return ()
		{
			return Floats ();
		}

	}

	public class Return_Bool : IValue
	{


		private Value_Bool Bools;



		public Return_Bool (Value_Bool val)
		{
			Bools = val;
		}

		public bool Return ()
		{
			return Bools ();
		}

	}

	public class Return_Int : IValue
	{


		private Value_Int Ints;

		public int Return ()
		{
			return Ints ();
		}

		public Return_Int (Value_Int val)
		{
			Ints = val;
		}


	}








	public class ProfileValue
	{
		/// <summary>
		/// The value. from 0.0 to 1.0.
		/// </summary>
		public float? value;
		//		public CompiledStatistics Stat;
		// public Optimizations.Types type;

		public static Builder Initialize ()
		{
			Builder temp = new Builder ();
			temp.create = new ProfileValue ();
			return temp;
		}

		public class Builder
		{
			public ProfileValue create;


			public Builder Define_Value (float val)
			{
				create.value = val;
				// create.type = Optimizations.Types.None;
//				create.Stat = null;
				return this;
			}

			//			public Builder Define_Statistic_And_Type (CompiledStatistics val, Optimizations.Types type)
			//			{
			//				create.value = null;
			//				create.type = type;
			//				create.Stat = val;
			//				return this;
			//			}

			public ProfileValue Declare ()
			{
				return create;
			}
		}
	}





	/*
	//
	public class Optimizations
	{
		public enum Types
		{
			None,
			Endurance,
			Tenacity,
			Diffuse,
			Exertion,
			Brilliance,
			Dexterity,
			Constitution,
			Vigor,
			Recovery
		}

		public float Endurance, Tenacity, Diffuse;
		public float Exertion, Brilliance, Dexterity;
		public float Constitution, Vigor, Recovery;

		public class Builder
		{
			Optimizations stat;

			public static Builder Create ()
			{
				return new Builder ();
			}

			public Builder SetConstitution (float val)
			{
				stat.Constitution = val;
				return this;
			}

			public Builder SetVigor (float val)
			{
				stat.Vigor = val;
				return this;

			}

			public Builder SetRecovery (float val)
			{
				stat.Recovery = val;
				return this;

			}

			public Builder SetExertion (float val)
			{
				stat.Exertion = val;
				return this;
			}

			public Builder SetBrilliance (float val)
			{
				stat.Brilliance = val;
				return this;

			}

			public Builder SetDexterity (float val)
			{
				stat.Dexterity = val;
				return this;

			}


			public Optimizations Finialize ()
			{
				return stat;
			}
		}
	}
/*
	/// <summary>
	/// Base statistics for State based objects.
	/// </summary>
	public class BaseStatistic
	{
		
		public Optimizations opt;

		public float Endurance {
			get {
				return opt.Endurance;
			}
		}

		public float Tenacity {
			get {
				return opt.Tenacity;
			}
		}

		public float Diffuse {
			get {
				return opt.Diffuse;
			}
		}

		public float Exertion {
			get {
				return opt.Exertion;
			}
		}

		public float Brilliance {
			get {
				return opt.Brilliance;
			}
		}

		public float Dexterity {
			get {
				return opt.Dexterity;
			}
		}

		public float Constitution {
			get {
				return opt.Constitution;
			}
		}

		public float Vigor {
			get {
				return opt.Vigor;
			}
		}

		public float Recovery {
			get {
				return opt.Recovery;
			}
		}


		public float ResolveUtilization, MettleUtilization, VitalityUtilization;


		public int Health;
		public float OverShieldPercent, ArmorShieldPercent;

		public int OverShield {
			get {
				return Mathf.RoundToInt (Health * OverShieldPercent);
			}
		}

		public int ArmorShield {
			get {
				return Mathf.RoundToInt (Health * ArmorShieldPercent);
			}
		}

		public float MoveSpeed, JumpHeight;

		public class Builder
		{
			BaseStatistic stat;
			public float Endurance, Tenacity, Diffuse;
			public float Exertion, Brilliance, Dexterity;
			public float Constitution, Vigor, Recovery;

			public static Builder Declare ()
			{
				return new Builder ();
			}

			public Builder Define_Constitution_Vigor_Recovery (float valC, float valV, float valR)
			{
//				stat;
				Constitution = valC;
				Vigor = valV;
				Recovery = valR;
				return this;
			}


			public Builder Define_Exertion_Briliance_Dexterity (float valE, float valB, float valD)
			{
				Exertion = valE;
				Brilliance = valB;
				Dexterity = valD;
				return this;
			}

			public Builder Define_Endurance_Tenacity_Diffuse (float valE, float valT, float valD)
			{
				Endurance = valE;
				Tenacity = valT;
				Diffuse = valD;
				return this;

			}

			public Builder Define_Resolve_Vitality_Mettle_Utilization (float valR, float valV, float valM)
			{
				stat.ResolveUtilization = valR;
				stat.VitalityUtilization = valV;
				stat.MoveSpeed = valM;
				return this;

			}

			public Builder Define_Move_And_Jump_Speed (float valM, float valJ)
			{
				stat.MoveSpeed = valM;
				stat.JumpHeight = valJ;
				return this;

			}

			public Builder Define_Health (int val)
			{
				stat.Health = val;
				return this;

			}

			public Builder Define_Armor_And_Over_Shield_Percent (float valO, float valA)
			{
				stat.OverShieldPercent = valO;
				stat.ArmorShieldPercent = valA;
				return this;

			}

			public BaseStatistic Initialize ()
			{
				return stat;
			}
		}
	}
	

	/// <summary>
	/// Stable statistic.
	/// </summary>
	public struct StableStatistic
	{
		public string ID;
		public float Constitution, Vigor, Recovery;
		public float Exertion, Brilliance, Dexterity;
		public float Endurance, Tenacity, Diffuse;


		public class Builder
		{
			StableStatistic Stable;

			public static Builder Create ()
			{
				return new Builder ();
			}

			//			public Builder SetMettle (MettleSubStatistics will)
			//			{
			//				Stable.Exertion = will.Exertion;
			//				Stable.Brilliance = will.Brilliance;
			//				Stable.Dexterity = will.Dexterity;
			//				return this;
			//			}
			//
			//			public Builder SetResolve (ResolveSubStatistics res)
			//			{
			//				Stable.Endurance = res.Endurance;
			//				Stable.Tenacity = res.Tenacity;
			//				Stable.Diffuse = res.Diffuse;
			//				return this;
			//			}
			//
			//			public Builder SetVitality (VitalitySubStatistics vit)
			//			{
			//				Stable.Constitution = vit.Constitution;
			//				Stable.Vigor = vit.Vigor;
			//				Stable.Recovery = vit.Recovery;
			//				return this;
			//			}

			public StableStatistic Finialize (string id)
			{
				Stable.ID = id;
				return this.Stable;
			}
		}
	}

	/// <summary>
	/// Unstable statistic.
	/// </summary>
	public class UnstableStatistic
	{
		Dictionary<string, StableStatistic> Stables;
		float constitution, vigor, recovery, exertion, brilliance, dexterity, endurance, tenacity, diffuse;
		//Statistics

		#region

		public float Constitution {
			get {
				return constitution;
			}
		}

		public float Vigor {
			get {
				return vigor;
			}
		}

		public float Recovery {
			get {
				return recovery;
			}
		}

		public float Exertion {
			get {
				return exertion;
			}
		}

		public float Brilliance {
			get {
				return brilliance;
			}
		}

		public float Dexterity {
			get {
				return dexterity;
			}
		}

		public float Endurance {
			get {
				return endurance;
			}
		}

		public float Tenacity {
			get {
				return tenacity;
			}
		}

		public float Diffuse {
			get {
				return diffuse;
			}
		}

		#endregion

		public void Add (StableStatistic stable)
		{
			Stables.Add (stable.ID, stable);

			constitution += stable.Constitution;
			vigor += stable.Vigor;
			recovery += stable.Recovery;

			exertion += stable.Exertion;
			brilliance += stable.Brilliance;
			dexterity += stable.Dexterity;

			endurance += stable.Endurance;
			tenacity += stable.Tenacity;
			diffuse += stable.Diffuse;


		}

		public void Remove (string id)
		{
			StableStatistic stable = new StableStatistic ();
			Stables.TryGetValue (id, out stable);
			Stables.Remove (id);

			constitution -= stable.Constitution;
			vigor -= stable.Vigor;
			recovery -= stable.Recovery;

			exertion -= stable.Exertion;
			brilliance -= stable.Brilliance;
			dexterity -= stable.Dexterity;

			endurance -= stable.Endurance;
			tenacity -= stable.Tenacity;
			diffuse -= stable.Diffuse;


		}

	}

	public struct CharacterStatistic
	{
		public int BaseHealth, BaseShield, BaseShieldTier;
		public float BaseMoveSpeed, BaseJump_Height;
		public Return_Float HealthImprovement, ShieldImprovement;
		public Return_Float MoveSpeedImprovement, Jump_HeightImprovement;

		public int MaxHealth {
			get {
				return Mathf.RoundToInt (BaseHealth * HealthImprovement.Return ()) + BaseHealth;
			}
		}

		public int MaxShield {
			get {
				return Mathf.RoundToInt (BaseShield * ShieldImprovement.Return ()) + BaseShield;
			}
		}

		//		public int MaxArmor {
		//			get {
		//				return Mathf.RoundToInt (BaseArmor * ArmorImprovement.Return ()) + BaseArmor;
		//			}
		//		}

		public float MaxMoveSpeed {
			get {
				return (BaseMoveSpeed * MoveSpeedImprovement.Return ()) + BaseMoveSpeed;
			}
		}

		public float MaxJump_Height {
			get {
				return (BaseJump_Height * Jump_HeightImprovement.Return ()) + BaseJump_Height;
			}
		}


		public class Builder
		{
			CharacterStatistic stat;

			public static Builder Create ()
			{
				return new Builder ();
			}

			public Builder SetHealth (int val)
			{
				stat.BaseHealth = val;
				return this;
			}

			public Builder SetShield (int val)
			{
				stat.BaseShield = val;
				return this;

			}

			//			public Builder SetArmor (int val)
			//			{
			//				stat.BaseArmor = val;
			//				return this;
			//
			//			}

			public Builder SetMoveSpeed (float val)
			{
				stat.BaseMoveSpeed = val;
				return this;
			}

			public Builder SetJumpHeight (float val)
			{
				stat.BaseJump_Height = val;
				return this;

			}
			public Builder SetHealth_Improvement (Return_Float val)
			{
				stat.HealthImprovement = val;
				return this;
			}

			public Builder SetShield_Improvement (Return_Float val)
			{
				stat.ShieldImprovement = val;
				return this;

			}

			//			public Builder SetArmor_Improvement (IValue.Value_Float val)
			//			{
			//				stat.ArmorImprovement = new Return_Float (val);
			//				return this;
			//
			//			}

			public Builder SetMoveSpeed_Improvement (Return_Float val)
			{
				stat.MoveSpeedImprovement = val;
				return this;
			}

			public Builder SetJumpHeight_Improvement (Return_Float val)
			{
				stat.Jump_HeightImprovement = val;
				return this;

			}




			public CharacterStatistic Finialize ()
			{
				return stat;
			}
		}
	}

	/// <summary>
	/// Stat addition.
	/// </summary>
	public struct StatAddition
	{
		public float Constitution, Vigor, Recovery, Exertion, Brilliance, Dexterity, Endurance, Tenacity, Diffuse;
		//		publ float Vitality, Mettle, Resolve;
	}

	public abstract class StatController
	{
		public struct statStable
		{
			
		}

		float baseVal;

		//		public float baseCompiledVal ()
		//		{
		//
		//		}
		//		//
		//		public float augmentedCompiledVal ()
		//		{
		//
		//		}
		//Compiled Stat with top stats
		List<statStable> baseAdditions;
		List<statStable> toppedAdditions;

	}

	public class StatManager
	{
		


	}









	/*
	/// <summary>
	/// Compiled statistics.
	/// </summary>
	public class CompiledStatistics
	{
		//Base and Stable Statistic

		#region

		//		VitalitySubStatistics Vitality_Base;
		//		MettleSubStatistics Will_Base;
		//		ResolveSubStatistics BaseStat;
		UnstableStatistic Stables;
		BaseStatistic BaseStat;
		//		RigItem Rig;

		#endregion

		//Vitality

		#region

		public float Vitality {
			get {
				return (((Constitution + Vigor + Recovery) / 3.0f) * BaseStat.VitalityUtilization) + Rig.VitalityUpgrade;
			}
		}

		public float Constitution {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Constitution + Stables.Constitution, 1);
			}
		}

		public float Constitution_Flux {
			get {
				return BaseStat.Constitution + Stables.Constitution > 1 ? BaseStat.Constitution + Stables.Constitution - 1 : 0;
			}
		}

		public float Vigor {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Vigor + Stables.Vigor, 1);

			}
		}

		public float Vigor_Flux {
			get {
				return BaseStat.Vigor + Stables.Vigor > 1 ? BaseStat.Vigor + Stables.Vigor - 1 : 0; 
			}
		}

		public float Recovery {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Recovery + Stables.Recovery, 1);
			}
		}

		public float Recovery_Flux {
			get {
				return BaseStat.Recovery + Stables.Recovery > 1 ? BaseStat.Recovery + Stables.Recovery - 1 : 0; 
			}
		}

		#endregion

		//Mettle

		#region

		public float Mettle {
			get {
				return ((Exertion + Brilliance + Dexterity) / 3.0f) + Rig.MettleUpgrade;
			}
		}

		public float Exertion {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Exertion + Stables.Exertion, 1);
			}
		}

		public float Exertion_Flux {
			get {
				return BaseStat.Exertion + Stables.Exertion > 1 ? BaseStat.Exertion + Stables.Exertion - 1 : 0;
			}
		}

		public float Brilliance {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Brilliance + Stables.Brilliance, 1);

			}
		}

		public float Brilliance_Flux {
			get {
				return BaseStat.Brilliance + Stables.Brilliance > 1 ? BaseStat.Brilliance + Stables.Brilliance - 1 : 0; 
			}
		}

		public float Dexterity {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Dexterity + Stables.Dexterity, 1);
			}
		}

		public float Dexterity_Flux {
			get {
				return BaseStat.Dexterity + Stables.Dexterity > 1 ? BaseStat.Dexterity + Stables.Dexterity - 1 : 0; 
			}
		}

		#endregion

		//Resolve

		#region

		public float Resolve {
			get {
				return ((Endurance + Tenacity + Diffuse) / 3.0f) + Rig.ResolveUpgrade;
			}
		}

		public float Endurance {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Endurance + Stables.Endurance, 1);
			}
		}

		public float Endurance_Flux {
			get {
				return BaseStat.Endurance + Stables.Exertion > 1 ? BaseStat.Endurance + Stables.Endurance - 1 : 0;
			}
		}

		public float Tenacity {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Tenacity + Stables.Tenacity, 1);

			}
		}

		public float Tenacity_Flux {
			get {
				return BaseStat.Tenacity + Stables.Tenacity > 1 ? BaseStat.Tenacity + Stables.Tenacity - 1 : 0; 
			}
		}

		public float Diffuse {
			get {
				float temp = 0;
				return BasicFunction.AddTillEqualTo (temp, BaseStat.Diffuse + Stables.Diffuse, 1);
			}
		}

		public float Diffuse_Flux {
			get {
				return BaseStat.Diffuse + Stables.Diffuse > 1 ? BaseStat.Diffuse + Stables.Diffuse - 1 : 0; 
			}
		}

		#endregion

		//Resources

		#region

		public int Health_Max {
			get {
				return BaseStat.Health + Mathf.RoundToInt (BaseStat.Health * Resolve);
			}
		}

		public int Health_Current;

		public int Overshield_Max {
			get {
				return BaseStat.OverShield + Mathf.RoundToInt (BaseStat.Health * Resolve);
			}
		}

		public int Armorshield_Max {
			get {
				return BaseStat.ArmorShield + Mathf.RoundToInt (BaseStat.Health * Resolve);
			}
		}

		public int Overshield_Current, Armorshield_Current;

		#endregion

		#region

		public class Builder
		{
			CompiledStatistics Comp;

			public static Builder Create ()
			{
				return new Builder ();
			}

			//			public Builder SetWill (MettleSubStatistics will)
			//			{
			//				Comp.Will_Base = will;
			//				return this;
			//			}
			//
			//			public Builder SetResolve (ResolveSubStatistics res)
			//			{
			//				Comp.BaseStat = res;
			//				return this;
			//			}
			//
			//			public Builder SetVitality (VitalitySubStatistics vit)
			//			{
			//				Comp.Vitality_Base = vit;
			//				return this;
			//			}
			//			public Builder SetStable(VitalityStat vit){
			////				Stable.Constitution = vit.Constitution;
			////				Stable.Vigor = vit.Vigor;
			////				Stable.Recovery = vit.Recovery;
			//				return this;
			//			}
			public CompiledStatistics Finialize ()
			{
				return this.Comp;
			}

		}

		#endregion
	}
	*/

	/*
	OBS
	public class VitalitySubStatistics
	{
		public float Constitution, Vigor, Recovery;

		public class Builder
		{
			VitalitySubStatistics vit;

			public static Builder Create ()
			{
				return new Builder ();
			}

			public static VitalitySubStatistics Create (float consti, float vigor, float recovery)
			{
				VitalitySubStatistics vit = new VitalitySubStatistics ();
				vit.Constitution = consti;
				vit.Vigor = vigor;
				vit.Recovery = recovery;
				return vit;
			}

			public Builder SetConstitution (float val)
			{
				vit.Constitution = val;
				return this;
			}

			public Builder SetVigor (float val)
			{
				vit.Vigor = val;
				return this;

			}

			public Builder SetRecovery (float val)
			{
				vit.Recovery = val;
				return this;

			}

			public VitalitySubStatistics Finialize ()
			{
				return vit;
			}
		}
	}

	public class MettleSubStatistics
	{
		public float Exertion, Brilliance, Dexterity;

		public class Builder
		{
			MettleSubStatistics vit;

			public static Builder Create ()
			{
				return new Builder ();
			}

			public static MettleSubStatistics Create (float ValE, float ValB, float ValD)
			{
				MettleSubStatistics vit = new MettleSubStatistics ();
				vit.Exertion = ValE;
				vit.Brilliance = ValB;
				vit.Dexterity = ValD;
				return vit;
			}

			public Builder SetExertion (float val)
			{
				vit.Exertion = val;
				return this;
			}

			public Builder SetBrilliance (float val)
			{
				vit.Brilliance = val;
				return this;

			}

			public Builder SetDexterity (float val)
			{
				vit.Dexterity = val;
				return this;

			}

			public MettleSubStatistics Finialize ()
			{
				return vit;
			}
		}
	}

	public class ResolveSubStatistics
	{
		public float Endurance, Tenacity, Diffuse;

		public class Builder
		{
			ResolveSubStatistics vit;

			public static Builder Create ()
			{
				return new Builder ();
			}

			public static ResolveSubStatistics Create (float endur, float tena, float diff)
			{
				ResolveSubStatistics vit = new ResolveSubStatistics ();
				vit.Endurance = endur;
				vit.Tenacity = tena;
				vit.Diffuse = diff;
				return vit;
			}

			public Builder SetConstitution (float val)
			{
				vit.Endurance = val;
				return this;
			}

			public Builder SetVigor (float val)
			{
				vit.Tenacity = val;
				return this;

			}

			public Builder SetRecovery (float val)
			{
				vit.Diffuse = val;
				return this;

			}

			public ResolveSubStatistics Finialize ()
			{
				return vit;
			}
		}
	}
//	[System.Serializable]
//	public class BaseOptimization
//	{
//		public readonly float Over_Shield;
//		public readonly int Health;
//
//		public readonly float Recovery;
//		public readonly float Endurance;
//
//
//		public readonly float Exertion;
//		public readonly float Brilliance;
//		public readonly float Mastery;
//		//
//		public readonly float Reaction;
//		public readonly float Mobility;
//		public readonly float Tenacity;
//		//
//		public readonly float Jump_Height;
//		public readonly float Move_Speed;
//		//
//
//
//		public BaseOptimization (float over_shield, float recovery, float def, int health, float dyn, float intelligence, 
//		                         float dex, float mob, float jh, float hpRegen, float move, float jump)
//		{
//			Over_Shield = over_shield;
//			Recovery = recovery;
//			Endurance = def;
//			Health = health;
//
//			Exertion = dyn;
//			Brilliance = intelligence;
//			Mastery = dex;
//
//			Mobility = mob;
//			Tenacity = jh;
//			Reaction = hpRegen;
//
//			Move_Speed = move;
//			Jump_Height = jump;
//		}
//
//		private BaseOptimization ()
//		{
//		}
//	}

	OBS
	public class BaseOptimizationMutators{
		public readonly OptimizationMutator Over_Shield;
		public readonly OptimizationMutator Recovery;
		public readonly OptimizationMutator Endurance;


		public readonly OptimizationMutator Exertion;
		public readonly OptimizationMutator Brilliance;
		public readonly OptimizationMutator Mastery;
		//
		public readonly OptimizationMutator Reaction;
		public readonly OptimizationMutator Mobility;
		public readonly OptimizationMutator Tenacity;
		//
		public readonly OptimizationMutator Jump_Height;
		public readonly OptimizationMutator Move_Speed;
		//

		/// <summary>
		/// Initializes a new instance of the <see cref="StatisticSystem.BaseOptimization"/> class.
		/// </summary>
		/// <param name="opt">Opt.</param>
		public BaseOptimizationMutators (OptimizationMutator opt1,OptimizationMutator opt2,OptimizationMutator opt3,OptimizationMutator opt4,OptimizationMutator opt5,OptimizationMutator opt6,OptimizationMutator opt7,OptimizationMutator opt8,OptimizationMutator opt9,OptimizationMutator opt10){
			Over_Shield = opt1;
			Recovery = opt2;
			Endurance = opt3;
			Exertion = opt4;
			Brilliance = opt5;
			Mastery = opt6;
			Reaction = opt7;
			Mobility = opt8;
			Jump_Height = opt9;
			Move_Speed = opt10;
		}
		private BaseOptimizationMutators (){
		}
	}

	//
	public class OptimizationMutator{
		public enum Stats{
			None = 0,
			Over_Shield = 1,
			Recovery = 2,
			Defense = 3,
			Exertion = 4,
			Brilliance = 5,
			Mastery = 6,
			Reaction = 7,
			Mobility = 8,
			Tenacity = 9
		}
		public Stats Stat;
		//
		public readonly float Resistance;
		//
		public float ValueReturned(StableOptimizationProfile stat){
			float value = 0;
			switch (Stat) {
			case Stats.Defense:
				value = stat.Defense;
				break;
			case Stats.Reaction:
				value = stat.Reaction;
				break;
			case Stats.Recovery:
				value = stat.Recovery;
				break;
			case Stats.Brilliance:
				value = stat.Brilliance;                
				break;
			case Stats.Mastery:
				value = stat.Mastery;
				break;
			case Stats.Exertion:
				value = stat.Exertion;
				break;
			case Stats.Mobility:
				value = stat.Mobility;
				break;
			case Stats.Tenacity:
				value = stat.Tenacity;
				break;
			case Stats.Over_Shield:
				value = stat.Over_Shield;
				break;
			}
			return value * Resistance;
		}

		public OptimizationMutator (Stats resisted, float resistance){
			Stat = resisted;
			Resistance = resistance;
		}
		public OptimizationMutator (){
			Stat = Stats.Brilliance;
			Resistance = 0;
		}
	}

	//
	[System.Serializable]
	public class CompiledOptimizationProfile{
		public BaseOptimization baseStat;
		public BaseOptimizationMutators baseOptimization;
		public StableOptimizationProfile stableOptimization;
		
		public float Over_Shield{
			get{
//				return 1;
				return baseStat.Over_Shield + (baseStat.Over_Shield * baseOptimization.Over_Shield.ValueReturned(stableOptimization));
			}
		}
		public int Max_Shield{
			get {
				return Mathf.RoundToInt((Over_Shield * Max_Health));
			}
		}
		int shield;
		public int Current_Shield{
			get{
				return shield;
			}
			set{
				if(value > 0)
					shield = shield - value > 0 ? shield : 0;
				if(value <= Max_Shield)
					shield = shield + value >= Max_Shield ? Max_Shield : shield;
			}
		}


		public float Endurance{
			get{
				return baseStat.Endurance + (baseStat.Endurance * baseOptimization.Endurance.ValueReturned(stableOptimization));
			}
		}

		//
		public int Max_Health{
			get{
				return baseStat.Health;
			}
		}
		int hp;
		public int Current_Health{
			get{
				return hp;
			}
			set{
				if(value > 0)
					hp = hp - value > 0 ? hp : 0;
				if(value <= Max_Health)
					hp = hp + value >= Max_Health ? Max_Health : hp;
			}
		}

	
		//
		public float Brilliance {
			get {
				return baseStat.Move_Speed + baseStat.Brilliance * baseOptimization.Brilliance.ValueReturned(stableOptimization);
			}
		}
		public float Mastery {
			get {
				return baseStat.Move_Speed + baseStat.Mastery * baseOptimization.Mastery.ValueReturned(stableOptimization);
			}
		} 
		public float Exertion {
			get {
				return baseStat.Exertion + (baseStat.Exertion * baseOptimization.Exertion.ValueReturned(stableOptimization));
			}
		}
		//
		public float Mobility {
			get {
				return baseStat.Mobility + (baseStat.Mobility * baseOptimization.Mobility.ValueReturned(stableOptimization));
			}
		}
		public float Reaction {
			get {
				return baseStat.Reaction + (baseStat.Reaction * baseOptimization.Reaction.ValueReturned(stableOptimization));
			}
		}
		public float Recovery {
			get {
				return baseStat.Recovery + (baseStat.Recovery * baseOptimization.Recovery.ValueReturned(stableOptimization));
			}
		}
		public float Tenacity{
			get{
				return baseStat.Tenacity + (baseStat.Tenacity * baseOptimization.Tenacity.ValueReturned(stableOptimization));
				}
		}
		public float Jump_Height{
			get{
				return baseStat.Jump_Height + (baseStat.Jump_Height * baseOptimization.Jump_Height.ValueReturned(stableOptimization));
			}
		}
		public float Move_Speed{
			get{
				return baseStat.Move_Speed + (baseStat.Move_Speed * baseOptimization.Move_Speed.ValueReturned(stableOptimization));
			}
		}


		public CompiledOptimizationProfile(BaseOptimization bs, StableOptimizationProfile sts, BaseOptimizationMutators bopt){
			baseStat = bs;
			stableOptimization = sts;
			baseOptimization = bopt;
			shield = Max_Shield;

		}



	}

	//
	[System.Serializable]
	public class StableOptimizationProfile{

		public readonly float Over_Shield;
		public readonly float Recovery;

		public readonly float Defense;


		public readonly float Exertion;
		public readonly float Brilliance;
		public readonly float Mastery;
		//
		public readonly float Reaction;
		public readonly float Mobility;
		public readonly float Tenacity;



		//
		public StableOptimizationProfile(float shield, float recovery, float defense, float str, float intel, float dex, float reflex, float mobil, float tenac){
			Over_Shield = shield;
			Recovery = recovery;
			Defense = defense;

			Exertion = str;
			Brilliance = intel;
			Mastery = dex;

			Reaction = reflex;
			Mobility = mobil;
			Tenacity = tenac;
		}

		//
		public static StableOptimizationProfile operator +(StableOptimizationProfile one, StableOptimizationProfile two) 
		{
			return new StableOptimizationProfile(one.Over_Shield + two.Over_Shield, 
				one.Recovery + two.Recovery, 
				one.Defense + two.Defense,
				one.Exertion + two.Exertion,
				one.Brilliance + two.Brilliance,
				one.Mastery + two.Mastery,
				one.Reaction + two.Reaction,
				one.Mobility + two.Mobility,
				one.Tenacity + two.Tenacity);
		}

		//
		public static StableOptimizationProfile operator -(StableOptimizationProfile one, StableOptimizationProfile two) 
		{
			return new StableOptimizationProfile(one.Over_Shield - two.Over_Shield, 
				one.Recovery - two.Recovery, 
				one.Defense - two.Defense,
				one.Exertion - two.Exertion,
				one.Brilliance - two.Brilliance,
				one.Mastery - two.Mastery,
				one.Reaction - two.Reaction,
				one.Mobility - two.Mobility,
				one.Tenacity - two.Tenacity);
		}
	}

//	[System.Serializable]
//	public class StableStatistics_Percent{
//		public float STRadiationResistance;
//		public float STQuantumProtection;
//		public float STMechanicalBuffer;
//		//
//		public int STShieldTier;
//		public float STShieldPercent;
//		public int STArmor;
//		//
//		public float STSteeledChance;
//		public float STRendingChance;
//		//
//		public float STEssenceTheft;
//		public float STHealthRegen;
//		public float STShieldRecoveryDelay;
//		public float STRecovery;
//		public float STReaction;
//		public float STMobility;
//		//
//		public float STRadiationIngression;
//		public int STRadiationPotential;
//		public float STQuantumSeepage;
//		public int STQuantumCharge;
//		public float STMechanicalPenetration;
//		public int STMechanicalExertion;
//		//
//		public StableStatistics_Percent(float ED, float QR, float KA, int ST,
//			float SP, int A, float SC, float RC, 
//			float LS, float HR, float SD, float FL, 
//			float RF, float MO, float EI, int EP, 
//			float QS, int QC, float KP, int KD){
//
//			STRadiationResistance = ED;
//			STQuantumProtection = QR;
//			STMechanicalBuffer = KA;
//
//			STShieldTier = ST;
//			STShieldPercent = SP;
//			STArmor = A;
//
//			STSteeledChance = SC;
//			STRendingChance = RC;
//			STEssenceTheft = LS;
//			STHealthRegen = HR;
//			STShieldRecoveryDelay = SD;
//			STRecovery = FL;
//			STReaction = RF;
//			STMobility = MO;
//			STRadiationIngression = EI;
//			STRadiationPotential = EP;
//			STQuantumSeepage = QS;
//			STQuantumCharge = QC;
//			STMechanicalPenetration = KP;
//			STMechanicalExertion = KD;
//
//		}
//
//		//
//		public static StableStatistics_Percent operator +(StableStatistics_Percent one, StableStatistics_Percent two) 
//		{
//			return new StableStatistics_Percent(one.STRadiationResistance + two.STRadiationResistance, 
//				one.STQuantumProtection + two.STQuantumProtection, 
//				one.STMechanicalBuffer + two.STMechanicalBuffer,
//				one.STShieldTier + two.STShieldTier,
//				one.STShieldPercent + two.STShieldPercent,
//				one.STArmor + two.STArmor,
//				one.STSteeledChance + two.STSteeledChance,
//				one.STRendingChance + two.STRendingChance,
//				one.STEssenceTheft + two.STEssenceTheft,
//				one.STHealthRegen + two.STHealthRegen,
//				one.STShieldRecoveryDelay + two.STShieldRecoveryDelay,
//				one.STRecovery + two.STRecovery,
//				one.STReaction + two.STReaction,
//				one.STMobility + two.STMobility,
//				one.STRadiationIngression + two.STRadiationIngression,
//				one.STRadiationPotential + two.STRadiationPotential,
//				one.STQuantumSeepage + two.STQuantumSeepage,
//				one.STQuantumCharge + two.STQuantumCharge,
//				one.STMechanicalPenetration + two.STMechanicalPenetration,
//				one.STMechanicalExertion + two.STMechanicalExertion);
//		}
//
//		//
//		public static StableStatistics_Percent operator -(StableStatistics_Percent one, StableStatistics_Percent two) 
//		{
//			return new StableStatistics_Percent(one.STRadiationResistance - two.STRadiationResistance, 
//				one.STQuantumProtection - two.STQuantumProtection, 
//				one.STMechanicalBuffer - two.STMechanicalBuffer,
//				one.STShieldTier - two.STShieldTier,
//				one.STShieldPercent - two.STShieldPercent,
//				one.STArmor - two.STArmor,
//				one.STSteeledChance - two.STSteeledChance,
//				one.STRendingChance - two.STRendingChance,
//				one.STEssenceTheft - two.STEssenceTheft,
//				one.STHealthRegen - two.STHealthRegen,
//				one.STShieldRecoveryDelay - two.STShieldRecoveryDelay,
//				one.STRecovery - two.STRecovery,
//				one.STReaction - two.STReaction,
//				one.STMobility - two.STMobility,
//				one.STRadiationIngression - two.STRadiationIngression,
//				one.STRadiationPotential - two.STRadiationPotential,
//				one.STQuantumSeepage - two.STQuantumSeepage,
//				one.STQuantumCharge - two.STQuantumCharge,
//				one.STMechanicalPenetration - two.STMechanicalPenetration,
//				one.STMechanicalExertion - two.STMechanicalExertion);
//		}
//	}
//

*/

	// /// <summary>
	// /// State status.
	// /// </summary>
	// [System.Serializable]
	// public struct StateStatus
	// {
	// 	public bool Rending;
	// 	public bool Steeled;
	// 	//
	// 	public bool Shield_Shattered;
	// 	//
	// 	public bool Armor_Shatter {
	// 		get {
	// 			return true;
	// 		}
	// 	}

	// 	public bool Out_Of_Health {
	// 		get {
	// 			return true;
	// 		}
	// 	}

	// 	public bool Paused;


	// 	public bool Invincible;
	// 	public bool Immune_To_Status_Efects;

	// 	public bool? Moving;
	// 	public bool Levitating;
	// 	public bool Immobile;

	// 	public bool Invisible;
	// }

	// /// <summary>
	// /// Controller status.
	// /// </summary>
	// [System.Serializable]
	// public struct ControllerStatus
	// {
	// 	public bool In_Tactic_Mobile, In_Tactic_Immobile, In_Tactic_Stasis, In_Tactic_Invincible;

	// 	public bool In_Tactic {
	// 		get {
	// 			return (In_Tactic_Mobile || In_Tactic_Immobile || In_Tactic_Stasis || In_Tactic_Invincible);
	// 		}
	// 	}

	// 	public bool Weapon_Spree;
	// 	public bool Character_Cant_Rotate;
	// }

	// /// <summary>
	// /// Status effects. Holds Status Effects and variables relating to their implementation.
	// /// </summary>
	// /// 
	// /*
	// [System.Serializable]
	// public struct StatusEffects
	// {
	// 	#region

	// 	Dictionary<IStatusEffect, IState> statusEffectsList;

	// 	public Dictionary<IStatusEffect, IState> StatusEffectsList {
	// 		get {
				
	// 			return statusEffectsList;
	// 		}
	// 	}

	// 	IState Owner;

	// 	int BlindnessCount;
	// 	int DazeCount;
	// 	int DefenseBypassCount;
	// 	int DefenseSuppressionCount;
	// 	int KnockDownCount;
	// 	int CoordinationBlockCount;
	// 	int NeutralizeCount;
	// 	int DeaccelerateCount;
	// 	int SnareCount;
	// 	int StaggerCount;
	// 	int StrikeCount;
	// 	int NeutralizeCount;
	// 	int SurgeCount;
	// 	int SuppressCount;

	// 	float slowValue;
	// 	float blindnessValue;
	// 	float dazeValue;
	// 	float defenseSuppressValue;
	// 	float strikeValue;
	// 	Vector3 strikeDirection;

	
	// 	 * Blindness
	// 	 * Daze
	// 	 * DefenseBypass
	// 	 * DefenseSurpression
	// 	 * KnockDown
	// 	 * CoordinationBlock
	// 	 * Neutralize
	// 	 * Deaccelerate
	// 	 * Snare
	// 	 * Stagger
	// 	 * Strike
	// 	 * Neutralize
	// 	 * Surge
	// 	 * Suppress
	// 	 *


		// public void SetOwner (IState owns)
		// {
		// 	Owner = owns;
		// }

		/*
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







		public bool isDeaccelerate {
			get {
				return DeaccelerateCount > 0;
			}
		}

		public bool isDefense_Supression {
			get {
				return DefenseSuppressionCount > 0;
			}
		}

		public bool isDaze {
			get {
				return DazeCount > 0;
			}
		}

		public bool isBlindness {
			get {
				return BlindnessCount > 0;
			}
		}

		#endregion

		/*
		 * 
		 *

		#region

		public float Deaccelerate_Value {

			get {
				return slowValue;
			}
		}

		public float Defense_Supression_Value {
			get {
				return defenseSuppressValue;
			}
		}

		public float Daze_Value {
			get {
				return dazeValue;
			}
		}

		public float Blindness_Value {
			get {
				return blindnessValue;
			}
		}

		#endregion

		/* 
		 * 
		 *

		#region

		public bool isStrike {
			get {
				return StrikeCount > 0;
			}
		}

		public float Strike_Value {
			get {
				return strikeValue;
			}
		}

		public Vector3 Strike_Direction {
			get {
				return strikeDirection;
			}
		}


		#endregion

		/*
		 * 
		 *
		#region

		public bool isSnare {
			get {
				return SnareCount > 0;
			}
		}

		public bool isNeutralize {
			get {
				return NeutralizeCount > 0;
			}
		}

		public bool isDefense_Bypass {
			get {
				return DefenseBypassCount > 0;
			}
		}

		public bool isCoordinationBlock {
			get {
				return CoordinationBlockCount > 0;
			}
		}

		public bool isNeutralize {
			get {
				return NeutralizeCount > 0;
			}
		}

		public bool isKnock_Down {
			get {
				return KnockDownCount > 0;
			}
		}

		#endregion


		public StatusEffects (IState state)
		{
			Owner = state;

			statusEffectsList = new Dictionary<IStatusEffect, IState> ();


			BlindnessCount = 0;
			DazeCount = 0;
			DefenseBypassCount = 0;
			DefenseSuppressionCount = 0;
			KnockDownCount = 0;
			CoordinationBlockCount = 0;
			NeutralizeCount = 0;
			DeaccelerateCount = 0;
			SnareCount = 0;
			StaggerCount = 0;
			StrikeCount = 0;
			NeutralizeCount = 0;
			SurgeCount = 0;
			SuppressCount = 0;

			slowValue = 0;
			blindnessValue = 0;
			dazeValue = 0;
			defenseSuppressValue = 0;
			strikeValue = 0;
			strikeDirection = Vector3.zero;
		}
	}
	

	[System.Serializable]
	public struct StatusEffectManager
	{
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
		//			= new List<StatusEffectPacket> ();

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
		 */


		//		public void SetOwner (IState owns)
		//		{
		//			Owner = owns;
		//		}

		/*
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

		#endregion



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


		#region

		

		#endregion





		public void Refresh ()
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
				keyval.Duration = MyMathFunctions.SubtractTillZero (keyval.Duration, Time.deltaTime);
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

		//		public StatusEffectManager ()
		//		{
		//
		//		}
	}
}
*/