using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikColision : MonoBehaviour
{
    public AudioSource sfx_point;



    private void Start()
    {
        sfx_point = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "finish")
        {
            sfx_point.Play();
        }

    }
}
