using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;//获取设备信息。按键信息
using UnityEngine.UI;

public class RayController : MonoBehaviour
{
    WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_Controller_Right;
    WaveVR_SimplePointer pointer;
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<WaveVR_SimplePointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pointer.GetHitTrans())
        {
            if (button)
            {
                button.GetComponent<Image>().color = Color.white;
            }
            return;
        }
        GameObject obj = pointer.GetHitTrans().gameObject;
        if (WaveVR_Controller.Input(device).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            if (obj.name == "Cube")
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            if (obj.name == "Button")
            {
                GameObject.Find("Cube").GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
        if (WaveVR_Controller.Input(device).GetPress(WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            if (obj.name == "Cube")
            {
                if (obj.GetComponent<Rigidbody>())
                {
                    Destroy(obj.GetComponent<Rigidbody>());
                }
                obj.transform.parent = transform;//把Cube绑定手柄上
            }

        }
        if (WaveVR_Controller.Input(device).GetPressUp(WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            if (obj.name == "Cube")
            {
                obj.transform.parent = null;
                obj.AddComponent<Rigidbody>();
            }
        }
        if (obj.name.Contains("Button"))
        {
            button = obj;
            button.GetComponent<Image>().color = Color.red;
        }
        else
        {
            if (button)
            {
                button.GetComponent<Image>().color = Color.white;
            }
        }

    }
}
