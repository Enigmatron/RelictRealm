/*
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
// using StatisticSystem;
// using Damage;

public abstract class HealthComponent : MonoBehaviour, IEventSystemHandler
{
	EntityState state;

	// public void Spawn ()
	// {
		
	// }



	 public int this [LifeAccessor i] {
		get {
			int temp = 0;
			switch (i) {
			case LifeAccessor.CurrentHealth:
				temp = Life.Health;
				break;
			case LifeAccessor.CurrentShield:
				temp = Life.ShieldComp;

				break;
			case LifeAccessor.MaxHealth: 
				temp = Life.MaxHealth;
				break;
			case LifeAccessor.MaxShield:
				temp = Life.MaxShieldPerTier * Life.ShieldTiers;
				break;
			}
			return temp;
		}
	}
	


	float BaseShieldRecoveryPercentPerSecond;
	int shieldTiers;

	public int ShieldTiers {
		get {
			return shieldTiers;
		}
	}

	int BaseSP;
	// Return_Float ShieldIncrease;

	public int MaxShieldPerTier {
		get {
			float temp = 1;
			// if (ShieldIncrease != null)
			// 	temp += ShieldIncrease.Return ();
			return	Mathf.RoundToInt (BaseSP * temp) / (shieldTiers * 2);
		}
	}

	public bool isShieldFull {
		get {
			bool temp = true;
			if (shield.Count == shieldTiers)
				foreach (int i in shield)
					if (i != MaxShieldPerTier)
						temp = false;
			return temp;
		}
	}

	List<float> shield;

	private static int ConvertIntToFloat (float pf)
	{
		return (int)pf;
	}

	public int[] Shields {
		get {
			return Array.ConvertAll (shield.ToArray (), new Converter<float, int> (ConvertIntToFloat));
		}
	}

	public int ShieldComp {
		get {
			int temp = 0;
			foreach (int i in Shields)
				temp += i;
			return  temp;
		}	
	}

	public bool ShieldShatter {
		get {
			return shield.Count == 0;
		}
	}


	float BaseHealthRecoveryPercentPerSecond;
	int BaseHP;
	// Return_Float HPIncrease;

	public int MaxHealth {
		get {
			float temp = 1;
			// if (HPIncrease != null)
			// 	temp += HPIncrease.Return ();
			return	Mathf.RoundToInt (BaseHP * temp);
		}
	}


	float HP;

	public int Health {
		get {
			return (int)HP;
		}
	}

	public bool isHPFull {
		get {
			return true;
		}
	}


	int LastHPCheckpoint;
	int TemporaryCheckIn;
	int ReconstitutionPotential;
	// Return_Float Constitution;

	public bool isHPReconstituted {
		get {
			return HP == ReconstitutionPotential;
		}
	}



	// Return_Float Recovery;



	float OP;

	public int Overshield {
		get {
			return (int)OP;
		}
	}




	bool InCombat;

	public void EnterCombat ()
	{
		InCombat = true;
		LastHPCheckpoint = TemporaryCheckIn;
	}

	public void LeaveCombat ()
	{
		InCombat = false;
		float temp = 0;
		// if (Constitution != null)
		// 	temp = Constitution.Return ();
		ReconstitutionPotential = (int)((LastHPCheckpoint - Health) * temp);
	}


	public void AddOvershield (float perc)
	{
		OP = MyMathFunctions.AddTillEqualTo (OP, MaxHealth * perc, MaxHealth);

	}



	public void HealAll (float perc)
	{
		if (!isShieldFull) {
			shield [shield.Count - 1] = MyMathFunctions.AddTillEqualTo (shield [shield.Count - 1], MaxShieldPerTier * perc, MaxShieldPerTier);
		} else if (!isHPFull) {
			HP = MyMathFunctions.AddTillEqualTo (HP, MaxHealth * perc, MaxHealth);
			TemporaryCheckIn = (int)HP;

		} else {
			return;
		}

	}

	public void HealAll (int flat)
	{
		if (!isShieldFull) {
			shield [shield.Count - 1] = MyMathFunctions.AddTillEqualTo (shield [shield.Count - 1], flat, MaxShieldPerTier);
		} else if (!isHPFull) {
			HP = MyMathFunctions.AddTillEqualTo (HP, flat, MaxHealth);
			TemporaryCheckIn = (int)HP;
		} else {
			return;
		}
	}

	public void HealShield (float perc)
	{
		if (!isShieldFull) {
			shield [shield.Count - 1] = MyMathFunctions.AddTillEqualTo (shield [shield.Count - 1], MaxShieldPerTier * perc, MaxShieldPerTier);
		} else {
			return;
		}
	}

	public void HealShield (int flat)
	{
		if (!isShieldFull) {
			shield [shield.Count - 1] = MyMathFunctions.AddTillEqualTo (shield [shield.Count - 1], flat, MaxShieldPerTier);
		} else {
			return;
		}
	}

	public void HealHealth (float perc)
	{
		if (!isHPFull) {
			HP = MyMathFunctions.AddTillEqualTo (HP, MaxHealth * perc, MaxHealth);
			TemporaryCheckIn = (int)HP;

		} else {
			return;
		}
	}

	public void HealHealth (int flat)
	{
		if (!isHPFull) {
			HP = MyMathFunctions.AddTillEqualTo (HP, flat, MaxHealth);
			TemporaryCheckIn = (int)HP;

		} else {
			return;
		}
	}

	public void Regen (float deltaTime)
	{
		if (Overshield != 0) {
			// float temp = 1;
		// 	if (Recovery != null)
		// 		temp += Recovery.Return ();
		// 	OP = MyMathFunctions.SubtractTillZero (OP, MaxHealth * BaseShieldRecoveryPercentPerSecond * temp * deltaTime);

		// } else if ((int)shield [shield.Count - 1] != MaxShieldPerTier) {
		// 	float temp = 1;
		// 	if (Recovery != null)
		// 		temp += Recovery.Return ();
		// 	shield [shield.Count - 1] = MyMathFunctions.AddTillEqualTo (shield [shield.Count - 1], MaxShieldPerTier * BaseShieldRecoveryPercentPerSecond * temp * deltaTime, MaxShieldPerTier);
		// } else if (shield.Count != shieldTiers) {
		// 	shield.Add (0);
		// 	float temp = 1;
		// 	if (Recovery != null)
		// 		temp += Recovery.Return ();
		// 	shield [shield.Count - 1] = MyMathFunctions.AddTillEqualTo (shield [shield.Count - 1], MaxShieldPerTier * BaseShieldRecoveryPercentPerSecond * temp * deltaTime, MaxShieldPerTier);
		// }
		// if (HP != ReconstitutionPotential && isShieldFull) {
		// 	float temp = 1;
		// 	if (Recovery != null)
		// 		temp += Recovery.Return ();
		// 	HP = MyMathFunctions.AddTillEqualTo (HP, MaxHealth * BaseHealthRecoveryPercentPerSecond * temp * deltaTime, ReconstitutionPotential);
		// 	TemporaryCheckIn = Health;
		// }
	}
	}




	// public void TakeDamage (int Damage)
	// {
	// 	if (OP != 0) {
	// 		OP = MyMathFunctions.SubtractTillZero (OP, Damage);
	// 	} else if (!ShieldShatter) {
	// 		shield [shield.Count - 1] = MyMathFunctions.SubtractTillZero (shield [shield.Count - 1], Damage);
	// 	} else {
	// 		HP = MyMathFunctions.SubtractTillZero (HP, Damage);
	// 	}
	// 	shield.RemoveAll (x => x == 0);
	// }



}
*/