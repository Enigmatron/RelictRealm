using UnityEngine;
using System.Collections;


public class MatchGUIController : MonoBehaviour
{
	public delegate void EscapeMenu();
	//public static event EscapeMenu pause;
	//public static event EscapeMenu unPause;

	private bool showInventory = false;
	private bool showOptions = false;

	private Rect windowRect = new Rect(Screen.width / 3, 0, Screen.width / 3, Screen.width / 4);
	string win1ToolTip;

	//TODO Load in save files that will be called on to set the values for the character
	void Awake () {
		Application.targetFrameRate = 120;
	}

	//
	void OnGUI(){
		if (showInventory)
			GUI.Box (new Rect (Screen.width / 4, 0, Screen.width / 2, Screen.height / 2.5f), "");
		
		if (showOptions) {
			windowRect = GUILayout.Window(1, windowRect, DoMyWindow, "Option Windows");
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
		} else {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
	
	//
	void DoMyWindow(int windowID) {
		GUI.DragWindow();
		if (GUILayout.Button("Options")) {
			
		}
		if (GUILayout.Button("Controls")) {
			
		}
		if (GUILayout.Button( "Exit Game")) {
			Application.Quit();
		}
		
	}
	void FixedUpdate(){
		Debug.Log (Time.deltaTime);
	}
	//
	void Update(){
		Debug.Log (Time.deltaTime);
		if (Input.GetKey (KeyCode.Tab) && !showOptions)
			showInventory = true;
		else
			showInventory = false;
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			showOptions = !showOptions;
			showInventory = false;
		}
		if(showOptions)
			showInventory = false;
}
}
