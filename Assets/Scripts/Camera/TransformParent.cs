using UnityEngine;
using System.Collections;

public class TransformParent : MonoBehaviour {

    public float rotation_x1 = 50f;
    private float rotation_y1;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.parent.rotation = Quaternion.Euler(rotation_x1, rotation_y1 -= 90, 0);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.parent.rotation = Quaternion.Euler(rotation_x1, rotation_y1 += 90, 0);
        }
    }
}
