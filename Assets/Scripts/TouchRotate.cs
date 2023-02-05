using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    /// <summary>
    /// 
    /// the LOGIC: What sign touch.position.(x and y) takes...
    /// 
    ///  Clockwise: A to B || D to C (Counterwise is opposite)
    ///  Clockwise: C to A || B to D (Counterwise is opposite)
    ///  
    /// *______________*
    /// |A     | B     |
    /// |  X+  |   X+  |   <--- Screen
    /// |  Y+  |   Y-  |
    /// |      |       |
    /// |______|_______|       the Code below finds
    /// |C     | D     |        in which area user is swiping,
    /// |      |       |       and which direction
    /// |  X-  |   X-  |        user wants to rotate the character.
    /// |  Y+  |   Y-  |        then, it does the job...
    /// |______|_______|                       
    ///                                        -Savran Donmez
    /// </summary>

    Touch touch;
    Quaternion rotationY;
    
    [SerializeField] float rotateSpeed = 0.1f;
    
    int rotateSignX; 
    int rotateSignY;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // #195f from below code.
                //Debug.Log(touch.position.y.ToString());

                // #135f from below code.
                //Debug.Log(touch.position.x.ToString());

                // which is the position Y and X of the player on screen.

                if (touch.position.y < 195f) { rotateSignY = -1; }
                else { rotateSignY = 1; }

                if (touch.position.x < 135f) { rotateSignX = 1; }
                else { rotateSignX = -1; }

                // Rotate according to X movement
                if (touch.deltaPosition.x >= touch.deltaPosition.y)
                {
                    rotationY = Quaternion.Euler(0, rotateSignY * touch.deltaPosition.x * rotateSpeed, 0);
                    transform.rotation *= rotationY;
                }

                // Rotate according to Y movement
                else
                {
                    rotationY = Quaternion.Euler(0, rotateSignX * touch.deltaPosition.y * rotateSpeed, 0);
                    transform.rotation *= rotationY;
                }
                
            }
        }
    }
}
