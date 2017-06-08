using UnityEngine;
using System.Collections;

public class TransformObjectRotation : MonoBehaviour {


    private float rotation_x;
    private float rotation_y;

	// Use this for initialization
	void Start () {
        rotation_y = transform.rotation.y;
        rotation_x = transform.rotation.x;
}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(rotation_x = 50, rotation_y -= 90, 0);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.rotation = Quaternion.Euler(rotation_x = 50, rotation_y += 90, 0);
        }
    }
}
