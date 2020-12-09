using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace EntityType{
    

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
    public abstract class ActiveEntity : MonoBehaviour{

        #region Variables
        protected Transform charTrans;
        protected Vector3 angleX;
        protected Vector3 angleCamera;
        protected Vector3 curr;

    

    #region Movement
    public float testmovespeed = 12;
    public float testjumpspeed = 20;
    public string backwardaxis = "Vertical";
    #endregion
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

        #endregion
        protected virtual void Awake(){

        }
        protected virtual void Start(){
            EnemySphere = gameObject.GetComponent(typeof(SphereCollider)) as SphereCollider;

        }
        protected virtual void Update(){

        }
        protected virtual void LateUpdate(){

        }
        protected virtual void FixedUpdate(){

        }

        #region enemy detection and combat timer
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

        public UnityEvent<List<ActiveEntity>> onCombatEvent{get; protected set;}
        public UnityEvent<List<ActiveEntity>> onEnemyTriggerEnter{get; protected set;}
        public UnityEvent<List<ActiveEntity>> onEnemyTriggerExit{get; protected set;}
        public UnityEvent<List<ActiveEntity>> onOutOfCombat{get; protected set;}

        protected 

        protected  

        #endregion
        protected virtual void OnTriggerEnter(Collider other){
            
        }
        protected virtual void OnTriggerExit(Collider other){
        
        }
        protected virtual void OnTriggerStay(Collider other){

        }

    void OnCollisionStay (Collision collisionInfo)
	{
		
	}

	void OnCollisionExit (Collision collisionInfo)
	{

	}

    #region Damage System
        Animation onDamageAnim;
        Animation onDeathAnim;
        UnityEvent onDeathEvent;
        UnityEvent onDamageEvent;
    #endregion

        EntityRegisterProfile profile;
    }
    public abstract class PassiveEntity : MonoBehaviour{
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