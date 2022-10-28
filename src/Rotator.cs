using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Transform target;
    public float turnSpeed = 0.1f;
    Quaternion rotGoal;
    Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
    }
}
