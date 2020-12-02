using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using ItemSystem;


//TODO
//Add Step_Movement Compatibility
//Add Movement Prediction
//
public class MasterPlayerController : MonoBehaviour /* NetworkBehaviour */
{
    //adding for commit
    #region
    Transform charTrans;
    Vector3 angleX;
    Vector3 angleCamera;
    Vector3 curr;
    Vector3 MoveVector = Vector3.zero;
    float currAcceleration;
    public float gravity = 32.2F;
    CharacterController controller;
    private bool showInventory = false;
    private bool showOptions = false;
    private Rect windowRect = new Rect(Screen.width / 3, 0, Screen.width / 3, Screen.width / 4);
    string win1ToolTip;
    //



    //TODO
    //make targetter component
    public Ray TargetCast
    {
        get
        {
            return thirdCamera.ScreenPointToRay(Input.mousePosition);
        }
    }

    public Camera thirdCamera = null;

    public Camera ThirdPersonCamera
    {
        get
        {
            return thirdCamera;
        }
        set
        {
            if (thirdCamera == null)
                thirdCamera = value;
        }
    }

    //
    RaycastHit hit;

    public RaycastHit Hit
    {
        get
        {
            return hit;
        }
    }
    //
    RaycastHit[] hits;

    public RaycastHit[] Hits
    {
        get
        {
            return hits;
        }
    }




    //public float? TargetRaycastAllDistance;
    //	RaycastHit[] TargetRaycastALL{
    //		get{
    //			return Physics.RaycastAll(thirdCamera.ScreenPointToRay(Input.mousePosition), TargetRaycastAllDistance);
    //		}
    //	}
    //
    public bool Near_Enemy
    {
        get
        {
            return true;
        }
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

    #endregion

    //

    #region movement controll

    /// <summary>
    /// Movement for this instance.
    /// </summary>
    float acclX;
    float acclZ;
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

	void BasicMovement(){
    	MoveVector.x = Input.GetAxisRaw("Horizontal")*testmovespeed;
		MoveVector.z = Input.GetAxisRaw("Vertical")*testmovespeed;
		MoveVector = transform.TransformVector(MoveVector);
        controller.Move(MoveVector * Time.deltaTime);
    }
    void AdvanceMovement()
    {
        float movespeed = testmovespeed;
        float jumpspeed = testjumpspeed;
        float backwardMovement = Input.GetAxisRaw(backwardaxis) == -1f ? 0.4f : 1f;

		#region commented out code
/*
// 		float backwardMovement = 1;
// 		// if (state == null)
// 		// 	state = GetComponentInParent<SovereignState> ();
// 		// Debug.Log (state.CompStat.Move_Speed);
// 		// Debug.Log (state.CompStat.Jump_Height);

if (controller.isGrounded) {
backwardMovement = Input.GetAxisRaw ("Horizontal") == -1f ? 0.4f : 1f;
//			MoveVector = new Vector3 (Input.GetAxisRaw ("Horizontal") * backwardMovement, 0, Input.GetAxisRaw ("Vertical") * backwardMovement);
}
else {
backwardMovement = Input.GetAxisRaw ("Horizontal") == -1f ? 0.2f : 0.4f;
//			MoveVector = new Vector3 (Input.GetAxisRaw ("Horizontal") * backwardMovement, 0, Input.GetAxisRaw ("Vertical") * backwardMovement);
}		
// MoveVector *= 
// // state.CompStat.Move_Speed;
// 12;

// MoveVector = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

////				- (state.CompStat.Move_Speed * state.StatusEffectVariables.Slow_Value);
//			MoveVector = transform.TransformDirection (MoveVector);
// MoveVector = transform.TransformDirection (MoveVector);
// if(state.StatusEffectVariables.isStun || state.StatusEffectVariables.isSnare){

// }
// else {
*/

/*
				// 	if (state.MoveCommands.Count != 0) {
				// 		foreach(IMovementCommand command in state.MoveCommands){
				// 			if (command.Finished)
				// 				state.MoveCommands.Remove (command);
				// 			else {
				// 				MoveVector += command.AcceleratedDirection * Time.deltaTime;
				// 				command.Refresh ();
				// 			}
				// 		}
				// }

			// }

			// if (controller.isGrounded) {
			// 	backwardMovement = Input.GetAxisRaw ("Vertical") == -1f ? 0.6f : 1;
			// 	MoveVector *= backwardMovement
			// 	//* state.CompStat.Move_Speed;
			// 	*12
			// 	;
			// }
			// else if (controller.isGrounded) {
			// 	backwardMovement = Input.GetAxisRaw ("Vertical") == -1f ? 0.4f : 0.6f;
			// 	MoveVector *= backwardMovement
			// 	//* state.CompStat.Move_Speed;
			// 	*12
			// 	;
			// }	
			// MoveVector = transform.TransformDirection (MoveVector);


	// 		if (Input.GetButtonDown ("Jump") && controller.isGrounded) {
	// //			MoveVector *= 0.85f;
	// 			MoveVector.y = 
	// 			//state.CompStat.Jump_Height;
	// 			12;
	// 		}	
*/
#endregion

		//side to side movement
        MoveVector.x = Input.GetAxisRaw("Horizontal") * backwardMovement * movespeed;
		//forward back movement
        MoveVector.z = Input.GetAxisRaw("Vertical") * backwardMovement* movespeed;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
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
        controller.Move(MoveVector * Time.deltaTime);
    }



    /// <summary>
    /// Player's input control.
    /// </summary>
    void PlayerInputControl()
    {

        if (Input.GetKey(KeyCode.Tab) && !showOptions)
        {
            showInventory = true;
        }
        else
        {
            showInventory = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showOptions = !showOptions;
            showInventory = false;

        }




        if (!showOptions)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (showOptions)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    #endregion

    //

    #region

    /// <summary>
    /// Raises the GU event.
    /// </summary>
    void OnGUI()
    {
        if (showInventory)
            GUI.Box(new Rect(Screen.width / 4, 0, Screen.width / 2, Screen.height / 2.5f), "");

        if (showOptions)
        {
            windowRect = GUILayout.Window(1, windowRect, DoMyWindow, "Option Windows");
        }
    }
    //
    void DoMyWindow(int windowID)
    {
        GUI.DragWindow();
        if (GUILayout.Button("Options"))
        {

        }
        if (GUILayout.Button("Controls"))
        {

        }
        if (GUILayout.Button("Exit Game"))
        {
            Debug.Log("Exit");
        }

    }

    #endregion

    //

    #region

    /// <summary>
    /// Awakens this instance.
    /// </summary>
    void Awake()
    {
        //		state = GetComponentInParent<SovereignState> ();

        thirdCamera = GetComponentInChildren<Camera>();
        //		Network.InitializeServer(8, 25000, false);

    }

    // void OnNetworkInstantiate (NetworkMessageInfo info)
    // {

    // 	Debug.Log ("New object instanted by me");

    // }

    //	public override void OnStartLocalPlayer ()
    //	{
    //		gameObject.SetActive (true);
    //	}


    void OnConnectedToServer()
    {
        //Network.Instantiate (gameObject, transform.position, transform.rotation, 0);
    }

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {

        controller = GetComponent<CharacterController>();
        charTrans = transform.GetChild(0);

    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerInputControl();
        AdvanceMovement();
    }

    /// <summary>
    /// Update the happens very frequently.
    /// </summary>
    void FixedUpdate()
    {

        //Debug.Log (Time.deltaTime);
        //Debug.DrawRay(TargetCast.origin, TargetCast.direction);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log (Rig.MaxXP);
        angleX = new Vector3(0, Input.GetAxis("Mouse X") * 3f, 0);
        transform.eulerAngles += angleX;

    }

    #endregion
}