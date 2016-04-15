using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class TankController : MonoBehaviour
{
    private Transform spawnPoint;
    private Color playerColor; 
    
    private int m_playerID;
    private int m_healthPoint;
    private int m_ammo;

    private TankInput m_inputController;
    private TankShoot m_tankShoot; 
    private Transform m_spawnPoint;

    public int HealthPoint
    {
        get
        {
            return m_healthPoint; 
        }

        set
        {
            m_healthPoint = value; 
        }
    }

    
    /// <summary>
    /// Setup all variables of the Player
    /// </summary>
    public void Init(int m_playerID, Transform m_spawnPoint, Color col)
    {
        // Referenzen
        this.m_spawnPoint = m_spawnPoint;
        this.m_playerID = m_playerID;
        this.playerColor = col; 

        // Ressourcen
        m_healthPoint = 100;
        m_ammo = 100;

        // Input
        m_inputController = GetComponent<TankInput>();
        m_inputController.Init(m_playerID);

        m_tankShoot = GetComponentInChildren<TankShoot>();
        m_tankShoot.Init(m_playerID);

        MeshRenderer[] rendererOfObjects = GetComponentsInChildren<MeshRenderer>();

        foreach(MeshRenderer renderer in rendererOfObjects)
        {
            renderer.material.color = playerColor; 
        }
    }
}
