using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnTime = 0.1f;
    float turnVelocity;
    // DialogueManager manager = gameObject.AddComponent<DialogueManager>();
    // static string[] items = { "Item1", "Item2", "Item3", "Item4" };
    // Dialogue dialogue = new Dialogue(items,"xd");
    // Update is called once per frame
    void Update()   
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        if (Input.GetButtonDown ("Interact")){
            // dialogue.name = "yoyo";
            // string[] items = { "Item1", "Item2", "Item3", "Item4" };
            // dialogue.sentences = items;
            print("interracted");
            // manager.StartDialogue(dialogue);
        }
        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }
}
