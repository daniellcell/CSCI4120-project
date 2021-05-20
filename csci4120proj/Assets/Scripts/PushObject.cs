using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PushObject : MonoBehaviour
{
    public AudioClip soundClip;
    AudioSource AudioPlayer;
    public float ObMass = 300;
    public float PushAtMass = 100;
    public float PushingTime;
    public float ForceToPush;
    Rigidbody rb;
    public float vel;
    Vector3 dir;
    bool colliding = false;
    Vector3 lastPos;
    float _PushingTime = 0;
    public int massLevel = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) return;

        AudioPlayer = GetComponent<AudioSource>();
        if (soundClip != null)
        {
            AudioPlayer.clip = soundClip;
            AudioPlayer.Stop();
        }
        AudioPlayer.volume = 0;

        AudioPlayer.pitch = 0.5f;

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
        if (!colliding)
        {
            rb.isKinematic = true;
            if (soundClip != null)
            {
                AudioPlayer.Stop();
            }


            AudioPlayer.volume = 0f;
            AudioPlayer.pitch = 0.2f;

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

        if (IsMoving() == true && rb.isKinematic == false)
        {
            if (AudioPlayer.isPlaying == false)
            {
                AudioPlayer.Play();
            }

            StartCoroutine(SoundChangeHigh());
        }
        else
        {

            StartCoroutine(SoundChangeLow());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            colliding = true;
            GameObject player = collision.gameObject;
            Animator anim;
            anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push"))
            {
                if (Inventory.power >= massLevel)
                {
                    rb.isKinematic = false;
                    dir = collision.contacts[0].point - transform.position;
                    dir = -dir.normalized;
                }
                else
                {
                    // Not enough strength
                }
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            colliding = false;
        }

    }

    IEnumerator SoundChangeHigh()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Animator anim;
        anim = player.GetComponent<Animator>();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push"))
        {
            AudioPlayer.volume = Mathf.Lerp(0, 0.5f, PushAtMass / rb.mass);
            AudioPlayer.pitch = Mathf.Lerp(0.2f, 1f, PushAtMass / rb.mass);
        }
        yield return new WaitForSeconds(0.1f);

    }
    IEnumerator SoundChangeLow()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Animator anim;
        anim = player.GetComponent<Animator>();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push"))
        {
            AudioPlayer.volume = 1 - Mathf.Lerp(0F, 0.5f, Time.deltaTime);
            AudioPlayer.pitch = 1 - Mathf.Lerp(0.2f, 1f, Time.deltaTime);
        }

        yield return new WaitForSeconds(0.1f);
    }


}
