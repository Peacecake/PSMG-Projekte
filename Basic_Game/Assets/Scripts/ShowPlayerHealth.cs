using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ShowPlayerHealth : MonoBehaviour {

    private SceneManager m_sceneManager;
    private Text[] m_playerHealth;
    //private Text[] winner;

    public delegate void GameEndedEventHandler(bool status);
    public event GameEndedEventHandler gameEnded;

    // Use this for initialization
    void OnEnable () {
        m_sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        m_playerHealth = GetComponentsInChildren<Text>();
        //winner = GameObject.Find("winnerText").GetComponentsInChildren<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < m_sceneManager.PlayerReferences.Length; i++)
        {
            m_playerHealth[i].text = "Health: " + m_sceneManager.PlayerReferences[i].HealthPoint;
            checkIfPlayerWon(i); 
        }
	}

    private void checkIfPlayerWon(int i)
    {
        if (m_sceneManager.PlayerReferences[i].HealthPoint <= 0)
        {
            m_playerHealth[i].text = "Health: 0";

            //Send Info to EndGameHandler
            EndGameHandler endGameHandler = new EndGameHandler();
            this.gameEnded += endGameHandler.OnGameEnded;
            OnGameEnded();
        } 
    }

    protected virtual void OnGameEnded()
    {
        if(gameEnded != null)
        {
            Debug.Log("ShowHealth: Game over");
            gameEnded(true);
        }
    }
}
