﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a system meant to force a movement for a character with options such as direction/target, force. this also has dynamic end conditions and a miniature state condition; removes character control
/// </summary>
//TODO: make is so it automatically locks movement
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
    public Vector3 Direction{
        get;
        // protected 
        set;
    }
    public bool Teleportation{
        get;
        // protected 
        set;
    }
    //the transform where the subject will go to regardless of the direction; just make it a sub-object that links to the subject transform; mutually exclusive with direction
    // public Transform TargetLocation{
    //     get;
    //     // protected 
    //     set;
    // }
    // my code utilizes acceleration values
    //TODO use IRegister or something that ties this as a register/registerStat

    public float TimeElapsed{
        get;
        private
        set;
    }
    public float Acceleration;
    public Transform Target;
    // public 
    public delegate float AccelerationEQ(Entity _entity);
    public AccelerationEQ accelerationEQ{
        get;
        // protected 
        set;
    }

    //this is to represent a matrix the represents a function with xyz used traditionally and w used for time
    public delegate Vector3 DirectionEQ(Entity _entity);
    public DirectionEQ directionEQ{
        get;
        protected
        set;
    }
    //
    public float DistanceToTravel{
        get;
        // protected 
        set;
    }

    public float DistanceTraveled{
        get;
        // protected 
        set;
    }

    //This is a nec as you could just give a limited speed boost instead of the movement command
    // public bool overrideMovement;
    #endregion
    public void Update(float distanceUpdate)
    {
        TimeElapsed += Time.deltaTime;
        DistanceTraveled += distanceUpdate;
    }
    //
    public MovementCommand(Vector3 dir, float acc, float toTravel, bool over = false, bool pause = true)
    {
        Acceleration = acc;
        DistanceToTravel = toTravel;
        DistanceTraveled = 0;
        Direction = dir;
    }
    //
    public MovementCommand(Transform dir, float acc, float toTravel, bool over = false, bool pause = true)
    {
        Acceleration = acc;
        Direction = Vector3.zero;
        DistanceToTravel = toTravel;
        DistanceTraveled = 0;
    }
    public class Builder{
        MovementCommand obj;
        public Builder Build(){
            return new Builder();
        }
        public Builder setAcceletationEQ(AccelerationEQ _acc){
            obj.accelerationEQ = _acc;
            return this;
        }
        public Builder setDirectionEQ(DirectionEQ _dir)
        {
            obj.directionEQ = _dir;
            return this;
        }
        public Builder setDistanceToTravel(float dir)
        {
            obj.DistanceToTravel = dir;
            return this;
        }

        public Builder setDirection(Vector3 dir)
        {
            obj.Direction = dir;
            return this;
        }

        public Builder setAcceleration(float accl = 60)
        {
            obj.Acceleration = accl;
            return this;
        }

        public Builder setTeleportation(bool tele = false)
        {
            obj.Teleportation = tele;
            return this;
        }

    }
}