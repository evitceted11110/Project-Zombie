using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private bool nat;

	// Use this for initialization
	void Start () {
//		nat = Network.HavePublicAddress;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartServer () {
		Network.InitializeServer (32, 25001, false);
		MasterServer.RegisterHost ("DännisMultiplayerTestGame", "My Game", "Just a test game");
	}

	void OnServerInitialized () {
		Debug.Log ("Server Initizliaed");
	}

	void OnMasterServerEvent (MasterServerEvent mse) {
		if (mse == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log("Registrated Server");
		}
	}

	void OnGUI () {
	
		if (GUI.Button (new Rect (10, 10, Screen.width / 3, Screen.height / 3), "Start Server")) {
			StartServer();
			Debug.Log("Starting Server");
		}

		if (GUI.Button (new Rect (10, 10 + Screen.height / 3, Screen.width / 3, Screen.height / 3), "Refresh")) {

			Debug.Log("Refreshing");
		}
	}
}
