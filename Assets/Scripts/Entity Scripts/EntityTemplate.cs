using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;





public abstract partial class ActiveEntity : Entity
{
    #region Partial Region
    protected partial void OnEntityEnter(Collider other);
     protected partial void OnEnemyStay(Collider other);
    protected partial void OnEntityExit(Collider other);
    public partial bool entityVisionCalc(ActiveEntity other);
    public partial void EntityDectionEventCall();
    public partial bool isEntityNeutral(ActiveEntity other);
    public partial bool isEntityAlly(ActiveEntity other);
    public partial bool isEntityEnemy(ActiveEntity other);
    protected partial void Movement(Vector3 Movement);
    #endregion
    public enum TeamValue
    {
        Player1,
        Player2,
        Neutral,
    }
    #region Variables
    TeamValue team;

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
