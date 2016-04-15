using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController m_gameController;

    void Start()
    {
        m_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if(other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            m_gameController.Gameover();
        }

        m_gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
