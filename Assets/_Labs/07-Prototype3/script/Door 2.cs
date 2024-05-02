using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public float interactionDistance;

    //The text that appears to let you know you can interact with the door
    public GameObject intText;

    public Animator doorAnimator; // Animator controlling door animations
    private bool doorOpen = false;
    public AudioClip openSoundClip; // Sound to play when the door opens
    public AudioClip closeSoundClip;
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the GameObject and get the reference
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    //The Update() void is where stuff occurs every frame
    void Update()
    {
        //A ray is created which will shoot forward from the player's camera
        Ray ray = new Ray(transform.position, transform.forward);

        //RaycastHit variable, which is used to get info back from whatever the raycast hits
        RaycastHit hit;

        //If the raycast hits something
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            //If the object the raycast hits is tagged as door
            if (hit.collider.gameObject.tag == "door")
            {

                //The interaction text is set active
                intText.SetActive(true);

                //If the E key is pressed
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorOpen)
                    {
                        // Close the door
                        doorAnimator.SetTrigger("close");
                        doorOpen = false;
                        if (closeSoundClip != null)
                            audioSource.PlayOneShot(closeSoundClip);
                    }
                    else
                    {
                        // Open the door
                        doorAnimator.SetTrigger("open");
                        doorOpen = true;
                        if (openSoundClip != null)
                            audioSource.PlayOneShot(openSoundClip);
                    }
                }
            }
            else
            {
                // Hide interaction prompt if player is not close enough
                intText.SetActive(false);
            }
        }
    }
}
