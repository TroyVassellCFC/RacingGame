using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehindCar : MonoBehaviour
{
    public Transform target;
    public float height = 5f;
    public float distance = 15f;
    [Range(1f, 100f)]
    public float smoothness = 50f;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var goalPosition = target.position - target.forward * distance + target.up * height;
        transform.position += (goalPosition - transform.position) / smoothness;
    }
}
