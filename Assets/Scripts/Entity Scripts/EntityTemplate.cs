using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


namespace EntityType
{


    /*
    //TODO replace with active entity
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
*/
    public abstract class ActiveEntity : MonoBehaviour
    {
        public enum TeamValue
        {
            Team1,
            Team2,
            Team3,
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
            //TODO Use The entity's profile
            float movespeed = testmovespeed;
            float jumpspeed = testjumpspeed;
            float backwardMovement = Input.GetAxisRaw(backwardaxis) == -1f ? 0.4f : 1f;

            //side to side movement
            MoveVector.x = Movement.x * backwardMovement * movespeed;
            //forward back movement
            MoveVector.z = Movement.z * backwardMovement * movespeed;

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
        SphereCollider EnemySphere;
        public bool Near_Enemy
        {
            get;
            protected set;
        }

        public bool Combat
        {
            get
            {
                return Near_Enemy || Damage_Timer.Finished;
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
        UnityEvent<List<Pair<int, ActiveEntity>>> EntityDetectionEvents;

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
        public Dictionary<ActiveEntity, int> nearEntities;

        public bool isEntityAlly(ActiveEntity other)
        {
            return false;
        }
        public bool isEntityEnemy(ActiveEntity other)
        {
            return true;
        }

        //TODO: has to be called on fixed update
        public void EntityDectionEventCall()
        {

        }

        //TODO
        public bool entityVisionCalc(ActiveEntity other){
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
                nearEntities.Add(ent,(int)EntityDetectionFlags.onEnter);
            }
        }

        protected void OnEntityExit(Collider other)
        {

            ActiveEntity ent = other.GetComponent<ActiveEntity>();
            if (ent != null)
            {
                //TODO add the appropriate flag
                nearEntities[ent] = MathLambda.FlagOn(nearEntities[ent],(int)EntityDetectionFlags.onExit);
                nearEntities[ent] = MathLambda.FlagOff(nearEntities[ent],(int)EntityDetectionFlags.OnVisionStay);
                nearEntities[ent] = MathLambda.FlagOn(nearEntities[ent],(int)EntityDetectionFlags.OnOutVision);
                //add code for calc vision;
            }
        }

        protected void OnEnemyStay(Collider other)
        {
            ActiveEntity ent = other.GetComponent<ActiveEntity>();
            if (ent != null)
            {
                nearEntities[ent] = MathLambda.FlagOn(nearEntities[ent],(int)EntityDetectionFlags.onStay);

                if(entityVisionCalc(ent)){
                    nearEntities[ent] = MathLambda.FlagOn(nearEntities[ent],(int)EntityDetectionFlags.OnVisionStay);
                }
                //add code for calc vision and update;

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
        Animation onDamageAnim;
        Animation onDeathAnim;
        UnityEvent onDeathEvent;
        UnityEvent onDamageEvent;
        #endregion

        EntityRegisterProfile Stats;
        EntityRegisterProfile Status;
        EntityRegisterProfile Buff;
        EntityRegisterProfile CC;
    }
    public abstract class PassiveEntity : MonoBehaviour
    {
        //how many hits till it dies;
        int hitcount;
        //the current counter
        int currentHitcount;
        //the physics involved in the system
        Rigidbody physics;

        Animation OnHitAnimationAnim;
        Animation OnDestructionAnimationAnim;
        UnityEvent onDeathEvent;
        UnityEvent onDamageEvent;



    }



}