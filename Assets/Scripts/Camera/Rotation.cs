using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public int xRotation = 50;

    private float yRotation;

    // Use this for initialization
    void Start () {
        
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            yRotation += Input.GetAxis("Horizontal");
            transform.eulerAngles = new Vector3(xRotation, yRotation -= 90, 0); transform.position = new Vector3(5, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            yRotation -= Input.GetAxis("Horizontal");
            transform.eulerAngles = new Vector3(xRotation, yRotation += 90, 0); transform.position = new Vector3(5, 0, 0);
        }
    }
}
