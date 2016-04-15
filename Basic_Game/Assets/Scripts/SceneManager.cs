using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{

    // Startpunkte
    public Transform[] spawnPoints = new Transform[2];
    public Color[] playerColors;
    public GameObject prefabTank;

    // Camera of the Game. We have to reference the players for the CameraScript
    public CameraControl cameraRig;

    private EndGameHandler m_endHandler;
    private ShowPlayerHealth m_showPlayerHealth;

    private TankController[] m_playerReferences;

    public TankController[] PlayerReferences
    {
        get
        {
            return m_playerReferences; 
        }

        private set
        {
            m_playerReferences = value; 
        }
    }


    /// <summary>
    /// Setup the Players in the Game
    /// </summary>
    public void OnEnable()
    {
        m_playerReferences = new TankController[spawnPoints.Length];
        //m_endHandler = new EndGameHandler();
        //m_showPlayerHealth = new ShowPlayerHealth();

        //m_showPlayerHealth.gameEnded += m_endHandler.OnGameEnded;


        for (int i =0; i<m_playerReferences.Length; i++)
        {
            GameObject obj = Instantiate(prefabTank,spawnPoints[i].position,spawnPoints[i].rotation) as GameObject;
            obj.name = "Playertank" + i;

            m_playerReferences[i] = obj.GetComponent<TankController>();
            m_playerReferences[i].Init(i,spawnPoints[i], playerColors[i]);
            //m_endHandler.Init();
            cameraRig.m_Targets[i] = obj.transform; 
        }
    }
}
