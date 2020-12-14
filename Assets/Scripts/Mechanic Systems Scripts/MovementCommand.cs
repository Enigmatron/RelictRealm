using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a system meant to force a movement for a character with options such as direction/target, force. this also has dynamic end conditions and a miniature state condition; removes character control
/// </summary>
//replace this, add a system or values on characters that can be invoked by register/progressors/interims
public class MovementCommand
{
    //TODO make a builder

    public bool Finished
    {
        get
        {
            return DistanceToTravel <= DistanceTraveled;
        }
    }

    #region variables



    //vector where the subject will go to if there isnt a targetLocation; mutually exclusive with target location
    public Vector3 Direction;
    //the transform where the subject will go to regardless of the direction; just make it a sub-object that links to the subject transform; mutually exclusive with direction
    public Transform TargetLocation;

    // my code utilizes acceleration values
    //TODO use IRegister or something that ties this as a register/registerStat
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
    public MovementCommand(Vector3 dir, float acc, float toTravel, bool over = false, bool pause = true)
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
    public MovementCommand(Transform dir, float acc, float toTravel, bool over = false, bool pause = true)
    {
        // SubjectLocation = null;
        Acceleration = acc;
        Direction = Vector3.zero;
        overrideMovement = over;
        DistanceToTravel = toTravel;
        DistanceTraveled = 0;
        TargetLocation = dir;
    }
}