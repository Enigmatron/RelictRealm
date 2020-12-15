using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;


//A class for a value that you can change and has events attached to it for when its changed, this can be interpreted as a float or bool
public class Register{//TODO make this a generic class that looks for register_value_manager class that manages a data type (boolean, vector, movecommand, float); maybe all values are derivative of floats so its fine

	#region methods
	//This method manages observer calls and updates the value of the stack
	public void updateValue(float val){
		// if(val == 0){
		// 	return;
		// }
		// if(val > 0 ){
		// 	OnIncrement.Invoke(val);
		// }
		// else if(val < 0 ){
		// 	OnDecrement.Invoke(val);
		// }
		value += val;
		OnChange.Invoke(val);
		// if(ValueAsBool()){
		// 	OnTrue.Invoke();
		// }
		// else{
		// 	OnFalse.Invoke();
		// }
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
		// if(val == 0){
		// 	return;
		// }
		// if(val > 0 ){
		// 	OnIncrement.Invoke(val);
		// }
		// else if(val < 0 ){
		// 	OnDecrement.Invoke(val);
		// }
		value = val;
		OnChange.Invoke(val);
		// if(ValueAsBool()){
		// 	OnTrue.Invoke();
		// }
		// else{
		// 	OnFalse.Invoke();
		// }
	}
	#endregion


	//some registers get referenced as a boolean
	#region variables
	public float value{get; protected set;}

	//These were removed as they were seen as unneccessary
	// all these values have to be moved to EntityRegisterProfile
	// public UnityEvent OnTrue{get; protected set;}
	// public UnityEvent OnFalse{get; protected set;}

	// public UnityEvent<float> OnIncrement {get; protected set;}
	// public UnityEvent<float> OnDecrement{get; protected set;}
	public UnityEvent<float> OnChange{get; protected set;}
	public UnityEvent<float> OnReset{get; protected set;}
	#endregion

	#region builder
	public static Builder initialize(){
		Builder builder = new Builder();
		return builder;
	}
	public class Builder{
		private Register obj = new Register();
		public static Builder initialize(){
			Builder builder = new Builder();
			return builder;
		}
		public Register build(){
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
		// public Builder add_OnDecrement(UnityAction<float> val){
		// 	obj.OnDecrement.AddListener(val);
		// 	return this;		
		// }
		// public Builder add_OnIncrement(UnityAction<float> val){
		// 	obj.OnIncrement.AddListener(val);
		// 	return this;
		// }

		// public Builder add_OnTrue(UnityAction val){
		// 	obj.OnTrue.AddListener(val);
		// 	return this;
		// }
		// public Builder add_OnFalse(UnityAction val){
		// 	obj.OnFalse.AddListener(val);
		// 	return this;
		// }
		//TODO add Builder methods


	}
	#endregion
}