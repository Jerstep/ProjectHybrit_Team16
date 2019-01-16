using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingCollider : MonoBehaviour {

    private Collider col;
    public int scaleMod;
    public Vector3 maxSize;

    private Vector3 scale = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
        col = GetComponent<SphereCollider>();
        col.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
        col.transform.localScale = scale;
        if(col.transform.localScale.x < maxSize.x)
        {
            scale.x += Time.deltaTime * scaleMod;
            scale.y += Time.deltaTime * scaleMod;
            scale.z += Time.deltaTime * scaleMod;
        }

        if(col.transform.localScale.x >= maxSize.x)
        {
            Destroy(gameObject);
        }
	}
}
