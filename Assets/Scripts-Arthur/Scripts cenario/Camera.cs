using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform pt; // Player Transform
    public Transform ct; // Camera Transform


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ct.position = Vector3.Lerp(
            ct.position,
            new Vector3(pt.position.x, pt.position.y, ct.position.z), 0.9f);

	
	}
}
