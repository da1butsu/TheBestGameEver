using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;

    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFarreBall", lifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveFixUpdate();

    }

    private void MoveFixUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void DestroyFarreBall()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);

        DestroyFarreBall();
    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }

    }
}