using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    //Startpunkte
    public Transform[] spawnPoints = new Transform[2];
    public GameObject prefabTank;

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

    public void OnEnable()
    {
        m_playerReferences = new TankController[spawnPoints.Length];

        for(int i = 0; i < m_playerReferences.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(prefabTank, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject;
            obj.name = "Playertank" + i;

            m_playerReferences[i] = obj.GetComponent<TankController>();
            m_playerReferences[i].Init(i, spawnPoints[i]);
        }
    }

	
}
