using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody granatePrefab;
    public Transform granateSoursTransform;
    public float force = 30f;
    public float damage = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var granate = Instantiate(granatePrefab);
            granate.transform.position = granateSoursTransform.position;
            granate.GetComponent<Rigidbody>().AddForce(granateSoursTransform.forward * force);
            granate.GetComponent<Granate>().damage = damage;

        }
        
    }
}
