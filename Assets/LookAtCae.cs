using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCae  : MonoBehaviour
{
	public Transform target;
    public float heightOffset = 3f;
    // Update is called once per frame
    void Update () {
		var difference = target.position - transform.position + target.up * heightOffset;
        transform.rotation = Quaternion.LookRotation( difference );
    }
}