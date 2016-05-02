using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	//初始化/
	private string info;//显示的信息/ 
	// Use this for initialization
	
	void Start () {
		
		info = "Click";  
		AdColony.OnVideoFinished = this.OnVideoFinished;

		AdColony.Configure
			(
				#if UNITY_IOS
				"version:1.0,store:google", // Arbitrary app version and Android app store declaration.
				"app17f205be345b4a4295",   // ADC App ID from adcolony.com
				"vz078460af5339456ebf" // A zone ID from adcolony.com
				
				#elif UNITY_ANDROID
				"version:1.0,store:google", // Arbitrary app version and Android app store declaration.
				"app60af58a8e2f542689d",   // ADC App ID from adcolony.com
				"vzce0ef362ad68471f97" // A zone ID from adcolony.com
				
				#endif
				);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PlayAVideo( string zoneID )
	{
		if (AdColony.IsV4VCAvailable (zoneID)) {
			info = " Availble";
			AdColony.ShowV4VC (false, zoneID);
		} else {
			info = " Not Availble";
		}
	}			

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect (50,  40, 400, Screen.width / 2));
		GUILayout.Label(info);
		if (GUI.Button (new Rect(20, 20, 100,  100) ,"Play  V4VC")) { 
			PlayAVideo("vzce0ef362ad68471f97");
		}
		GUILayout.EndArea(); 
	}

	private void OnVideoFinished(bool ad_was_shown)
	{
		Debug.Log("On Video Finished");
		// Resume your app here.
	}
}
