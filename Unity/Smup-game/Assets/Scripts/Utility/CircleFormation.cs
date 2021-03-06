﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFormation : MonoBehaviour {

    public Transform markerPrefab;
    [Range(1, 100)]
    public int pointCount;
    public float radius;

    public List<Transform> markers;

    public void Start()
    {
        markers = new List<Transform>();
        InitMarkers();
        MakeFOrmation();
    }

    public void MakeFOrmation()
    {
        if(pointCount != markers.Count)
        {
            InitMarkers();
        }

        ////// the core bit ///////
        Quaternion quaternion = Quaternion.AngleAxis(360f / (float)(pointCount), transform.up);
        Vector3 vec3 = transform.forward * radius;
        for(int index = 0; index < pointCount; ++index)
        {
            markers[index].position = transform.position + vec3;
            // update for the next one
            vec3 = quaternion * vec3;
        }
        ////// end of the core bit ///////
    }

    private void InitMarkers()
    {
        if(pointCount > markers.Count)
        {
            for(int i = markers.Count; i < pointCount; i++)
            {
                // doesn't matter, we're updating the positions later
                markers.Add(Instantiate(markerPrefab, Vector3.zero, transform.rotation) as Transform);
                markers[i].transform.parent = gameObject.transform;
            }
        }
    }
}

