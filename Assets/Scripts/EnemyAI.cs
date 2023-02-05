using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public List<Transform> diamonds = new List<Transform> ();
    [SerializeField] float enemyRotationSpeed = 50f;

    Vector3 destination;
    float temp = 60f; // stage size
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    void Update()
    {
        FindAndLook();
    }

    public void FindAndLook()
    {
        //FIND
        foreach (Transform diamond in diamonds)
        {
            if (diamond != null)
            {
                if (Vector3.Distance(rb.transform.position, diamond.position) < temp)
                {
                    temp = Vector3.Distance(rb.transform.position, diamond.position);
                    destination = diamond.position;

                    Look();
                    
                }
                destination = Random.insideUnitSphere * 29;
            }
        }
    }

    public void Look()
    {
        var lookPos = destination - rb.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, rotation, Time.deltaTime * enemyRotationSpeed);
    }
}
