using UnityEngine;
using System.Collections;

public class TankInput : MonoBehaviour
{

    public float rotationSpeed = 10f;
    public float speedBoost = 20;
    private int m_playerID;

    private string m_inputMovementAxisName;
    private string m_inputRotationAxisName; 

    private float m_inputMovement;
    private float m_inputRotation;

    private Rigidbody m_rigidbody;

    private bool m_isActive = true;

    public void test(bool b)
    {
        Debug.Log("test: " + b);
    }

    /// <summary>
    /// Move the Player Forward
    /// </summary>
    private void Move()
    {
        m_inputMovement = Input.GetAxis(m_inputMovementAxisName);
        Vector3 movement = transform.forward * speedBoost * m_inputMovement * Time.deltaTime;

        m_rigidbody.MovePosition(m_rigidbody.position + movement);

    }

    /// <summary>
    /// Rotate the Player based on the input of the Player
    /// </summary>
    private void Rotate()
    {
        m_inputRotation = Input.GetAxis(m_inputRotationAxisName);
    
        float turn = m_inputRotation * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f,turn,0f);
        m_rigidbody.MoveRotation(m_rigidbody.rotation * turnRotation);

    }

    /// <summary>
    /// Update the Inputs of the Player per Step 
    /// </summary>
    void FixedUpdate()
    {
        if (m_isActive)
        {
            Debug.Log("isActive: " + m_isActive);
            Move();
            Rotate();
        }
        
    }

    public void Init(int m_playerID)
    {
        this.m_playerID = m_playerID; 

        m_inputMovementAxisName = "Vertical" + m_playerID;
        m_inputRotationAxisName = "Horizontal" + m_playerID; 

        m_rigidbody = GetComponent<Rigidbody>();
    }

    
}
