using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public GameObject wood;
	public GameObject wood_text;

	// Use this for initialization
	void Start ()
	{
		wood = GameObject.Find ("Wood");
		wood.SetActive (false);
	}

	void OnMouseDown()
	{
		wood.SetActive (true);
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 15.0f);
		print ("You broke the bridge and got 3 woods !");
	}
	// Update is called once per frame
	void Update ()
	{

	}
}
