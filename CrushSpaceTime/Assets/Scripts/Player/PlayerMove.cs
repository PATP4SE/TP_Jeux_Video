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

    private Rigidbody2D rbody;
    private AudioSource launchAudio;


    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        launchAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            transform.rotation = new Quaternion(0, 0, 0, 0);
            
            if (areAllMovementKeysReleasedExceptKey(KeyCode.W) && !launchAudio.isPlaying) launchAudio.Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 vect = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, 90);

            if (areAllMovementKeysReleasedExceptKey(KeyCode.A) && !launchAudio.isPlaying) launchAudio.Play();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 vect = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, 180);

            if (areAllMovementKeysReleasedExceptKey(KeyCode.S) && !launchAudio.isPlaying) launchAudio.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 vect = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.LookAt(vect);
            rbody.AddForce(transform.forward * speed, ForceMode2D.Impulse);

            rotate(0, 0, -90);

            if (areAllMovementKeysReleasedExceptKey(KeyCode.D) && !launchAudio.isPlaying) launchAudio.Play();
        }

        rbody.position = new Vector3
        (
            Mathf.Clamp(rbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rbody.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );


        if (areAllMovementKeyReleased()) launchAudio.Stop();
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

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            areAllMovementKeyReleased = true;

        return areAllMovementKeyReleased;
    }

    private bool areAllMovementKeysReleasedExceptKey(KeyCode key)
    {
        bool areAllOtherKeysReleased = false;

        if(key == KeyCode.W) 
            if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
                areAllOtherKeysReleased = true;

        if(key == KeyCode.A)
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            areAllOtherKeysReleased = true;

        if (key == KeyCode.S)
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
                areAllOtherKeysReleased = true;

        if (key == KeyCode.D)
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                areAllOtherKeysReleased = true;

        return areAllOtherKeysReleased;
    }

    public Boundary getBoundary()
    {
        return boundary;
    }
}
