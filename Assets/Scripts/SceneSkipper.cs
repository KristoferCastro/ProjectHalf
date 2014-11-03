using UnityEngine;
using System.Collections;

public class SceneSkipper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)){
			Application.LoadLevel ("MainMenu");
		}
	
		if (Input.GetKeyDown (KeyCode.F1)){
			Application.LoadLevel ("IntroScenePreTalking");
		}
		
		if (Input.GetKeyDown (KeyCode.F2)){
			Application.LoadLevel ("IntroScene");
			
		}
		
		if (Input.GetKeyDown (KeyCode.F3)){
			Application.LoadLevel ("ToFriendsHouseScenePreTalking");
			
		}
		
		if (Input.GetKeyDown (KeyCode.F4)){
			Application.LoadLevel ("ToFriendsHouseScene");
			
		}
		
		if (Input.GetKeyDown (KeyCode.F5)){
			Application.LoadLevel ("FriendsHouseScenePreTalking");
			
		}
		
		if (Input.GetKeyDown (KeyCode.F6)){
			Application.LoadLevel ("FriendsHouseScene");
			
		}
		
		if (Input.GetKeyDown (KeyCode.F7)){
			Application.LoadLevel ("FriendsHouseScenePostTalking");
			
		}
		
		if (Input.GetKeyDown (KeyCode.F8)){
			Application.LoadLevel ("HDBuildingScenePreTalking");
		}
		
		if (Input.GetKeyDown (KeyCode.F9)){
			Application.LoadLevel ("HDBuildingScene");
		}
		
		if (Input.GetKeyDown (KeyCode.F10)){
			Application.LoadLevel ("HDBossPreTalking");
		}
		
		if (Input.GetKeyDown (KeyCode.F11)){
			Application.LoadLevel ("BossBattleAScene");
		}
		
		if (Input.GetKeyDown (KeyCode.F12)){
			Application.LoadLevel ("BossBattleBScene");
		}
		
		if (Input.GetKeyDown (KeyCode.R)){
			Debug.Log ("resetted preferences");
			PlayerPrefs.SetInt(PlayerPrefVariables.BAD_COUNT, 0);
			PlayerPrefs.SetInt(PlayerPrefVariables.GOOD_COUNT, 0);
			PlayerPrefs.SetInt(PlayerPrefVariables.KILL_COUNT, 0);
			PlayerPrefs.SetInt(PlayerPrefVariables.TOTAL_MEMBERS, 0);
			PlayerPrefs.SetInt(PlayerPrefVariables.POWER_USAGE, 0);		
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha0)){
			Application.LoadLevel("EndScene");
		}
		
		if (Input.GetKeyDown(KeyCode.Space)){
			//Debug.Log (PlayerPrefs.GetInt(PlayerPrefVariables.POWER_USAGE));
			int powerUsage = PlayerPrefs.GetInt(PlayerPrefVariables.POWER_USAGE)+1;
			PlayerPrefs.SetInt (PlayerPrefVariables.POWER_USAGE, powerUsage);
		}
		
	}
}
