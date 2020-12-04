using UnityEngine;

//using UnityEngine.
using System.Collections;


//TODO: this stuff will be moved the the GUI Controller and will have its values written to a systemsettings file that will be saves as a options.dat file.
public class ScreenController : MonoBehaviour
{
	public int width;
	public int height;
	public bool fullscreen;
	public bool boarder;
	// Use this for initialization
	void Start ()
	{
//		this.setWindowLong
		Screen.SetResolution (width, height, fullscreen);
//		Screen.
//		Window
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Screen.width != width || Screen.fullScreen != fullscreen || Screen.height != height)
			Screen.SetResolution (width, height, fullscreen);
		
	}
}
