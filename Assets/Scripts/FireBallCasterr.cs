﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCasterr : MonoBehaviour
{ 
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    public float damage = 10;
    // Start  is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          var fireball =  Instantiate(fireballPrefab,fireballSourceTransform.position,fireballSourceTransform.rotation);
            fireball.damage = damage;
        }
    }
}
