using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{

    [SerializeField] float sprayForce = 10f;

    Rigidbody rb;
    bool isSpiked;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spray") && !isSpiked)
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * sprayForce, ForceMode.Impulse);
        }
        else if(other.CompareTag("Goal"))
        {
            isSpiked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            isSpiked = false;
        }
    }

}
