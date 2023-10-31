using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using wvr;
using static UnityEditor.PlayerSettings;

public class TeleportPosition : MonoBehaviour
{
    WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_Controller_Right;
    WaveVR_SimplePointer pointer;
    GameObject mark;
    Vector3[] markPos = {
        new Vector3(-0.56f,-2.9f,-0.76f),
        new Vector3(-0.56f,-2.9f,6.57f),
        new Vector3(-0.56f,-2.9f,14.23f),
        new Vector3(-0.56f,-2.9f,21.69f),
        new Vector3(7.6f,-2.9f,21.44f),
        new Vector3(7.6f,-2.9f,14.36f),
        new Vector3(7.6f,-2.9f,6.92f),
        new Vector3(7.6f,-2.9f,-1.05f),
    };
    int currentIndex = 0;
    UIMain uiMain;
    GameObject imageObj;
    GameObject ds;
    Vector3 pos;//雕塑初始化坐标
    Vector3 rot;//雕塑初始角度
    // Start is called before the first frame update
    void Start()
    {
        mark = GameObject.FindGameObjectWithTag("Mark");
        pointer = GetComponent<WaveVR_SimplePointer>();
        InitPos();
        uiMain = FindObjectOfType<UIMain>();
    }
    void InitPos()
    {
        currentIndex = 0;
        Teleport();
    }
    public void Teleport()
    {
        if (currentIndex >= markPos.Length)
        {
            return;
        }
        transform.parent.position = markPos[currentIndex] + Vector3.up * 1.3f;
        if (currentIndex == 0)
        {
            ShowMark(1);
        }
        else if (currentIndex == 1)
        {
            ShowMark(2);
        }
        else if (currentIndex == 2)
        {
            ShowMark(3);
        }
        else if (currentIndex == 3)
        {
            ShowMark(4);
        }
        else if (currentIndex == 4)
        {
            ShowMark(5);
        }
        else if (currentIndex == 5)
        {
            ShowMark(6);
        }
        else if (currentIndex == 6)
        {
            ShowMark(7);
        }
        else if (currentIndex == 7)
        {
            ShowMark(0);
        }
    }
    public void ShowMark(int index)
    {
        if (index >= markPos.Length)
        {
            return;
        }
        mark.transform.position = markPos[index];
        currentIndex = index;
    }
    // Update is called once per frame
    void Update()
    {
        if (!pointer.GetHitTrans())
        {
            if (mark)
            {
                mark.transform.localScale = Vector3.one * 0.5f;
            }
            if (imageObj)
            {
                imageObj.GetComponent<Image>().color = Color.white;
            }
            return;
        }
        GameObject obj = pointer.GetHitTrans().gameObject;
        if (WaveVR_Controller.Input(device).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            if (obj.name == "Plane003")
            {
                transform.parent.position = pointer.GetHitPos() + Vector3.up * 1.3f;
            }
            if (obj.tag == "Mark")
            {
                Teleport();
                // transform.parent.position = obj.transform.position + Vector3.up * 1.3f;
            }
            if (obj.name.Contains("buTTon"))
            {
                uiMain.ShowPanel(obj.name);
            }
            if (obj.name == "CloseButton")
            {
                obj.transform.parent.gameObject.SetActive(false);
            }
            if (obj.name == "OpenVideo")
            {
                uiMain.OpenOrClosePanel(true);
            }
            if (obj.name == "CloseVideo")
            {
                uiMain.OpenOrClosePanel(false);
            }
            if (obj.name == "Play")
            {
                uiMain.PlayOrPause(true);
            }
            if (obj.name == "Pause")
            {
                uiMain.PlayOrPause(false);
            }
            if (obj.name == "VictoriaBust")
            {
                pos = obj.transform.localPosition;
                rot = obj.transform.localEulerAngles;
                ds = obj;
            }

    }

        if (WaveVR_Controller.Input(device).GetPress(WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            if (obj.name == "VictoriaBust")
            {
                obj.transform.parent = transform;

            }
        }
        if (WaveVR_Controller.Input(device).GetPressUp(WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            if (ds)
            {
                obj.transform.parent = FindObjectOfType<PictureRotate>().transform.Find("Showing13").GetChild(2);
                obj.transform.localEulerAngles = rot;
                obj.transform.localPosition = pos;
            }
        }


        if (obj.GetComponent<Image>())
        {
            obj.GetComponent<Image>().color = Color.green;
            imageObj = obj;
        }
        else
        {
            if (imageObj)
            {
                imageObj.GetComponent<Image>().color = Color.white;
            }
        }



        GameObject[] marks = GameObject.FindGameObjectsWithTag("Mark");
        for (int i = 0; i < marks.Length; i++)
        {
            marks[i].transform.GetChild(0).LookAt(transform.parent.position);
        }
        if (obj.tag == "Mark")
        {
            mark = obj;
            mark.transform.localScale = Vector3.one * 0.8f;
        }
        else
        {
            if (mark)
            {
                mark.transform.localScale = Vector3.one * 0.5f;
            }
        }
    }
}
