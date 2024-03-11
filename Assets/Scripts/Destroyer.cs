using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float dealy = 2;
    public float damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("Destroyy", dealy);

        var playerHealf = other.GetComponent<PlayerHealth>();
        if (playerHealf != null)
        {
            playerHealf.DealDamage(damage);
        }

        var enemyHealf = other.GetComponent<EnemyHealth>();
        if(enemyHealf != null)
        {
            enemyHealf.DealDamage(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Destroyy()
    {
        Destroy(gameObject);
    }
}
 