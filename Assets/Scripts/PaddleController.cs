using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;

    private float targetPressed;
    private float targetRelease;


    private HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
       hinge =  GetComponent<HingeJoint>();

       targetPressed = hinge.limits.max;
       targetRelease = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        //MovePaddle();
    }

    private void ReadInput()
    {
        
        JointSpring jointSpring = hinge.spring;
        // Read Input here
        if(Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }
        hinge.spring = jointSpring;
    }

    //private void MovePaddle()
    //{
        //Move Paddle Here
    //}
}
