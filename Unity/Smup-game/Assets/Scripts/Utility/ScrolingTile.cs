using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolingTile : MonoBehaviour {
    public int scrollSpeed;

    private float startPos;
    private float pos;
    private float endPos;

    // Use this for initialization
    void Start () {
        endPos = 99.7f;
        startPos = -99.7f;
        pos = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(this.transform.position.x, pos += Time.deltaTime * scrollSpeed, this.transform.position.z);

        if (pos > endPos)
        {
            pos = startPos;
        }
	}
}
