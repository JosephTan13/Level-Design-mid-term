using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController1 : MonoBehaviour
{
    public GameObject BreakableWall1;
    private bool canInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
       {
            if (BreakableWall1 != null)
            {
                Destroy(BreakableWall1);
            }
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
