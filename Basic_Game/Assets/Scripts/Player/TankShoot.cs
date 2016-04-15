using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour {

    public GameObject m_Shell;

    public float m_minimalLaunchForce = 15f;
    public float m_maximalLaunchForce = 30f;
    public float m_chargeTime = 0.75f; 
     
    private int m_playerID;
    private string m_fireButton;

    private Transform shootTransform;
    private bool m_Fired = false;

    private float m_CurrentLaunch;


    /// <summary>
    /// Init the component when the game starts
    /// </summary>
    /// <param name="m_playerID"></param>
    public void Init (int m_playerID) {

        // sace the Transform component
        shootTransform = GetComponent<Transform>();

        //Save the LayerID
        this.m_playerID = m_playerID;

        //Create the FireAxisname
        m_fireButton = "Fire" + m_playerID;  
	}
	
    /// <summary>
    /// Check the fireinput
    /// </summary>
	void Update () {

        // If the maximal Force is reached we have to shoot the bullet
        if(m_CurrentLaunch >= m_maximalLaunchForce && !m_Fired)
        {
            // force the maximal force
            m_CurrentLaunch = m_maximalLaunchForce;
            Fire();
        }

        // Button Down
        if(Input.GetButtonDown(m_fireButton))
        {
            m_Fired = false;
            m_CurrentLaunch = m_minimalLaunchForce; 
        }

        // Button holded
        else if(Input.GetButton(m_fireButton) && m_Fired == false)
        {
            m_CurrentLaunch += m_chargeTime * Time.deltaTime; 
        }

        // Button up
        else if(Input.GetButtonUp(m_fireButton) && m_Fired == false)
        {
            Fire(); 
        }
            
	}

    /// <summary>
    /// Fire a bullet
    /// </summary>
    private void Fire()
    {
        m_Fired = true;

        GameObject shellInstance = Instantiate(m_Shell,shootTransform.position, shootTransform.rotation) as GameObject;
        shellInstance.GetComponent<Rigidbody>().velocity = m_CurrentLaunch * shootTransform.forward;

        //Reset the Launchforce
        m_CurrentLaunch = m_minimalLaunchForce; 
        
    }
}
