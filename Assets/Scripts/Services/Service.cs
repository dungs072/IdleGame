using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Service : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ToggleService(true);
    }
    private void OnTriggerExit(Collider other)
    {
        ToggleService(false);
    }
    public virtual void ToggleService(bool state)
    {
        if (state)
        {
            // toggle service
        }
        else
        {

        }
    }

}
