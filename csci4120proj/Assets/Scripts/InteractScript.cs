using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "KeyItem")
        {
            KeyItemScript key = collision.collider.GetComponent<KeyItemScript>();
            Inventory.keys[key.index] = true;
            Inventory.power++;
            Destroy(collision.collider.gameObject);
        }

    }
}
