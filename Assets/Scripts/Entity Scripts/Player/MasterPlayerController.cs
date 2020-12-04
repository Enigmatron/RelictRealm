using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using ItemSystem;
using EntityType;

//TODO
//Add Step_Movement Compatibility
//Add Movement Prediction
//
public class MasterPlayerController :  MoveableEntity /* NetworkBehaviour */
{


    #region variables

    

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

    /// <summary>
    /// Movement for this entities. need to move it to an abstract class to implement AI capabilities; moved to entitytemplate
    /// </summary>
    // #region movement control





    /// <summary>
    /// Player's input control. remove the controls for the gui and move it to another
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


    
    /// <summary>
    /// GUI Controls for the player, this does not belong in this class as it would be applicable on other screens without the player.
    /// </summary>
    #region GUI controls

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
            Debug.Log("Options");
        }
        if (GUILayout.Button("Controls"))
        {
            Debug.Log("Controls");
        }
        if (GUILayout.Button("Exit Game"))
        {
            Debug.Log("Exit");
        }

    }

    #endregion

    

    #region Unity Lifecycle Methods

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
        Movement(new Vector3(
            Input.GetAxisRaw("Horizontal"), Input.GetButtonDown("Jump")?1.0f: 0.0f, Input.GetAxisRaw("Vertical")
            ));
    }


    void FixedUpdate()
    {

        //Debug.Log (Time.deltaTime);
        //Debug.DrawRay(TargetCast.origin, TargetCast.direction);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log (Rig.MaxXP);

        //TODO move this to another method: camera rotation controlls
        angleX = new Vector3(0, Input.GetAxis("Mouse X") * 3f, 0);
        transform.eulerAngles += angleX;

    }

    #endregion


}