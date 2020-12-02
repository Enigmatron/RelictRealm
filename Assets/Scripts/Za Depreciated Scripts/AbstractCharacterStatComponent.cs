// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// // using StatisticSystem;

// //using CollectableSystem;
// using Damage;

	
/*
//list of stats
public enum StatAccessor
{
	Resolve,
	Endurance,
	Tenacity,
	Diffuse,
	Mettle,
	Exertion,
	Brilliance,
	Dexterity,
	Vitality,
	Constitution,
	Vigor,
	Recovery,
	MaxJumpHeight,
	MaxMoveSpeed,
	CurrentMoveSpeed,
	CurretJumpHeight,
}


//an abstract profile of a character's stats that should be implemented per character
public abstract class AbstractCharacterStatComponent
{
	


	public int CurrentHealth, CurrentShield;

	// public abstract List<Ability> Abilities {
	// 	get;
	// }

	// public abstract CharacterStatistic BaseStats {
	// 	get;
	// }



	// List<MovementCommand> movementComands;

	// public List<MovementCommand> MovementCommands {
	// 	get {
	// 		return movementComands;
	// 	}
	// }

	// StatusEffectManager statusEffect;

	// public StatusEffectManager StatusEffect {
	// 	get {
	// 		return statusEffect;
	// 	}
	// }

	// public float MoveSpeed {
	// 	get {
	// 		return BaseStats.MaxMoveSpeed + (BaseStats.MaxMoveSpeed * StatusEffect.Accelerate_Value) - (BaseStats.MaxMoveSpeed * StatusEffect.Deaccelerate_Value);
	// 	}
	// }


	public abstract float Health_Return ();

	public abstract float Shield_Return ();

	//	public abstract float Armor_Return ();

	public abstract float MoveSpeed_Return ();

	public abstract float JumpHeight_Return ();

	// public Return_Float Resolve {
	// 	get {
	// 		return new Return_Float (Resolve_Return);

	// 	}
	// }

	public abstract float Resolve_Return ();

	// public Return_Float Endurance {
	// 	get {
	// 		return new Return_Float (Endurance_Return);
	// 	}
	// }

	public abstract float Endurance_Return ();

	// public Return_Float Tenacity {
	// 	get {
	// 		return new Return_Float (Tenacity_Return);
	// 	}
	// }

	// public abstract float Tenacity_Return ();


	// public Return_Float Diffuse {
	// 	get {
	// 		return new Return_Float (Diffuse_Return);

	// 	}
	// }

	// public abstract float Diffuse_Return ();

	/*
	 * 
	 */
	// public Return_Float Mettle {
	// 	get {
	// 		return new Return_Float (Mettle_Return);

	// 	}

	// public abstract float Mettle_Return ();


	// public Return_Float Exertion {
	// 	get {
	// 		return new Return_Float (Exertion_Return);

	// 	}
	// }

	// public abstract float Exertion_Return ();


	// public Return_Float Brilliance {
	// 	get {
	// 		return new Return_Float (Brilliance_Return);

	// 	}
	// }

	// public abstract float Brilliance_Return ();


	// public Return_Float Dexterity {
	// 	get {
	// 		return new Return_Float (Dexterity_Return);

	// 	}
	// }

	// public abstract float Dexterity_Return ();


	// /*
	//  * 
	//  */
	// public Return_Float Vitality {
	// 	get {
	// 		return new Return_Float (Vitality_Return);

	// 	}
	// }

	// public abstract float Vitality_Return ();


	// public Return_Float Constitution {
	// 	get {
	// 		return new Return_Float (Constitution_Return);

	// 	}
	// }

	// public abstract float Constitution_Return ();


	// public Return_Float Vigor {
	// 	get {
	// 		return new Return_Float (Vigor_Return);

	// 	}
	// }

	// public abstract float Vigor_Return ();


	// public Return_Float Recovery {
	// 	get {
	// 		return new Return_Float (Recovery_Return);

	// 	}
	// }

	//
	// public abstract float Recovery_Return ();

	//
/*
	public float this [StatAccessor index] {
		get {
			switch (index) {

			case StatAccessor.Resolve:
				return Resolve.Return ();
			case StatAccessor.Endurance:
				return Endurance.Return ();
			case StatAccessor.Tenacity:
				return Tenacity.Return ();
			case StatAccessor.Diffuse:
				return Diffuse.Return ();


			case StatAccessor.Mettle:
				return Mettle.Return ();
			case StatAccessor.Exertion:
				return Exertion.Return ();
			case StatAccessor.Brilliance:
				return Brilliance.Return ();
			case StatAccessor.Dexterity:
				return Dexterity.Return ();

			case StatAccessor.Vitality:
				return Vitality.Return ();
			case StatAccessor.Constitution:
				return Constitution.Return ();
			case StatAccessor.Vigor:
				return Vigor.Return ();
			case StatAccessor.Recovery:
				return Recovery.Return (); 

			case StatAccessor.MaxMoveSpeed:
				return BaseStats.MaxMoveSpeed;
			case StatAccessor.CurrentMoveSpeed:
				return 0;
			case StatAccessor.MaxJumpHeight:
				return BaseStats.MaxJump_Height;
			case StatAccessor.CurretJumpHeight:
				return 0;

			default:
				return 0;

			}
		}
	}

	//
	public int this [LifeAccessor index] {
		set {
			if (index == LifeAccessor.CurrentHealth)
				CurrentHealth = value;
			if (index == LifeAccessor.CurrentShield)
				CurrentShield = value;
		}
		get {
			switch (index) {

			case LifeAccessor.MaxHealth:
				return BaseStats.MaxHealth;
			case LifeAccessor.MaxShield:
				return BaseStats.MaxShield;
			case LifeAccessor.CurrentHealth:
				return CurrentHealth;
			case LifeAccessor.CurrentShield:
				return CurrentShield;
			default:
				return 0;

			}
		}
	}
*/
	//
	// public CharacterStat ()
	// {
	// 	CurrentHealth = BaseStats.MaxHealth;
	// 	CurrentShield = BaseStats.MaxShield;
	// 	movementComands = new List<MovementCommand> ();
	// 	statusEffect = new StatusEffectManager ();


	// }
		
// }
