using UnityEngine;
using System.Collections;

public class ShellExplosion : MonoBehaviour {


    public GameObject explosion;
    public float radius = 5f;
    public float maximalDamage = 20f;
    public float m_ExplosionForce = 1000f; 

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Boom");
        Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
        Collider[] targets =  Physics.OverlapSphere(collision.contacts[0].point,radius);

        foreach(Collider col in targets)
        {
            TankController playerController = col.gameObject.GetComponent<TankController>();
            
            // Health
            if(playerController)
            {
                playerController.HealthPoint -= CalculateDamage(col.transform.position);
            }

            //ExplosionEffect
            Rigidbody element_rigidbody = col.GetComponent<Rigidbody>(); 
            if (element_rigidbody)
            {
                element_rigidbody.AddExplosionForce(m_ExplosionForce, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
    

    private int CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionCenterToTarget = targetPosition - transform.position;

        float explosionsDistance = explosionCenterToTarget.magnitude;

        float relativeDistance = (radius - explosionsDistance) / radius;

        float damage = relativeDistance * maximalDamage;

        damage = Mathf.Max(0f, damage);

        return (int)damage; 
    }
}
