using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour {

    private int m_playerID;
    private string m_fireAxisName;
    private Transform m_shootTransform;

	public void Init(int m_playerID)
    {
        m_shootTransform = GetComponent<Transform>();
        this.m_playerID = m_playerID;
        m_fireAxisName = "Fire" + m_playerID;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(m_fireAxisName))
        {
            Debug.Log("Shoot");

            Ray rayForCasting = new Ray(m_shootTransform.position, m_shootTransform.forward);
            RaycastHit hitInformation;

            Debug.DrawRay(rayForCasting.origin, rayForCasting.direction, Color.red);

            if(Physics.Raycast(rayForCasting, out hitInformation))
            {
                TankController enemy = hitInformation.collider.GetComponent<TankController>();

                if(enemy)
                {
                    enemy.HealthPoint -= 10;
                }
            }
        }
	}
}
