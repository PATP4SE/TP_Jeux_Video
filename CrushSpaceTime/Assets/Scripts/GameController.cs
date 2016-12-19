using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    //Constants
    private const float MIN_SPAWN_CREATION_WAIT = 0.05f;
    private const float MAX_SPAWN_WAIT = 3f;
    private const float MIN_SPAWN_WAIT = 0f;
    private const float LEVEL_TEXT_TIME = 2.5f;

    [SerializeField] private GameObject hazard;
    [SerializeField] private Vector3 spawnValues;
    [SerializeField] private float spawnWidth;
    [SerializeField] private int hazardCount;
    [SerializeField] private float spawnWait;
    [SerializeField] private float startWait;
    [SerializeField] private float waveWait;
    [SerializeField] private float timeAlteration;
    [SerializeField] private string startTitle;
    [SerializeField] private string endTitle;
    private GameObject levelText;
    private float oldTimeAlteration;
    private AudioSource musicBackground;
    private GameObject player;
    private GameObject spaceship;
    private GameObject wormhole;

    void Start () {
        StartCoroutine(makeLevelTextAppearDisappear());

        spawnWait = MIN_SPAWN_WAIT;
        timeAlteration = GameObject.Find("TimeManipulationSlider").GetComponent<Slider>().value;
        waveWait = 0;
        musicBackground = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        spaceship = GameObject.FindGameObjectWithTag("SpaceShip");
        wormhole = GameObject.FindGameObjectWithTag("Wormhole");
        levelText = GameObject.Find("LevelText");

        StartCoroutine(spawnWaves());
    }

    void Update()
    {
        if (wormhole.GetComponent<WormHole>().gethasEnteredWormhole())
        {
            StartCoroutine(finishLevel());
        }

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
        if(!player.GetComponent<Player>().GetIsInSpaceShip())
        {
            spaceship.GetComponent<Animator>().speed = Time.timeScale * Mathf.Abs(timeAlteration);
        } else
        {
            spaceship.GetComponent<Animator>().speed = Time.timeScale;
        }
        
        wormhole.GetComponent<Animator>().speed = Time.timeScale* Mathf.Abs(timeAlteration);

        oldTimeAlteration = timeAlteration;

    }

    IEnumerator spawnWaves()
    {
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                yield return new WaitForSeconds(startWait);
                Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x - spawnWidth, spawnValues.x + spawnWidth), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                if (timeAlteration > MIN_SPAWN_CREATION_WAIT)
                    Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator makeLevelTextAppearDisappear()
    {
        yield return new WaitForSeconds(LEVEL_TEXT_TIME);
        levelText.GetComponent<Text>().text = (startTitle);

        yield return new WaitForSeconds(LEVEL_TEXT_TIME);
        levelText.GetComponent<Text>().text = "";
    }

    public float getTimeAlteration()
    {
        return timeAlteration;
    }

    public IEnumerator finishLevel()
    {
        yield return new WaitForSeconds(LEVEL_TEXT_TIME);
        levelText.GetComponent<Text>().text = (endTitle);
    }
}
