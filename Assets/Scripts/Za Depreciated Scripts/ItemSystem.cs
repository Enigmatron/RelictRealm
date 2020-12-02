// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using StatisticSystem;


namespace ItemSystem
{
	/*
	//TODO
	public static class Crux_Library
	{
		
		public enum Instance
		{
			Last_Will,
			Ferocity



		}

		public static Dictionary<Instance, Crux> Library = new Dictionary<Instance, Crux> () {


		};




		//
		public class Crux
		{


			public Crux ()
			{
				
			}
		}

		public static Crux Create ()
		{

			return new Crux ();
		}

	}
		
	//TODO
	public class RigItem
	{

		/// <summary>
		/// Flux. For determining where flux stats are sent to
		/// </summary>
		public enum Flux
		{
			None,
			Endurance,
			Tenacity,
			Diffuse,
			Exertion,
			Brilliance,
			Dexeterity,
			Constitution,
			Vigor,
			Recovery
		}

		/// <summary>
		/// Rig level up set.
		/// </summary>
		/// 
		/*
		public struct RigLevelUpSet
		{
			Upgrade upgrade;
			Enhancement enhance;
			Crux_Library.Crux crux;
			bool IsSet;

			public RigLevelUpSet (Upgrade.Path path, float val)
			{
				Upgrade temp = new Upgrade ();
				temp.stable = val;
				temp.path = path;
				upgrade = temp;

				enhance = null;
				crux = null;
				IsSet = true;
			}

			public RigLevelUpSet (Upgrade.Path path, float val, StableStatistic stable)
			{
				Upgrade temp = new Upgrade ();
				temp.stable = val;
				temp.path = path;
				upgrade = temp;

				Enhancement temp2 = new Enhancement ();
				temp2.Stable = stable;
				enhance = temp2;

				crux = null;
				IsSet = true;

			}

			public RigLevelUpSet (Upgrade.Path path, float val, Crux_Library.Crux crux)
			{
				Upgrade temp = new Upgrade ();
				temp.stable = val;
				temp.path = path;
				upgrade = temp;

				enhance = null;

				this.crux = crux;
				IsSet = true;

			}

			//			//
			//			public RigLevelUpSet ()
			//			{
			//				enhance = null;
			//				crux = null;
			//				upgrade = null;
			//				IsSet = false;
			//			}
		}

		/// <summary>
		/// Upgrade.
		/// </summary>
		public class Upgrade
		{
			public enum Path
			{
				Resolve,
				Mettle,
				Vitality
			}

			public float stable;
			public Path path;
		}

		/// <summary>
		/// Enhancement.
		/// </summary>
		public class Enhancement
		{
			public StableStatistic Stable;
		}

		/// <summary>
		/// The cruxes attached to the rig.
		/// </summary>
		List<Crux_Library.Crux> Cruxes;
		/// <summary>
		/// The enhanments attached to the rig.
		/// </summary>
		List<Enhancement> Enhanments;
		/// <summary>
		/// The upgrades attached to the rig.
		/// </summary>
		List<Upgrade> Upgrades;

		public float ResolveUpgrade;
		public float MettleUpgrade;
		public float VitalityUpgrade;

		/// <summary>
		/// The stat that execess stat amounts are redirected to.
		/// </summary>
		public Flux FluxRedirectOne;
		/// <summary>
		/// The stat that execess stat amounts are redirected to.
		/// </summary>
		public Flux FluxRedirectTwo;

		/// <summary>
		/// The current level of a players Rig.
		/// </summary>
		/// 
		public int Current_Level;

		/// <summary>
		/// The a list of unused or used level ups.
		/// </summary>
		public bool[] Level_Used = new bool[] {
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false
		};

		/// <summary>
		/// The level upgrade items.
		/// </summary>
		public RigLevelUpSet[] Level_Upgrade_Items = new RigLevelUpSet[] {
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
			new RigLevelUpSet (),
		};

		//OBS
		public void Add (Enhancement enh)
		{

		}

		//OBS
		public void Add (Crux_Library.Crux aux)
		{

		}
	}

*/
}
