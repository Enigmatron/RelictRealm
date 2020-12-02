// using UnityEngine;
// using System.Collections;

//public class Fatigue {
//	public float maxTime, minTime, currentTime;
//
//	public bool gainOnAtt, lossOnHit;
//	public bool canBeStagger, canBeReset;
//	bool muzzled;
//
//	public float Reduction{
//		get {
//			return Mathf.Sqrt((Mathf.Pow ((currentTime / maxTime), 3)));
//		}
//	}
//	public float LossOnDamage{
//		get {
//			return 1;
//		}
//	}
//	public float GainOnAtt{
//		get {
//			return 1;
//		}
//	}
//	public void Refresh(float timeChange, ReplicaState state){
////		if (state.DurationSEVar.Muzzle)
////			muzzled = true;
////		else if(!state.DurationSEVar.Muzzle && muzzled){
////			muzzled = false;
////			currentTime = minTime;
////		}
//		if(currentTime != maxTime){
//			currentTime = BasicFunction.AddTillEqualTo(currentTime, timeChange, maxTime);
//		}
//	}
//	public void Use(){
//		currentTime = 0.0f; 
//	}
//	public void CutShort(){
//		currentTime = maxTime/2; 
//	}
//
//
//
//	public Fatigue(float max, float min, bool gain = false, bool loss = false, bool stagger = false, bool reset = false){
//
//	}
//
//
//}
