using UnityEngine;
using System.Collections;

public class RotatePage : MonoBehaviour {

	public bool left = false;
	public int speed = 100;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 angle = transform.rotation.eulerAngles;
        if (angle.y < 179f && left)
		{
			transform.Rotate(new Vector3(0, 1, 0), speed * Time.deltaTime);
		}
        if (angle.y > 2 && !left)
		{
			transform.Rotate(new Vector3(0, 1, 0), -speed * Time.deltaTime);
		}   
	}
}
