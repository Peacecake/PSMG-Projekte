using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

    private int m_playerID;
    private Transform m_spawnPoint;

    private int m_health;
    private int m_ammo;

    private TankInput m_inputManager;
    private TankShoot m_TankShoot;

    public int HealthPoint
    {
        get
        {
            return m_health;
        }
        set
        {
            m_health = value;
        }
    }


    public void Init(int m_playerID, Transform m_spawnPoint)
    {
        //Referenzen
        this.m_playerID = m_playerID;
        this.m_spawnPoint = m_spawnPoint;

        //Ressourcen
        m_health = 100;
        m_ammo = 100;

        //Input
        m_inputManager = GetComponent<TankInput>();
        m_inputManager.Init(m_playerID);

        m_TankShoot = GetComponentInChildren<TankShoot>();
        m_TankShoot.Init(m_playerID);

    }
}
