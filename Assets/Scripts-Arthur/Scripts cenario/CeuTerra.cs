using UnityEngine;
using System.Collections;

public class CeuTerra : MonoBehaviour {
    //script reclicado do CameraFollow
    private Transform pt; // Player Transform
    private Transform ct; // Ceu ou Terra transform


	// Use this for initialization
	void Start () {
        pt = GameObject.FindGameObjectWithTag("Player").transform;
        ct = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        ct.position = Vector3.Lerp(ct.position,new Vector3(pt.position.x, ct.position.y, ct.position.z), 0.9f);

	
	}
}
