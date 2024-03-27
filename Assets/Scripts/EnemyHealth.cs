using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public float  experience = 10;
    public PlayerProgress playerProgress;

    void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public void DealDamage(float damage)
    {
        playerProgress.addExpereence(experience);
        value -= damage;
        if(value <= 0)
        {
            
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


}
