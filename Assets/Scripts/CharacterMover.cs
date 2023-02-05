using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    /// <summary>
    /// 
    /// THIS SCRIPT is only exist for testing purposes on PC.
    /// 
    /// DUE TO THIS:
    /// 
    /// the FREEZING WHILE ROTATING bug caused by increased mass,
    /// and unwell adjusted friction values are not considered
    /// as a problem that should have been fixed.
    ///                                 -Savran
    /// 
    /// </summary>
    
    [SerializeField] float torqueAmount = 50f;
    Vector3 torqueVector;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        torqueVector = new Vector3(0, torqueAmount, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();      
    }

    // PC Rotation mechanics for player
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(torqueVector);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-torqueVector);
        }
    }
}
