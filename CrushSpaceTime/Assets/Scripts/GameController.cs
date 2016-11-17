using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject hazard;
    [SerializeField] private Vector3 spawnValues;
    [SerializeField] private int hazardCount;
    [SerializeField] private float spawnWait;
    [SerializeField] private float startWait;
    [SerializeField] private float waveWait;
    [SerializeField] private float timeSpeed;
    private AudioSource musicBackground;

    void Start () {
        musicBackground = GetComponent<AudioSource>();
        StartCoroutine(spawnWaves());
    }

    void Update()
    {
        
        if (timeSpeed != 1f)
        {
            musicBackground.pitch = Time.timeScale * timeSpeed;
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach(GameObject asteroid in asteroids)
            {
                //if (asteroid.GetComponent<Mover>().getSpeedAlteration() != timeSpeed)
                //{
                //    asteroid.GetComponent<Mover>().setSpeedAlteration(timeSpeed);

                //}

                //Rigidbody2D rbody = asteroid.GetComponent<Rigidbody2D>();
                //Vector2 oldVelocity = rbody.velocity;
                //Debug.Log("oldVelocity" + oldVelocity.y);
                //rbody.velocity = new Vector2(0, oldVelocity.y*timeSpeed);
                //Debug.Log("newVelocity" + rbody.velocity.y);
            }
        }
    }

    IEnumerator spawnWaves()
    {
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                yield return new WaitForSeconds(startWait);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
