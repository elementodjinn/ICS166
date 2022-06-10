using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject checkedObject;
    public GameObject objectToDeactivate;

    // Update is called once per frame
    void Update()
    {
        if (!checkedObject.activeSelf)
        {
            objectToDeactivate.SetActive(false);
        }
    }
}
