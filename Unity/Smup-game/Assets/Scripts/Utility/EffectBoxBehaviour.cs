using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBoxBehaviour : MonoBehaviour {

    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Quaternion originalRot;
    [SerializeField] private Vector3 currPos;
    [SerializeField] private Quaternion currRot;

    private bool canMove = false;
    public float waitTime;

    public float speed = 1.0F;
    public float journeyTime = 1.0F;

    private float startTime;
    private float journeyLength;

    public float timer;
    public bool startTimer = false;

    private void Start()
    {
        originalPos = this.transform.position;
        originalRot = this.transform.rotation;
    }

    private void FixedUpdate()
    {
        currPos = this.transform.position;
        currRot = this.transform.rotation;

        //if(startTimer)
        //{
        //    timer += Time.deltaTime;
        //    if(timer >= waitTime)
        //    {
        //        canMove = false;
        //        this.transform.position = originalPos;
        //        this.transform.rotation = originalRot;

        //        timer = 0;
        //        startTimer = false;
        //    }
        //}

        if(canMove)
        {
            float distCovered = (Time.time - startTime) / journeyTime * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(currPos, originalPos, fracJourney);
            transform.rotation = Quaternion.Lerp(currRot, originalRot, fracJourney);            

            if (currPos == originalPos)
            {
                canMove = false;
            }
        }
    }

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Explosion"))
        //{
            canMove = false;
            StartCoroutine(ReturnToOrigin());
        //}

        if(currPos != originalPos)
        {
            canMove = false;
            StartCoroutine(ReturnToOrigin());
        }
    }

    IEnumerator ReturnToOrigin()
    {
        yield return new WaitForSeconds(waitTime);
        startTime = Time.time;
        currPos = this.transform.position;
        currRot = this.transform.rotation;
        journeyLength = Vector3.Distance(currPos, originalPos);
        canMove = true;
        startTimer = true;
    }

}
