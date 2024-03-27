using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granate : MonoBehaviour
{
    
    public float dealy = 0.5f;
    public float damage = 50;

   
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", dealy);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion =Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        explosion.GetComponent<Destroyer>().damage = damage;
        
    }
} 
