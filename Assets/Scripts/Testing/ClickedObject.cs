using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedObject : MonoBehaviour
{
    public Camera cameraa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = cameraa.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            print("NOT IT WORKED!");
            if (Physics.Raycast(ray, out hit))
            {
                print("IT WORKED!");
                // the object identified by hit.transform was clicked
                // do whatever you want
            }
        }
    }
}
