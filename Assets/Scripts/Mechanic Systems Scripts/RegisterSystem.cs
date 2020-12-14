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

// public interface Timer{
// 	public void Play ();
// 	public void Reset();
//     public void Stop();
//     public void Update();

// }

//Just a simple timer that has its Value tracked
public class Timer
{
    RegisterValue value;
	float maxTime;
	float lastCheckIn;
    public int Flags;
	public void Reset ()
	{
        value.reset();
    }
    public void Update()
	{
        if (maxTime <= value.value){
			return;
		}
		else{
			value.setValue(Time.deltaTime);
		}

    }



    public class Builder{
        Timer obj;

		public Builder(){
			obj = new Timer();
		}


	}
}


public class Resource
{
    public enum ResourceVariables
    {

	}
    RegisterProfile<ResourceVariables> profile;




}
