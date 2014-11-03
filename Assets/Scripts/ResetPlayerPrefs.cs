using UnityEngine;
using System.Collections;

public class ResetPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt(PlayerPrefVariables.BAD_COUNT, 0);
		PlayerPrefs.SetInt(PlayerPrefVariables.GOOD_COUNT, 0);
		PlayerPrefs.SetInt(PlayerPrefVariables.KILL_COUNT, 0);
		PlayerPrefs.SetInt(PlayerPrefVariables.TOTAL_MEMBERS, 0);
		PlayerPrefs.SetInt(PlayerPrefVariables.POWER_USAGE, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
