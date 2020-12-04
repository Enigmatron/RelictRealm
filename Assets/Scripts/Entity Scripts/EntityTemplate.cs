﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace EntityType{
    

    public abstract class MoveableEntity : ActiveEntity{
        #region Variables
        protected Transform charTrans;
        protected Vector3 angleX;
        protected Vector3 angleCamera;
        protected Vector3 curr;
        protected Vector3 MoveVector = Vector3.zero;
        protected float currAcceleration;
        public float gravity = 32.2F;
        protected CharacterController controller;
        protected float acclX;
        protected float acclZ;
    /*
    public float accelerationCoeffX
    {
        get
        {
            return Mathf.Sqrt((Mathf.Pow((acclX) / 2, 3)));
        }
    }

    public float accelerationCoeffZ
    {
        get
        {
            return Mathf.Sqrt((Mathf.Pow((acclZ) / 2, 3)));
        }
    }
    float lastDirectionX = 1;
    float lastDirectionZ = 1;
    */
    public float testmovespeed = 12;
    public float testjumpspeed = 20;
    public string backwardaxis = "Vertical";
    #endregion

        protected void Movement(Vector3 Movement)
        {
            //TODO Use The entity's profile
            float movespeed = testmovespeed;
            float jumpspeed = testjumpspeed;
            float backwardMovement = Input.GetAxisRaw(backwardaxis) == -1f ? 0.4f : 1f;

            //side to side movement
            MoveVector.x = Movement.x * backwardMovement * movespeed;
            //forward back movement
            MoveVector.z = Movement.z * backwardMovement* movespeed;

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
                MoveVector.x *= 0.85f;
                MoveVector.z *= 0.85f;
            }



            MoveVector.y -= gravity * Time.deltaTime;
            MoveVector = transform.TransformVector(MoveVector);
            //TODO replace character controller
            controller.Move(MoveVector * Time.deltaTime);
        }
    }
    
    public abstract class ComabatEnity : ActiveEntity
    {

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

    public abstract class ActiveEntity : MonoBehaviour{

    }
    public abstract class PassiveEntity : MonoBehaviour{

    }

}