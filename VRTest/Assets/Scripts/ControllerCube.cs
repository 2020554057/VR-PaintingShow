using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangeColor()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public void ChangeBig()
    {
        transform.localScale += Vector3.one;
    }
    public void ChangeSmall()
    {

        transform.localScale -= Vector3.one;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
