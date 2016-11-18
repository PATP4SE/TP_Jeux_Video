using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    //Constants
    private const float MIN_SPAWN_CREATION_WAIT = 0.05f;
    private const float MAX_SPAWN_WAIT = 3f;
    private const float MIN_SPAWN_WAIT = 0f;

    [SerializeField] private GameObject hazard;
    [SerializeField] private Vector3 spawnValues;
    [SerializeField] private int hazardCount;
    [SerializeField] private float spawnWait;
    [SerializeField] private float startWait;
    [SerializeField] private float waveWait;
    [SerializeField] private float timeAlteration;
    private float oldTimeAlteration;
    private AudioSource musicBackground;

    void Start () {
        spawnWait = MIN_SPAWN_WAIT;
        timeAlteration = GameObject.Find("TimeManipulationSlider").GetComponent<Slider>().value;
        waveWait = 0;
        //GetComponent<Mover>().setTimeAlteration(timeAlteration);
        musicBackground = GetComponent<AudioSource>();
        StartCoroutine(spawnWaves());
    }

    void Update()
    {
        timeAlteration = GameObject.Find("TimeManipulationSlider").GetComponent<Slider>().value;
        GameObject.Find("TimeAlterationText").GetComponent<Text>().text = timeAlteration.ToString("F2");
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid.GetComponent<Mover>().getTimeAlteration() != timeAlteration)
            {
                asteroid.GetComponent<Mover>().setTimeAlteration(timeAlteration);
            }
        }

        if(oldTimeAlteration != timeAlteration && timeAlteration < 1)
            spawnWait = Mathf.Clamp(MAX_SPAWN_WAIT - timeAlteration*2, MIN_SPAWN_WAIT, MAX_SPAWN_WAIT);
        else if (oldTimeAlteration != timeAlteration && timeAlteration >= 1)
            spawnWait = 0;

        musicBackground.pitch = Time.timeScale * timeAlteration;
        oldTimeAlteration = timeAlteration;

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
                if (timeAlteration > MIN_SPAWN_CREATION_WAIT)
                    Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public float getTimeAlteration()
    {
        return timeAlteration;
    }
}
