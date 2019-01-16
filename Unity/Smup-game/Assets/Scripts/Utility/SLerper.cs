using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLerper : MonoBehaviour
{

    public Transform startPos;
    public Transform endPos;
    public float journeyTime = 1.0f;
    public float speed;
    public bool repeatable;

    float StartTime;
    Vector3 centerPoint;
    Vector3 startRelCenter;
    Vector3 endRelCenter;

    public void GetCenter(Vector3 direction)
    {
        centerPoint = (startPos.position + endPos.position) * 5f;
        centerPoint -= direction;
        startRelCenter = startPos.position - centerPoint;
        endRelCenter = endPos.position - centerPoint;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetCenter(Vector3.up);
        if(!repeatable)
        {
            float fracComplete = (Time.time - StartTime) / journeyTime * speed;
            transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete * speed);
            transform.position += centerPoint;
        }
        else
        {
            float fracComplete = Mathf.PingPong(Time.time - StartTime, journeyTime / speed);
            transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete * speed);
            transform.position += centerPoint;
        }
    }
}
