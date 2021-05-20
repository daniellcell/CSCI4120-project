using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PushObject : MonoBehaviour
{
    public float ObMass = 300;
    public float PushAtMass = 100;
    public float PushingTime;
    public float ForceToPush;
    Rigidbody rb;
    public float vel;
    Vector3 dir;

    Vector3 lastPos;
    float _PushingTime = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) return;

        rb.mass = ObMass;
    }

    bool IsMoving()
    {
        if (rb.velocity.magnitude > 0.06f)
        {
            return true;
        }
        return false;

    }

    private void Update()
    {
        vel = rb.velocity.magnitude;
        GameObject player = GameObject.FindWithTag("Player");
        Animator anim;
        anim = player.GetComponent<Animator>();
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Push"))
        {
            rb.isKinematic = true;

        }

        if (rb.isKinematic == false)
        {
            _PushingTime += Time.deltaTime;
            if (_PushingTime >= PushingTime)
            {
                _PushingTime = PushingTime;
            }

            rb.mass = Mathf.Lerp(ObMass, PushAtMass, _PushingTime / PushingTime);
            rb.AddForce(dir * ForceToPush, ForceMode.Force);
        }
        else
        {
            rb.mass = ObMass;
            _PushingTime = 0;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Animator anim;
            anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push"))
            {
                rb.isKinematic = false;
                dir = collision.contacts[0].point - transform.position;
                dir = -dir.normalized;


            }
        }

    }



}
