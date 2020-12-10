using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;





public abstract partial class ActiveEntity : Entity
{
    protected partial void OnEntityEnter(Collider other);
     protected partial void OnEnemyStay(Collider other);
    protected partial void OnEntityExit(Collider other);
    public partial bool entityVisionCalc(ActiveEntity other);
    public partial void EntityDectionEventCall();
    public partial bool isEntityNeutral(ActiveEntity other);
    public partial bool isEntityAlly(ActiveEntity other);
    public partial bool isEntityEnemy(ActiveEntity other);
    public enum TeamValue
    {
        Player1,
        Player2,
        Neutral,
    }
    #region Variables
    TeamValue team;

    #endregion

    #region Movement
    public float testmovespeed = 12;
    public float testjumpspeed = 20;
    public string backwardaxis = "Vertical";
    protected Vector3 MoveVector = Vector3.zero;
    protected float currAcceleration;
    public float gravity = 32.2F;
    protected CharacterController controller;
    protected float acclX;
    protected float acclZ;
    protected void Movement(Vector3 Movement)
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



    #endregion
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        detectionSphere = gameObject.GetComponent(typeof(SphereCollider)) as SphereCollider;

    }
    protected virtual void Update()
    {
        EntityDectionEventCall();
    }
    protected virtual void LateUpdate()
    {

    }
    protected virtual void FixedUpdate()
    {

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        OnEntityEnter(other);
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        OnEnemyStay(other);
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        OnEntityExit(other);
    }

    protected virtual void OnCollisionEnter(Collision collisionInfo)
    {

    }
    protected virtual void OnCollisionStay(Collision collisionInfo)
    {

    }

    protected virtual void OnCollisionExit(Collision collisionInfo)
    {

    }

    #region Damage System



    #endregion

    RegisterProfile Stats;
    RegisterProfile Buff;
    RegisterProfile CC;
}
public abstract partial class PassiveEntity : Entity
{
    //how many hits till it dies;
    int hitcount;
    //the current counter
    int currentHitcount;
    //the physics involved in the system
    Rigidbody physics;





}

public abstract partial class Entity : MonoBehaviour
{
    //TODO: add base stats here like shield and hp;


    RegisterProfile Stats;
    //damage queue can be cleared to allow a frame of invincibility on Shell break
    Queue<Damage> damageQueue;


    //TODO: add a thing so that DOTs can persist thru shells, NVM actually explanation in OneNote
    //List<DamageSources> DamageSources;
}
