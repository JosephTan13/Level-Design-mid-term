using System.Collections;
using System.Collections.Generic;
using SupanthaPaul;
using UnityEngine;

public class MovingPlanform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    public int i;

    public CameraFollow CameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;

        CameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f) 
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);

            CameraFollow.ToggleFollowing(false);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

            CameraFollow.ToggleFollowing(true);
        }
    }

}
