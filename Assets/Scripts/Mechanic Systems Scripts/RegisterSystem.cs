using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;


#region RegisterValue
//A class for a value that you can change and has events attached to it for when its changed, this can be interpreted as a float or bool
public class RegisterValue{//TODO make this a generic class that looks for register_value_manager class that manages a data type (boolean, vector, movecommand, float); maybe all values are derivative of floats so its fine

	#region methods
	//This method manages observer calls and updates the value of the stack
	public void updateValue(float val){
		if(val == 0){
			return;
		}
		if(val > 0 ){
			OnIncrement.Invoke(val);
		}
		else if(val < 0 ){
			OnDecrement.Invoke(val);
		}
		value += val;
		OnChange.Invoke(val);
		if(ValueAsBool()){
			OnTrue.Invoke();
		}
		else{
			OnFalse.Invoke();
		}
	}

	//resets the value of the stack and makes the onreset observer call
	public void reset(){
		OnReset.Invoke(value);
		value = 0;
	}

	public bool ValueAsBool(){
		return value >= 0 ? true : false;  
	}
	//Calls necessary observer methods when the value gets flatly added to
	public void setValue(float val){
		if(val == 0){
			return;
		}
		if(val > 0 ){
			OnIncrement.Invoke(val);
		}
		else if(val < 0 ){
			OnDecrement.Invoke(val);
		}
		value = val;
		OnChange.Invoke(val);
		if(ValueAsBool()){
			OnTrue.Invoke();
		}
		else{
			OnFalse.Invoke();
		}
	}
	#endregion


	//some registers get referenced as a boolean
	#region variables
	public float value{get; protected set;}


	// all these values have to be moved to EntityRegisterProfile
	public UnityEvent OnTrue{get; protected set;}
	public UnityEvent OnFalse{get; protected set;}

	public UnityEvent<float> OnIncrement {get; protected set;}
	public UnityEvent<float> OnDecrement{get; protected set;}
	public UnityEvent<float> OnChange{get; protected set;}
	public UnityEvent<float> OnReset{get; protected set;}
	#endregion

	#region builder
	public static Builder initialize(){
		Builder builder = new Builder();
		return builder;
	}
	public class Builder{
		private RegisterValue obj = new RegisterValue();
		public static Builder initialize(){
			Builder builder = new Builder();
			return builder;
		}
		public RegisterValue build(){
			return obj;
		}
		public Builder add_OnChange(UnityAction<float> val){
			obj.OnChange.AddListener(val);
			return this;
		}
		public Builder add_OnReset(UnityAction<float> val){
			obj.OnReset.AddListener(val);
			return this;
		}
		public Builder add_OnDecrement(UnityAction<float> val){
			obj.OnDecrement.AddListener(val);
			return this;		
		}
		public Builder add_OnIncrement(UnityAction<float> val){
			obj.OnIncrement.AddListener(val);
			return this;
		}

		public Builder add_OnTrue(UnityAction val){
			obj.OnTrue.AddListener(val);
			return this;
		}
		public Builder add_OnFalse(UnityAction val){
			obj.OnFalse.AddListener(val);
			return this;
		}
		//TODO add Builder methods


	}
	#endregion
}
#endregion

/// <summary>
/// a system meant to force a movement for a character with options such as direction/target, force. this also has dynamic end conditions and a miniature state condition; removes character control
/// </summary>
//replace this, add a system or values on characters that can be invoked by register/progressors/interims
public class MovementCommand
{
	//TODO make a builder

	public bool Finished {
		get {
			return DistanceToTravel <= DistanceTraveled;
		}
	}

	#region variables
	


	//vector where the subject will go to if there isnt a targetLocation; mutually exclusive with target location
	public Vector3 Direction;
	//the transform where the subject will go to regardless of the direction; just make it a sub-object that links to the subject transform; mutually exclusive with direction
	public Transform TargetLocation;

	// my code utilizes acceleration values
	public float Acceleration;

	//
	public float DistanceToTravel;

	// public Vector3 AcceleratedDirection {
	// 	get {
	// 		return Direction * Acceleration; 
	// 	}
	// }

	public float DistanceTraveled;

	//prevent outside movement
	public bool overrideMovement;
	#endregion

	// public void Refresh ()
	// {
	// 	DistanceTraveled = BasicFunction.AddTillEqualTo (DistanceTraveled, Acceleration * Time.deltaTime, DistanceToTravel);
	// }

	//
	public MovementCommand (Vector3 dir, float acc, float toTravel, bool over = false, bool pause = true)
	{
		// SubjectLocation = null;
		Acceleration = acc;
		TargetLocation = null;
		overrideMovement = over;
		DistanceToTravel = toTravel;
		DistanceTraveled = 0;
		Direction = dir;
	}
	//
	public MovementCommand (Transform dir, float acc, float toTravel, bool over = false, bool pause = true)
	{
		Acceleration = acc;
		Direction = Vector3.zero;
		overrideMovement = over;
		DistanceToTravel = toTravel;
		DistanceTraveled = 0;
		TargetLocation = dir;
		// SubjectLocation = null;
	}
}



//this system is a class for dynamic state changes. This class has a value that calls certain methods for the value as it updates, finishes, made updatable or not
//this is intended for out of combat timers, energy resources, mana, ect.
public class ProgressionStateMachine
{



	//the maximum value for progression
	public readonly float Maximum_Progress;

	public RegisterValue Progress;
	public float IntervalProgress;
	//
	// public Phase_Management onPhase;
	//
	public bool start, finish;

	//
	public bool Started {
		get {
			return start;
		}
	}
	//
	public bool Finished {
		get {
			return finish;
		}
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}

	public void Play ()
	{
		// if (onPhase.onPlay != null) {
		// 	onPhase.onPlay.Invoke ();
		// }
	}

	public void Reset ()
	{
		Progress.reset();
		IntervalProgress = 0;
		finish = false;
	}

	public void Complete ()
	{
		// if (onPhase.onCompletion != null) {
		// 	onPhase.onCompletion.Invoke ();
		// }
		finish = false;
		start = false;
	}




	public void Refresh ()
	{
		// if (!finish && start) {
		// 	if (Iterations > 0) {
		// 		IntervalProgress += Time.deltaTime;
		// 		Progress = BasicFunction.AddTillEqualTo (Progress, Time.deltaTime, Maximum_Progress);
		// 		if (Progress != Maximum_Progress) {
		// 			while (IntervalProgress >= Equal_Interval) {
		// 				IntervalProgress -= Equal_Interval;
		// 				if (onPhase.onRefresh != null)
		// 					onPhase.onRefresh.Invoke ();
		// 			}
		// 		} else {
		// 			Complete ();
		// 		}

		// 	} else {
		// 		Progress += Time.deltaTime;
		// 		if (Progress < Maximum_Progress) {
		// 			if (onPhase.onRefresh != null) {
		// 				onPhase.onRefresh.Invoke ();
		// 			}
		// 		} else if (Progress >= Maximum_Progress) {
		// 			Complete ();
		// 		}
		// 	}
		// }
	}

	public ProgressionStateMachine (){
		start = false;
		finish = false;
		pause = true;
		Maximum_Progress = 0;
		// Iterations = 0;
		// onPhase = null;
		// Progress = null;
		IntervalProgress = 0;
	}

	public class Builder{
		// int Iteration;
		float Max_Progress;
		// Phase_Management Phases = new Phase_Management(null, null, null, null);
		bool Pause;

		// public void setIteration

		public Builder(){

		}

	}
}





/*
/// <summary>
/// DOT.
/// </summary>
//public class DOT : Interim
//{
//
//
//		
//	//
//	public DamageProfile damage;
//
//	//
//	public void Attach (IState state)
//	{
////		time = new Interim (shell);
////		time.Play (state);
//	}
//
//	public void Detach ()
//	{
//		
//	}
//	//
//	public void Refresh ()
//	{
////		time.Refresh ();
//	}
//
//	//
//	//	public DOT (int iterations, float durations, DamageProfile dam)
//	//	{
//	////		shell = new Interim.Shell (durations, iterations, true, new Phase_Management ());
//	//		damage = dam;
//	//	}
//}
/*
/// <summary>
/// Collectible object.
/// </summary>
public class Collectible
{
	public struct Shell
	{
		public float? Progress;
		public int Heap;
		public int Heap_Gain, Heap_Loss, Heap_Loss_On_Death;
		public bool Refreshable;

		public Shell (float? progress, int heap, int loss, int gain, int death, bool refresh)
		{
			Progress = progress;
			Heap = heap;
			Heap_Gain = gain;
			Heap_Loss = loss;
			Heap_Loss_On_Death = death;
			Refreshable = refresh;
		}
	}
	//
	object id;

	public object ID {
		get {
			return id;
		}
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}

	//
	public float? Maximum_Progress;
	public float Progress;


	public void Play (IState state)
	{

	}

	public void Refresh ()
	{
		if (Maximum_Progress != null) {
			Progress = BasicFunction.AddTillEqualTo (Progress, Time.deltaTime, (float)Maximum_Progress);					
		}
	}
	//
	public int Maximum_Heap;
	//
	public int Heap;
	//
	public int Heap_Gain;
	//
	public int Heap_Loss;
	//
	public int Heap_Lost_On_Death;
	//
	public bool Refreshable;



	//
	public void Collect ()
	{
		Heap = BasicFunction.AddTillEqualTo (Heap, Heap_Gain, Maximum_Heap);
		if (Refreshable)
			Progress = 0;
	}

	public void Loss ()
	{
		Heap = BasicFunction.SubtractTillZero (Heap, Heap_Loss);
	}

	public void DeathLoss ()
	{
		Heap = BasicFunction.SubtractTillZero (Heap, Heap_Lost_On_Death);
	}

	public Collectible (string Id, float? duration, bool refresh = true, int stacks = 1, int gain = 1, int loss = 1, int lostDeath = 1)
	{
		id = Id;
		Maximum_Progress = duration;
		Maximum_Heap = stacks;
		this.Progress = 0;
		this.Heap = 0;
		Heap_Gain = gain;
		Heap_Loss = loss;
		Heap_Lost_On_Death = lostDeath;
		this.Refreshable = pause;
	}

	public Collectible (string Id, Shell shell)
	{
		id = Id;
		Maximum_Progress = shell.Progress;
		Maximum_Heap = shell.Heap;
		this.Progress = 0;
		this.Heap = 0;
		Heap_Gain = shell.Heap_Gain;
		Heap_Loss = shell.Heap_Loss;
		Heap_Lost_On_Death = shell.Heap_Loss_On_Death;
		this.Refreshable = shell.Refreshable;
	}

	public Collectible (Collectible copy)
	{
		id = copy.id;
		Maximum_Progress = copy.Maximum_Progress;
		Progress = copy.Progress;
		Maximum_Heap = copy.Maximum_Heap;
		Heap = copy.Heap;
		this.Progress = copy.Progress;
		this.Heap = copy.Heap;
		Heap_Gain = copy.Heap_Gain;
		Heap_Loss = copy.Heap_Loss;
		Heap_Lost_On_Death = copy.Heap_Lost_On_Death;
	}

}
*/
/*
/// <summary>
/// Progressor: an object that counts up to 100 and an optional value. ultimate goal is to return that its usable.
/// </summary>
public class Progressor : IRefresh
{
	public struct Shell
	{
		public static readonly int None = 0;
		public static readonly int Staggerable = 1 << 1;
		public static readonly int Resetable = 1 << 2;
		public static readonly int Surgeable = 1 << 3;
		public static readonly int No_Natural_Gain = 1 << 4;

		public int Flags;

		public int Min, Max;
		public int LowGain, MedGain, HighGain;
		public int LowLoss, MedLoss, HighLoss;


		public Shell (int max, int min, int LowGain, int MedGain, int HighGain, int LowLoss, int MedLoss, int HighLoss, int flag)
		{
			Max = max;
			Min = min;
			this.HighLoss = HighLoss;
			this.MedLoss = MedLoss;
			this.LowLoss = LowLoss;
			this.HighGain = HighGain;
			this.MedGain = MedGain;
			this.LowGain = LowGain;
			Flags = flag;
		}

		public Progressor Instanstiate ()
		{
			return new Progressor (this);
		}
	}

	public class Info
	{
		
	}



	//	IState state;
	public static readonly int None = 0;
	public static readonly int Staggerable = 1 << 1;
	public static readonly int Resetable = 1 << 2;
	public static readonly int Surgeable = 1 << 3;
	public static readonly int No_Natural_Gain = 1 << 4;


	public readonly float Maximum_Progress, Minimum_Progress;
	public readonly int LowGain, MedGain, HighGain;
	public readonly int LowLoss, MedLoss, HighLoss;

	public float Progress;

	public int flags;

	public int Flags {
		get {
			return flags;
		}
	}

	public float Reduction {
		get {
			return Mathf.Sqrt ((Mathf.Pow ((Progress / Maximum_Progress), 3)));
		}
	}

	public void Refresh ()
	{
		float changeInProgression = 1;

		if (Progress != Maximum_Progress && !BasicFunction.FlagBool (Flags, No_Natural_Gain)) {
//			if(BasicFunction.FlagBool(Flags, Staggerable) && )
			Progress = BasicFunction.AddTillEqualTo (Progress, Time.deltaTime * changeInProgression, Maximum_Progress);
		}
	}


	public void OnLowGain ()
	{
		Progress = BasicFunction.AddTillEqualTo (Progress, LowGain, Maximum_Progress);
	}

	public void OnLowLoss ()
	{
		Progress = BasicFunction.SubtractTillZero (Progress, LowGain);
	}

	public void OnMediumGain ()
	{
		Progress = BasicFunction.AddTillEqualTo (Progress, MedGain, Maximum_Progress);

	}

	public void OnMediumLoss ()
	{
		Progress = BasicFunction.SubtractTillZero (Progress, MedGain);

	}

	public void OnHighGain ()
	{
		Progress = BasicFunction.AddTillEqualTo (Progress, HighGain, Maximum_Progress);

	}

	public void OnHighLoss ()
	{
		Progress = BasicFunction.SubtractTillZero (Progress, HighGain);
	}



	public bool Usable {
		get {
			return Progress >= Minimum_Progress || Progress >= Maximum_Progress;
		}
	}



	public void CutShort ()
	{
		Progress = Maximum_Progress / 2; 
	}

	public void Reset ()
	{
		if (BasicFunction.FlagBool (Flags, Resetable))
			Progress = 0;
	}
		
	//
	public Progressor (int max, int min, int LowGain, int MedGain, int HighGain, int LowLoss, int MedLoss, int HighLoss, int flag)
	{
		Maximum_Progress = max;
		Minimum_Progress = min;
		this.HighLoss = HighLoss;
		this.MedLoss = MedLoss;
		this.LowLoss = LowLoss;
		this.HighGain = HighGain;
		this.MedGain = MedGain;
		this.LowGain = LowGain;
		flags = flag;
	}
	//
	public Progressor (Shell shell)
	{
		Maximum_Progress = shell.Max;
		Minimum_Progress = shell.Min;
		this.HighLoss = shell.HighLoss;
		this.MedLoss = shell.MedLoss;
		this.LowLoss = shell.LowLoss;
		this.HighGain = shell.HighGain;
		this.MedGain = shell.MedGain;
		this.LowGain = shell.LowGain;
		flags = shell.Flags;
	}
}
	
//
public class StatusEffect
{
	public enum StatusEffects
	{
		Snare,
		Slow,
		EnduranceBypass,
		EnduranceSupression,
		Daze,
		Blindness,
		Displace,
		Muzzle,
		Surge,
		Advance,
		Stun,

	}



	public class Builder
	{




	}
}

/*
/// <summary>
/// Status Effect Instances.
/// </summary>
public class Slow : IStatusEffect
{
	public float value;
	public Interim duration;

	public void Refresh ()
	{
		duration.Refresh ();
	}

	public void Play (IState state)
	{
		duration.Play (state);
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Defense_Supression : IStatusEffect
{

	public float value;
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Daze : IStatusEffect
{
	public float value;
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Blindness : IStatusEffect
{
	public float value;
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Strike : IStatusEffect
{
	public MovementCommand direction;


	public void Play (IState state)
	{
		//		direction.Play (state);
	}

	public void Refresh ()
	{

	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Snare : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}

}

public class Stun: IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Defense_Bypass: IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}

}

public class Muzzle : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Surge : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Stagger : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Neutralize : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}
//	public class Knock_Down : IStatusEffect
//	{
//		public Interim duration;
//
//		public void Play (IState state)
//		{
//			duration.Play (state);
//		}
//
//		public void Refresh ()
//		{
//			duration.Refresh ();
//		}
//
//		bool pause;
//
//		public bool Pauseable {
//			get {
//				return pause;
//			}
//		}
//	}
public class Suppress : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

//"stagger"
public class Exhaust : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

//"rally"
public class Invigorate : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}

public class Advance : IStatusEffect
{
	public Interim duration;

	public void Play (IState state)
	{
		duration.Play (state);
	}

	public void Refresh ()
	{
		duration.Refresh ();
	}

	bool pause;

	public bool Pauseable {
		get {
			return pause;
		}
	}
}
*/