using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
    public float xSpeed = 10f;
	public float ySpeed = 10f;
	public float zSpeed = 10f;
    
    void Update ()
    {
		transform.Rotate(Vector3.right, zSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up, ySpeed * Time.deltaTime);
		transform.Rotate(Vector3.forward, zSpeed * Time.deltaTime);
    }
}