using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public MovingPlatform2 movingPlatform;

    private bool isActivated = false;

    private bool canInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKey(KeyCode.E))
        {
            if (isActivated)
            {
                movingPlatform.StopMoving();
                Debug.Log("You used the lever to start the platform.");
            }
            else
            {
                movingPlatform.StartMoving();
                Debug.Log("You used the lever to stop the platform.");
            }

            isActivated = !isActivated;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }


}
