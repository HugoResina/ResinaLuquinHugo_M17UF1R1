using System.Collections.Generic;
using UnityEngine;

public class SawPathFollower : MonoBehaviour
{

    public List<Transform> points;


    public float speed = 5f;

    private int index = 0;

    void Update()
    {
        if (points == null || points.Count == 0)
            return;


        Transform objetive = points[index];


        transform.position = Vector3.MoveTowards(
            transform.position,
            objetive.position,
            speed * Time.deltaTime
        );


        if (Vector3.Distance(transform.position, objetive.position) < 0.05f)
        {
            index++;


            if (index >= points.Count)
                index = 0;
        }
    }
    public void Restart()
    {
        transform.position = points[0].position;
        index = 0;
    }
}
