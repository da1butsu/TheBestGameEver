using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granate : MonoBehaviour
{
    
    public float dealy = 3;

   
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
        //GetComponent<StressReceiver>().
        
    }
} 
