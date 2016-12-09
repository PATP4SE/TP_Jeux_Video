using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

    [SerializeField] private Transform bullets;
    private AudioSource[] audioSources;
    private AudioSource shotAudio;

    // Use this for initialization
    void Start ()
    {
        audioSources = GetComponents<AudioSource>();
        shotAudio = audioSources[1];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(bullets, transform.position, new Quaternion());
        shotAudio.Play();
    }
}
