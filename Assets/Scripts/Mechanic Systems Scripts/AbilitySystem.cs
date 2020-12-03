using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//TODO it seems like ability must be a curcuit with leaves. Requirements are branches and ExecuteFrames are leaves once the branch decides to move on
//90% of this can be replaced by well placed UnityEvents 




public delegate void AbilityLink ();


public interface IExecuteFrame
{
	// bool Activate (HealthController cont);

	bool Activated {
		get;
	}
}

public interface IRequirementFrame
{
	//returns true if reqs are done
	bool Update ();
}

public struct Blank_Frame : IRequirementFrame, IExecuteFrame
{

	
	
	
	

	public bool Activated {
		get {
			return activated;
		}
	}

	bool activated;

	public bool Update ()
	{
		return true;
	}
}


//
// public struct Combat_Frame : IExecuteFrame, IRequirementFrame
// {

// 	public bool Update ()
// 	{
// 		return Combat == null;
// 	}








	// public ICombat Combat;
// 	bool activated;

// 	public bool Activated {
// 		get {
// 			return activated;
// 		}
// 	}

// 	// public Combat_Frame (ICombat Key)
// 	// {
// 	// 	activated = false;

// 	// 	Combat = Key;
// 	// }
// }


public struct Movement_Frame : IExecuteFrame, IRequirementFrame
{
	public bool Update (){
		return true;
	}

	public MovementCommand Command;

	
	public bool Finished {
		get {
			return Command.Finished;
		}
	}


	
	bool activated;

	public bool Activated {
		get {
			return activated;
		}
	}


	public Movement_Frame (MovementCommand Key)
	{
		Command = Key;
		activated = false;
	}
}


//generally the idle frame for ability initial activation
public struct Activate_Frame : IRequirementFrame
{
	#region IRequirementFrame implementation

	public bool Update ()
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	public KeyCode key;

	//
	public Activate_Frame (KeyCode Key)
	{
		key = Key;
	}
}


//hard cd or waiting frame
public struct Delay_Frame : IRequirementFrame
{
	#region IRequirementFrame implementation

	public bool Update ()
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	

	public float duration;

	//
	public Delay_Frame (float time)
	{
		duration = time;
	}

}


//waits for a key press but has a maximum time before it activates an alternative path
//ex: a timer till ability runs out or allows the ability to be activated
public struct Progressor_Frame : IRequirementFrame
{
	#region IRequirementFrame implementation

	public bool Update ()
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	
	public float min;
	public float max;

	//
	public Progressor_Frame (float timeMin, float timeMax)
	{
		min = timeMin;
		max = timeMax;
	}

}
	
//
public struct SequenceSector
{

	public bool Started;
	public bool Finished;
	public bool Canceled;
	//add on_Canceled/Finished/Started observer events
	// public Return_Bool Rbool;
	IExecuteFrame Execute;
	IRequirementFrame Requirement;
	Animation animPre;
	Animation animPost;

	// public void Refresh (HealthController control)
	// {
		
	// 	if (!Execute.Activate(control)) {
			
	// 	}



	// }

	public SequenceSector (IExecuteFrame ea, IRequirementFrame ra)
	{	
		animPost = null;
		animPre = null;

		// Rbool = new Return_Bool (rbool);
		Canceled = false;
		Execute = ea;
		Requirement = ra;
		Finished = false;
		Started = false;
	}

	public SequenceSector (IExecuteFrame ea)
	{
		animPost = null;
		animPre = null;
		
		// Rbool = new Return_Bool (rbool);
		Canceled = false;
		Execute = ea;
		Requirement = new Blank_Frame ();
		Finished = false;
		Started = false;
	}
}




//public class AbilityCost
//{
//	public float currentLifeResourcePercent;
//	public float Resource;
//}



//
public class Ability
{
	public List<SequenceSector> Frames;
	//all sequences in an ability
	public SequenceSector? CurrentFrame;
	int? currentFrame = 0;
	bool activate;

	public bool Activate {
		get {
			return activate;
		}
	}

	public bool startedSequence;
	//
	// public void Refresh (HealthController control)
	// {
	// 	if (Activate) {
	// 		startedSequence = true;
	// 		currentFrame = 0;
	// 		CurrentFrame = Frames [(int)currentFrame];
	// 	}
	// 	if (startedSequence) {
	// 		if (((SequenceSector)CurrentFrame).Finished) {
	// 			currentFrame++;
	// 			//currentFrame = currentFrame < (Frames.Count - 1) ? currentFrame : null;
	// 			if (!(currentFrame < Frames.Count - 1))
	// 				CurrentFrame = Frames [(int)currentFrame];
	// 			else {
	// 				CurrentFrame = null;
	// 				startedSequence = false;
	// 			}
	// 		}
	// 		((SequenceSector)CurrentFrame).Refresh (control);
				
	// 	}
	// }



	//
	protected Ability ()
	{

	}


	public class Builder
	{
		Ability ability;

		public Builder AddSector (SequenceSector req)
		{
//			SequenceSector last = ability.Frames [ability.Frames.Count - 1];
//			last.Link += req.Start;
			ability.Frames.Add (req);
			return this;
		}

		public Ability Intialize ()
		{
			return ability;
		}

		public static Builder Create ()
		{
			Builder Builder = new Builder ();
			Builder.ability = new Ability ();
			return Builder;
		}
	}
}
