using UnityEngine;
using System.Collections;

public class Repulse : MonoBehaviour {

    [SerializeField] private float radius = 0f;
    [SerializeField] private float repulseStrenght = 0f;
    [SerializeField] private ParticleSystem particle;
    private GameController gameControllerScript;
    private KeyCode repulseKey;

    // Use this for initialization
    void Start ()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        repulseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RepulsePref"));
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(repulseKey))
        {
            particle.Play();
            Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

            foreach (GameObject obj in objects)
            {
                if ((Vector2.Distance(transform.position, obj.transform.position) <= radius) && obj.tag == "Asteroid")
                {                    
                    pushObject(obj);
                    obj.GetComponent<Mover>().setRepulsed(true);
                }
            }
        } else if(!Input.GetKey(repulseKey) && !gameControllerScript.GetIsInSpaceShip())
        {
            particle.Stop();
        }

    }


    private void pushObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        Quaternion temp = obj.transform.rotation;

        obj.transform.LookAt(transform.position);
        obj.transform.rotation = new Quaternion(-obj.transform.rotation.x, -obj.transform.rotation.y, obj.transform.rotation.z, obj.transform.rotation.w);
        obj.GetComponent<Rigidbody2D>().AddForce(obj.transform.forward * repulseStrenght, ForceMode2D.Impulse);

        obj.transform.rotation = temp;
    }

}
