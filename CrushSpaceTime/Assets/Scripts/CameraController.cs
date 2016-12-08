using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Camera camera;
    private float cameraHeight;
    private float cameraWidth;
    private Boundary boundary;
    [SerializeField] private float speed = 0;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;
        boundary = player.GetComponent<PlayerMove>().getBoundary();
        offset = transform.position - new Vector3(0,0, player.transform.position.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        

        transform.position = new Vector3
        (
            Mathf.Clamp(player.transform.position.x, boundary.xMin + cameraWidth*0.5f, boundary.xMax - cameraWidth * 0.5f),
            Mathf.Clamp(player.transform.position.y, boundary.yMin + cameraHeight*0.5f, boundary.yMax - cameraHeight * 0.5f),
            -5.0f
        );
    }
}
