using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{

    [Header("Object References")]
    [SerializeField] ParticleSystem leftSpray;
    [SerializeField] GameObject leftPlayer;
    [SerializeField] ParticleSystem rightSpray;
    [SerializeField] GameObject rightPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftSpray.Play();
            StartCoroutine(EnableCollider(leftPlayer));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            rightSpray.Play();
            StartCoroutine(EnableCollider(rightPlayer));
        }
    }

    IEnumerator EnableCollider(GameObject player)
    {
        player.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<BoxCollider>().enabled = false;
    }
}
