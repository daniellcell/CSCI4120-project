using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    AudioSource AudioPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        //newAudio.clip = clip; 
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "KeyItem")
        {
            KeyItemScript key = collision.collider.GetComponent<KeyItemScript>();
            Inventory.keys[key.index] = true;
            Inventory.power++;
            Destroy(collision.collider.gameObject);
            AudioPlayer = GameObject.FindGameObjectWithTag("Pick").GetComponent<AudioSource>();
            GetComponent<AudioSource>().clip = AudioPlayer.clip;
            AudioPlayer.Play();
        }


    }
}
