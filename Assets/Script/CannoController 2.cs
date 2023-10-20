using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoController2 : MonoBehaviour
{
    public GameObject BreakableWall2;
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
            if (BreakableWall2 != null)
            {
                Destroy(BreakableWall2);
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
