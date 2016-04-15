using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EndGameHandler : MonoBehaviour {

    public GameObject wonMessage;
    private RectTransform m_wonMessage;

    private bool m_gameOver;
    private bool test;

	// Use this for initialization
	void OnEnable () {
        m_gameOver = false;
        Debug.Log("WonMessage: " + m_wonMessage);
    }

    public void OnGameEnded(bool status)
    {
        Debug.Log("OnGameEnded status: " + status);
        test = status;
    }


    private void changePanelVisibility(bool status)
    {
        wonMessage.SetActive(status);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update in EndGameHandler: " + m_gameOver);
        Debug.Log("Test: " + test);
        wonMessage.SetActive(m_gameOver);
    }
}
