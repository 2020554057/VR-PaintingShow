using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureRotate : MonoBehaviour
{

    void Update()
    {
        for (int i = 0; i < 12; i++)
        {
            transform.GetChild(i).GetChild(0).GetChild(0).Rotate(0, 0, 3);
        }
    }
}
