using Microsoft.MixedReality.Toolkit.UI;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float thrust = 1.0f;    
    public GameObject robotGameObject;
    public GameObject explosionGameObject;

    private GameObject target;
    private Transform targetTransform;
    private Vector3 towardsTarget = Vector3.zero;
    private Animator anim;
    private bool onGround = false;
    private float radius = 0.4f;

    void OnEnable()
    {
        anim = GetComponent<Animator>();
        target = Camera.main.gameObject;

        if (targetTransform == null)
        {
            targetTransform = target.transform;
        }

        if (!anim.GetBool("Open_Anim"))
        {
            anim.SetBool("Open_Anim", true);
        }
        else
        {
            anim.SetBool("Open_Anim", false);
        }
    }

    
    void Update()
    {
        if (onGround)
        {
            towardsTarget = this.transform.position - targetTransform.position;

            towardsTarget.y = 0;

            towardsTarget.Normalize();

            transform.LookAt(targetTransform);

            if (Vector3.Distance(transform.position, targetTransform.position) > radius)
            {
                transform.Translate(towardsTarget * thrust * Time.deltaTime);
                anim.SetBool("Walk_Anim", true);
            }
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 0.5)
        {
            onGround = true;
        }
    }

    public void DestroyRobot()
    {
        robotGameObject.SetActive(false);
        explosionGameObject.SetActive(true);
        Destroy(this.gameObject, 1);
    }   
}
