using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;




    
    public abstract class ActiveEntity : Entity
    {
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
            EnemySphere = gameObject.GetComponent(typeof(SphereCollider)) as SphereCollider;

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

        #region EntityDetection

        //TODO: add the combat timer: a timer that resets on damage taken; the section is gonna be indeterminant for now;
        SphereCollider EnemySphere;
        public bool NearVisibleEnemy
        {
            get;
            protected set;
        }
        public bool NearEnemy
        {
            get;
            protected set;
        }
        public bool NearVisibleAlly
        {
            get;
            protected set;
        }
        public bool NearAlly
        {
            get;
            protected set;
        }
        public bool NearVisibleNeutral
        {
            get;
            protected set;
        }
        public bool NearNeutral
        {
            get;
            protected set;
        }

        public bool Combat
        {
            get
            {
                return NearEnemy || Damage_Timer.Finished;
            }
        }

        //this is for the out of combat system
        ProgressionStateMachine damage_timer;

        public ProgressionStateMachine Damage_Timer
        {
            get
            {
                return damage_timer;
            }
        }

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        RaycastHit entityDetectionHit;
        [Flags]
        public enum EntityDetectionFlags : byte
        {
            onEnter = 1,
            onStay = 2,
            onExit = 4,
            onInVision = 8,
            OnVisionStay = 16,
            OnOutVision = 32,
        }
        //replace the events below
        //the int is a flag for what event is being called whether it is true or not;
        //ActiveEntity is the subject of the event;
        //The events need to decern what teamvalue the entity has
        //the 
        UnityEvent<Dictionary<ActiveEntity, int>> EntityDetectionEvents;

        /*
        // public UnityEvent<List<ActiveEntity>> onCombatEvent { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onEnemyTriggerEnter { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onAllyTriggerEnter { get; protected set; }

        // public UnityEvent<List<ActiveEntity>> onEnemyTriggerExit { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onAllyTriggerExit { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onEnemyInVision { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onAllyInVision { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onEnemyOutVision { get; protected set; }
        // public UnityEvent<List<ActiveEntity>> onAllyOutVision { get; protected set; }

        // public UnityEvent<List<ActiveEntity>> onOutOfCombat { get; protected set; }
        */


        //uses the same flag as EntityDectionEvents
        //the flag can tell you if the entity is in vision
        //these are kept seperate as to maintain the isnearvariable for both to quickly get out of combat
        public Dictionary<ActiveEntity, int> nearAllies;
        //neutral is
        public Dictionary<ActiveEntity, int> nearEnemies;
        public Dictionary<ActiveEntity, int> nearNeutrals;


        public bool isEntityAlly(ActiveEntity other)
        {
            return other.team == team;
        }
        public bool isEntityEnemy(ActiveEntity other)
        {
            return other.team != team && other.team != TeamValue.Neutral;
        }
        public bool isEntityNeutral(ActiveEntity other)
        {
            return other.team == TeamValue.Neutral;
        }


        //TODO: has to be called on fixed update
        public void EntityDectionEventCall()
        {

        }

        //TODO: write the code, use ray cast and check the head, upper legs, and body and return tru if any are 'seen'
        public bool entityVisionCalc(ActiveEntity other)
        {
            return true;
        }

        //add to a dictionary of near enemies and detect if they're in vision
        //if: in vision then: add to in vision entities of enemies or allies;
        //if: not in vision then: add enemies and allies to dictionary of such;
        protected void OnEntityEnter(Collider other)
        {
            ActiveEntity ent = other.GetComponent<ActiveEntity>();
            if (ent != null)
            {
                if (isEntityEnemy(ent))
                {
                    nearEnemies.Add(ent, (int)EntityDetectionFlags.onEnter);
                    NearEnemy = true;
                }
                if (isEntityAlly(ent))
                {
                    nearAllies.Add(ent, (int)EntityDetectionFlags.onEnter);
                    NearAlly = true;
                }
                if (isEntityNeutral(ent))
                {
                    nearNeutrals.Add(ent, (int)EntityDetectionFlags.onEnter);
                    NearNeutral = true;
                }
            }
        }

        protected void OnEntityExit(Collider other)
        {

            ActiveEntity ent = other.GetComponent<ActiveEntity>();
            if (ent != null)
            {
                //TODO: add the appropriate flag
                if (isEntityAlly(ent))
                {
                    nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlags.onExit);
                    nearAllies[ent] = MathLambda.FlagOff(nearAllies[ent], (int)EntityDetectionFlags.OnVisionStay);
                    nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlags.OnOutVision);
                }
                if (isEntityEnemy(ent))
                {
                    nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlags.onExit);
                    nearEnemies[ent] = MathLambda.FlagOff(nearEnemies[ent], (int)EntityDetectionFlags.OnVisionStay);
                    nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlags.OnOutVision);
                }
                if (isEntityNeutral(ent))
                {
                    nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlags.onExit);
                    nearNeutrals[ent] = MathLambda.FlagOff(nearNeutrals[ent], (int)EntityDetectionFlags.OnVisionStay);
                    nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlags.OnOutVision);
                }
                //add code for calc vision;
            }
        }

        protected void OnEnemyStay(Collider other)
        {
            ActiveEntity ent = other.GetComponent<ActiveEntity>();
            if (ent != null)
            {
                if (isEntityAlly(ent))
                {
                    nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlags.onStay);
                }
                if (isEntityEnemy(ent))
                {
                    nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlags.onStay);
                }
                if (isEntityNeutral(ent))
                {
                    nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlags.onStay);
                }

                if (entityVisionCalc(ent))
                {
                    if (isEntityAlly(ent))
                    {
                        nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlags.OnVisionStay);
                    }
                    if (isEntityEnemy(ent))
                    {
                        nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlags.OnVisionStay);
                    }
                    if (isEntityNeutral(ent))
                    {
                        nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlags.OnVisionStay);
                    }
                }
            }
        }

        #endregion
        protected virtual void OnTriggerEnter(Collider other)
        {
            OnEntityEnter(other);
        }
        protected virtual void OnTriggerExit(Collider other)
        {
            OnEntityExit(other);
        }
        protected virtual void OnTriggerStay(Collider other)
        {
            OnEnemyStay(other);
        }

        protected virtual void OnCollisionStay(Collision collisionInfo)
        {

        }

        protected virtual void OnCollisionExit(Collision collisionInfo)
        {

        }

        #region Damage System
       


        #endregion

        EntityRegisterProfile Stats;
        EntityRegisterProfile Status;
        EntityRegisterProfile Buff;
        EntityRegisterProfile CC;
    }
    public abstract class PassiveEntity : Entity
    {
        //how many hits till it dies;
        int hitcount;
        //the current counter
        int currentHitcount;
        //the physics involved in the system
        Rigidbody physics;

        



    }

    public abstract class Entity : MonoBehaviour{
        //TODO: add base stats here like shield and hp;



        //remove these as they can be placed in the registerProfile
        Animation onDamageAnim;
        Animation onDeathAnim;
        UnityEvent onDeathEvent;
        UnityEvent onDamageEvent;

        //damage queue can be cleared to allow a frame of invincibility on Shell break
        Queue<Damage> damageQueue;


        //TODO: add a thing so that DOTs can persist thru shells, NVM actually explanation in OneNote
        //List<DamageSources> DamageSources;
    }
