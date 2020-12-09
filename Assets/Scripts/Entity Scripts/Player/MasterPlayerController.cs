using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

//TODO
//Add Step_Movement Compatibility
//Add Movement Prediction
//
public class MasterPlayerController :  ActiveEntity /* NetworkBehaviour */
{


    #region variables

    
    protected Transform charTrans;
    protected Vector3 angleX;
    private bool showInventory = false;
    private bool showOptions = false;
    private Rect windowRect = new Rect(Screen.width / 3, 0, Screen.width / 3, Screen.width / 4);
    string win1ToolTip;
    //


    #region Targetting Info
    //TODO
    //make targetter component
    public Ray TargetCast
    {
        get
        {
            return thirdCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
    public Vector3 TargetDirection{
        get{
            return TargetCast.direction;
        }
    }

    //TODO: get the target cast hit
    // public Transform TargetCastHit{
    //     get{
    //         return TargetCast.
    //     }
    //      set;
    // }

    #endregion
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
    

    #endregion

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
    protected override void Awake()
    {
        base.Awake();
        thirdCamera = GetComponentInChildren<Camera>();
    }
    protected override void Start()
    {
        base.Start();
        controller = GetComponent<CharacterController>();
        charTrans = transform.GetChild(0);
    }
    protected override void Update()
    {
        base.Update();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerInputControl();
        Movement(new Vector3(
            Input.GetAxisRaw("Horizontal"), Input.GetButtonDown("Jump")?1.0f: 0.0f, Input.GetAxisRaw("Vertical")
            ));
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void LateUpdate()
    {
        base.LateUpdate();
        angleX = new Vector3(0, Input.GetAxis("Mouse X") * 3f, 0);
        transform.eulerAngles += angleX;

    }

    #endregion


}