using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerHealth : MonoBehaviour {

    private Text[] playerInfo;
    private SceneManager sceneManager;

    void OnEnable()
    {
        playerInfo = GetComponentsInChildren<Text>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < sceneManager.PlayerReferences.Length; i++)
        {
            playerInfo[i].text = "Player " + i + ": " + sceneManager.PlayerReferences[i].HealthPoint;
        }
	}
}
