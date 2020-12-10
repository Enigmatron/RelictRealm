using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public abstract partial class ActiveEntity {
    
    public float testmovespeed = 12;
    public float testjumpspeed = 20;
    public string backwardaxis = "Vertical";
    protected Vector3 MoveVector = Vector3.zero;
    protected float currAcceleration;
    public float gravity = 32.2F;
    protected CharacterController controller;
    protected float acclX;
    protected float acclZ;
    protected partial void Movement(Vector3 Movement)
    {
        //TODO: Use The entity's profile
        float movespeed = testmovespeed;
        float jumpspeed = testjumpspeed;
        float backwardMovement = Input.GetAxisRaw(backwardaxis) == -1f ? 0.4f : 1f;

        //side to side movement
        MoveVector.x = Movement.x * movespeed;
        //forward back movement
        MoveVector.z = Movement.z * movespeed;

        if (controller.isGrounded)
        {
            if (Movement.y > 0)
            {
                MoveVector.y =
                jumpspeed;
            }
        }
        if (!controller.isGrounded)
        {
            //TODO: add logic so that top speed can't be made but it can be kept while in air, so that you get limited air control
            MoveVector.x *= 0.85f;
            MoveVector.z *= 0.85f;
        }



        MoveVector.y -= gravity * Time.deltaTime;
        MoveVector = transform.TransformVector(MoveVector);
        //TODO replace character controller
        controller.Move(MoveVector * Time.deltaTime);
    }







}