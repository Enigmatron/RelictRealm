using UnityEngine;
using System.Collections.Generic;
// using StatisticSystem;

//public class CollectibleLibrary
//{
//
//	public enum Instances
//	{
//		Savagery = 0,
//
//
//
//	}
//
//	static Dictionary<Instances,Collectible> publicCollectibles = new Dictionary<Instances, Collectible> () {
//		{ Instances.Savagery, new Collectible () }
//	};
//
//	public Dictionary<Instances,Collectible> PublicCollectibles {
//		get {
//			return publicCollectibles;
//		}
//	}
//
//}
namespace CollectibleSystem
{
	public enum CollectibleInstances
	{
		FrostOver,
		BloodTrail,
	}

	public class Collectible
	{
		protected class Record
		{
			public int Heap;
			public int Heap_Lost_On_Death;
			public float Progress;

			public void DeathLoss ()
			{
				Heap = MathLambda.SubtractTillZero (Heap, Heap_Lost_On_Death);
			}

			public Record ()
			{
			}
		}

		//		public class Receipt
		//		{
		//			private Record record;
		//			public int Heap;
		//			public CollectibleInstances instance;
		//		}


		Dictionary<EntityState, Record> Records;
		//
		private float Maximum_Progress;

		//
		private int Maximum_Heap;
		private int Heap_Gain, Heap_Start;
		private int Heap_Loss;
		private int Heap_Lost_On_Death;

		//
		private bool Refreshable;
		
		//	//
		//	public void Attach (IState state)
		//	{
		//		state.Update_Handler += Refresh;
		//		state.Death_Handler += DeathLoss;
		//
		//	}
		//
		//	public void Detach (IState state)
		//	{
		//		state.Update_Handler -= Refresh;
		//		state.Death_Handler -= DeathLoss;
		//	}

		//
		public void Update ()
		{
			foreach (KeyValuePair<EntityState, Record> entry in Records) {
				if (entry.Value.Heap > 0) {
					if (Maximum_Progress != 0) {
						entry.Value.Progress = MathLambda.AddTillEqualTo (entry.Value.Progress, Time.deltaTime, (float)Maximum_Progress);
						if (entry.Value.Progress >= Maximum_Progress) {
							entry.Value.Heap = MathLambda.SubtractTillZero (entry.Value.Heap, Heap_Loss);

						}
					}
				} else
					Records.Remove (entry.Key);
			}

		}

		public EntityState[] Holders ()
		{
			List<EntityState> temp = new List<EntityState> ();
			foreach (KeyValuePair<EntityState, Record> entry in Records) {
				temp.Add (entry.Key);
			}
			return temp.ToArray ();
		}

		public bool HolderTest (EntityState state)
		{
			return Records.ContainsKey (state);
		}

		public int HeapCount (EntityState state)
		{
			Record rec = null;
			int val = 0;
			if (Records.TryGetValue (state, out rec)) {
				val = rec.Heap;
			}
		
			return val;
		}

		private Collectible.Record CreateInstance ()
		{
			Record rec = new Collectible.Record ();
			rec.Heap = Heap_Start;
			rec.Heap_Lost_On_Death = Heap_Lost_On_Death;
			return rec;
		}
		//
		public void Collect (EntityState state)
		{
			Record rec = null;
			if (Records.TryGetValue (state, out rec)) {
				rec.Heap = MathLambda.AddTillEqualTo (rec.Heap, Heap_Gain, Maximum_Heap);
				if (Refreshable)
					rec.Progress = 0;
			} else {
				rec = CreateInstance ();
//				state.Death_Handler += rec.DeathLoss;
				Records.Add (state, rec);
			} 
		}

		public void Consume (EntityState state)
		{
			Record rec = null;
			if (Records.TryGetValue (state, out rec)) {
				rec.Heap = MathLambda.SubtractTillZero (rec.Heap, Heap_Loss);
				if (rec.Heap <= 0)
					Records.Remove (state);
			}
		}



		//	public Collectible (string Id, float duration, bool refresh = true, int stacks = 1, int gain = 1, int loss = 1, int lostDeath = 1)
		//	{
		//		name = Id;
		//		Maximum_Progress = duration;
		//		Maximum_Heap = stacks;
		//		this.Progress = 0;
		//		this.Heap = 0;
		//		Heap_Gain = gain;
		//		Heap_Loss = loss;
		//		Heap_Lost_On_Death = lostDeath;
		//		this.Refreshable = refresh;
		//	}
		//
		//	public Collectible (string Id, Shell shell)
		//	{
		//		name = Id;
		//		Maximum_Progress = shell.Progress;
		//		Maximum_Heap = shell.Heap;
		//		this.Progress = 0;
		//		this.Heap = 0;
		//		Heap_Gain = shell.Heap_Gain;
		//		Heap_Loss = shell.Heap_Loss;
		//		Heap_Lost_On_Death = shell.Heap_Loss_On_Death;
		//		this.Refreshable = shell.Refreshable;
		//	}
		//
		//	public Collectible (Collectible copy)
		//	{
		//		name = copy.name;
		//		Maximum_Progress = copy.Maximum_Progress;
		//		Progress = copy.Progress;
		//		Maximum_Heap = copy.Maximum_Heap;
		//		Heap = copy.Heap;
		//		this.Progress = copy.Progress;
		//		this.Heap = copy.Heap;
		//		Heap_Gain = copy.Heap_Gain;
		//		Heap_Loss = copy.Heap_Loss;
		//		Heap_Lost_On_Death = copy.Heap_Lost_On_Death;
		//		this.Refreshable = copy.Refreshable;
		//
		//	}

		public static Builder Initialize ()
		{
			Builder temp = new Builder ();
			temp.create.Maximum_Progress = 0;
			temp.create.Maximum_Heap = 1;
			temp.create.Heap_Loss = 0;
			temp.create.Heap_Gain = 0;
			temp.create.Heap_Lost_On_Death = 1;
			return temp;
		}

		public class Builder
		{
			public Collectible create;

			public Builder Define_Refreshability (bool val)
			{
				create.Refreshable = val;
				return this;
			}

			public Builder Define_Progess_Limit (float val)
			{
				create.Maximum_Progress = val;
				return this;
			}

			public Builder Define_Heap_Limit (int val)
			{
				create.Maximum_Heap = val;
				return this;
			}

			public Builder Define_Heap_Start (int val)
			{
				create.Heap_Start = val;
				return this;
			}

			public Builder Define_Gain (int val)
			{
				create.Heap_Gain = val;
				return this;
			}

			public Builder Define_Loss (int val)
			{
				create.Heap_Loss = val;
				return this;
			}

			public Builder Define_Loss_On_Death (int val)
			{
				create.Heap_Lost_On_Death = val;
				return this;
			}

			public Collectible Declare ()
			{
//			create.name = name;
				return create;
			}
		}

		protected Collectible ()
		{
		
		}
	}
}



/*
  /// <summary>
/// Interface for requirement.
/// </summary>
public interface IRequirement
{


}

public interface IRequirementPlayer : IRequirement
{


}

public interface IRequirementCollectible : IRequirement
{


}

/// <summary>
/// Collectible requirement for abilities.
/// </summary>
//public class CollectibleRequirement : IRequirement
//{
//	public Collectible collect;
//
//	public int stackRequirement;
//
//	public bool RequirementMet {
//		get {
//			bool temp = true;
////			if (collect != ) {
//			temp = collect.Heap <= stackRequirement && collect.Heap != 0;
////			}
//			return temp;
//		}
//	}
//}

/// <summary>
/// Collectible requirement for abilities.
/// </summary>
public class KeyCodeRequirement : IRequirement
{
	public KeyCode collect;


	public bool RequirementMet {
		get {

			return Input.GetKeyDown (collect);
		}
	}
}

/// <summary>
/// Progressor requirement for abilities.
/// </summary>
public class ProgressorRequirement : IRequirement
{
	public Progressor progress;

	public bool RequirementMet {
		get {
			bool temp = true;
			if (progress != null) {
				temp = progress.Usable;
			}
			return temp;
		}
	}
}

/// <summary>
/// Iterim requirement for abilities.
/// </summary>
public class IterimRequirement : IRequirement
{
	public Interim progress;

	public int stackRequirement;

	public bool RequirementMet {
		get {
			bool temp = true;
			if (progress != null) {
				temp = progress.Finished;
			}
			return temp;
		}
	}
}
*/