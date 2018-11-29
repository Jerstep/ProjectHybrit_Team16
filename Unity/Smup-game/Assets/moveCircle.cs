using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCircle : MonoBehaviour {


    [SerializeField] float angle = 0;
    [SerializeField] private int radius = 10;
    [SerializeField] private int speed = 10;

    private Transform parent;
    private float localX;
    private float localY;

    // Use this for initialization
    void Start()
    {
        //parent = GetComponentInParent<Transform>();

        //for(int i = 0; i < numObjects; ++i)
        //{
        //    float theta = (2 * pi / numObjects) * i;
        //    x = cos(theta);
        //    z = sin(theta);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //localX = parent.position.x;
        //localY = parent.position.y;

        //float x = 0;
        //float y = 0;

        //Vector2 direction = Vector2.zero;

        //x = radius * Mathf.Cos(angle);
        //y = radius * Mathf.Sin(angle);

        //transform.position = new Vector2(x + localX, y + localY) ;

        //angle += speed * Mathf.Deg2Rad * Time.deltaTime;
    }


}
