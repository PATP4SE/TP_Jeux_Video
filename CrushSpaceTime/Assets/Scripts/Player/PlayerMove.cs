using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerMove : MonoBehaviour {

    [SerializeField] private Boundary boundary;
    [SerializeField] private float speed = 0;
    [SerializeField] private ParticleSystem particlesLeft;
    [SerializeField] private ParticleSystem particlesTop;
    [SerializeField] private ParticleSystem particlesRight;
    [SerializeField] private ParticleSystem particlesBottom;

    private Rigidbody2D rbody;
    private AudioSource launchAudio;
    private GameController gameControllerScript;
    private KeyCode upKey;
    private KeyCode leftKey;
    private KeyCode downKey;
    private KeyCode rightKey;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        launchAudio = GetComponent<AudioSource>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        upKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpPref"));
        leftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftPref"));
        downKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DownPref"));
        rightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightPref"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            if (!gameControllerScript.GetIsInSpaceShip())
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                particlesTop.Play();
            }else rotate(0, 0, 0);

            if (areAllMovementKeysReleasedExceptKey(upKey) && !launchAudio.isPlaying) launchAudio.Play();
        }
        else if (Input.GetKey(leftKey))
        {
            Vector3 vect = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            if(!gameControllerScript.GetIsInSpaceShip())
            {
                rotate(0, 0, 0);
                transform.Rotate(new Vector3(0, 0, 0));
                particlesLeft.Play();
            } else rotate(0, 0, 90);


            if (areAllMovementKeysReleasedExceptKey(leftKey) && !launchAudio.isPlaying) launchAudio.Play();
        }
        else if (Input.GetKey(downKey))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            if (!gameControllerScript.GetIsInSpaceShip())
            {
                rotate(0, 0, 0);
                particlesBottom.Play();
            } else rotate(0, 0, 180);

            if (areAllMovementKeysReleasedExceptKey(downKey) && !launchAudio.isPlaying) launchAudio.Play();
        }
        else if (Input.GetKey(rightKey))
        {
            Vector3 vect = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            if (!gameControllerScript.GetIsInSpaceShip())
            {
                rotate(0, 0, 0);
                particlesRight.Play();
            } else rotate(0, 0, -90);

            if (areAllMovementKeysReleasedExceptKey(rightKey) && !launchAudio.isPlaying) launchAudio.Play();
        }

        rbody.position = new Vector3
        (
            Mathf.Clamp(rbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rbody.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        if (areAllMovementKeyReleased()) launchAudio.Stop();
        if (!gameControllerScript.GetIsInSpaceShip()) stopParticlesEmission();
    }

    /************************************ PRIVATE METHODS ************************************/
    private void rotate(float x, float y, float z)
    {
        Quaternion quat = transform.rotation;
        quat.eulerAngles = new Vector3(x, y, z);
        transform.rotation = quat;
    }

    private bool areAllMovementKeyReleased()
    {
        bool areAllMovementKeyReleased = false;

        if (!Input.GetKey(upKey) && !Input.GetKey(leftKey) && !Input.GetKey(downKey) && !Input.GetKey(rightKey))
            areAllMovementKeyReleased = true;

        return areAllMovementKeyReleased;
    }

    private bool areAllMovementKeysReleasedExceptKey(KeyCode key)
    {
        bool areAllOtherKeysReleased = false;

        if(key == upKey) 
            if(!Input.GetKey(leftKey) && !Input.GetKey(downKey) && !Input.GetKey(rightKey))
                areAllOtherKeysReleased = true;

        if(key == leftKey)
            if (!Input.GetKey(upKey) && !Input.GetKey(downKey) && !Input.GetKey(rightKey))
            areAllOtherKeysReleased = true;

        if (key == downKey)
            if (!Input.GetKey(leftKey) && !Input.GetKey(upKey) && !Input.GetKey(rightKey))
                areAllOtherKeysReleased = true;

        if (key == rightKey)
            if (!Input.GetKey(leftKey) && !Input.GetKey(downKey) && !Input.GetKey(upKey))
                areAllOtherKeysReleased = true;

        return areAllOtherKeysReleased;
    }

    private void stopParticlesEmission()
    {
        if (Input.GetKeyUp(upKey)) particlesTop.Stop();
        if (Input.GetKeyUp(leftKey)) particlesLeft.Stop();
        if (Input.GetKeyUp(downKey)) particlesBottom.Stop();
        if (Input.GetKeyUp(rightKey)) particlesRight.Stop();
    }

    public Boundary getBoundary()
    {
        return boundary;
    }
}
