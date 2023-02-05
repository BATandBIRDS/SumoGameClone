using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowerStronger : MonoBehaviour
{
    /// <summary>
    /// 
    ///  WHAT COLLECTING DIAMONDS BRINGS TO THE PLAYER
    /// 
    /// </summary>

    Rigidbody rb;

    [SerializeField] float characterSpeed = 0.005f;
    [SerializeField] float bonusSpeed = 0.003f;
    [SerializeField] float growingFactor = .2f;
    [SerializeField] float massGain = 10f;
    [SerializeField] ParticleSystem growingEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // constant force
        transform.Translate(0, 0, characterSpeed);
    }

    // Growing
    void OnTriggerEnter(Collider other)
    {
        // when a character takes a diamond,
        // gain MASS, SPEED, and VOLUME.

        if (other.gameObject.tag == "Diamond")
        {
            growingEffect.Play();

            // Volume
            rb.transform.localScale += new Vector3(growingFactor, growingFactor, growingFactor);
            
            // Mass
            rb.mass += massGain;
            
            // Speed
            characterSpeed += bonusSpeed;
        }
    }
}
