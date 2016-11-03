using UnityEngine;
using System.Collections;

public class Repulse : MonoBehaviour {

    [SerializeField] private float radius;
    [SerializeField] private float repulseStrenght;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

            foreach (GameObject obj in objects)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if ((Vector2.Distance(mousePosition, obj.transform.position) <= radius) && obj.tag != "Player" && obj.tag != "MainCamera")
                {
                    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    
                    Vector2 vect = new Vector2(mousePosition.x, mousePosition.y);

                    Quaternion temp = obj.transform.rotation;

                    obj.transform.LookAt(vect);
                    obj.transform.rotation = new Quaternion(-obj.transform.rotation.x, -obj.transform.rotation.y, obj.transform.rotation.z, obj.transform.rotation.w);
                    obj.GetComponent<Rigidbody2D>().AddForce(obj.transform.forward * repulseStrenght, ForceMode2D.Impulse);
                    
                    obj.transform.rotation = temp;
                }
            }
        }
    }


    private void PushObject(GameObject obj)
    {
        
    }

}
