using UnityEngine;
using System.Collections;

public class TankInput : MonoBehaviour {

    private float speedBoost = 10;
    private float rotationSpeed = 100;

    private int m_playerID;

    private string m_inputMovementAxisName;
    private string m_inputRotateAxisName;

    private float m_inputMovement;
    private float m_inputRotate;

    private Rigidbody m_rigitbody;


	private void Move()
    {
        m_inputMovement = Input.GetAxis(m_inputMovementAxisName);
        Vector3 movement = transform.forward * speedBoost * m_inputMovement * Time.deltaTime;

        m_rigitbody.MovePosition(m_rigitbody.position + movement);
    }

    private void Rotate()
    {
        m_inputRotate = Input.GetAxis(m_inputRotateAxisName);

        float turn = m_inputRotate * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_rigitbody.MoveRotation(m_rigitbody.rotation * turnRotation);

    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Init(int m_playerID)
    {
        this.m_playerID = m_playerID;
        m_inputMovementAxisName = "Vertical" + m_playerID;
        m_inputRotateAxisName = "Horizontal" + m_playerID;

        m_rigitbody = GetComponent<Rigidbody>();
    }
}
