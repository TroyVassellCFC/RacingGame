using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    public SphereCollider Collider;
    public AudioSource audioSource;
    public bool isCollected;
    public float wobbleSpeed = 1f;
    public float wobbleHeight = 0.25f;
    private Vector3 startPosition;
    public float spinSpeed = 90f;
    private float collectedTime;
    private Transform collector;
    public float removeAfter = 1f;
    void Collect( CarController car )
    {
        if (isCollected) return;
        collector = car.transform;
        collectedTime = Time.time;
        isCollected = true;
        audioSource.Play();
        var gameLogic = FindObjectOfType<GameLogic>();
        gameLogic.score += 1;
        Debug.Log("Collected!");
    } 
    void OnTriggerEnter( Collider collider )
    {
        // Don't collect the same item twice!
        if ( isCollected ) return;
        // The car has a Rigidbody, so if it's not there we can exit
        if ( collider.attachedRigidbody == null ) return;

        // Try to get the car, and exit if it doesn't exit
        var car = collider.attachedRigidbody.GetComponent<CarController>();
        if ( car == null ) return;

        Collect( car );
    }
    // Use this for initialization
    void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.AngleAxis( Time.time * spinSpeed, Vector3.up );
        if (!isCollected)
        {
            var wobble = Mathf.Sin( Time.time * Mathf.PI * wobbleSpeed ) * wobbleHeight;
            transform.position = startPosition + Vector3.up * wobble;
        }
        else
        {
            if (collectedTime + removeAfter < Time.time) Destroy(gameObject);
            transform.position += ( collector.position - transform.position ) * 0.125f;
        }
    }
}
