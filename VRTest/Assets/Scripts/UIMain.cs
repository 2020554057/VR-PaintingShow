using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    List<GameObject> panels = new List<GameObject>();
    List<GameObject> buttons = new List<GameObject>();
    List<string> listString = new List<string>();
    List<AudioClip> audioClips = new List<AudioClip>();
    bool isPrint = false;
    bool isPlay = false;
    float t = 0;
    int index;
    int indexText = 0;
    int num = 0;//是否是第一次打印文本
    AudioSource au;
    GameObject videoPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            panels.Add(transform.Find("Image3" + i).gameObject);
            listString.Add(panels[i].transform.GetChild(0).GetComponent<Text>().text);
            panels[i].SetActive(false);
            audioClips.Add(Resources.Load<AudioClip>("Audio/" + i));
            buttons.Add(transform.Find("buTTon3" + i).gameObject);
        }
        au = GetComponent<AudioSource>();
        videoPanel = transform.Find("VideoPanel").gameObject;
    }
    public void OpenOrClosePanel(bool isOpen)
    {
        videoPanel.SetActive(isOpen);
    }
    public void PlayOrPause(bool isPlay)
    {
        if (isPlay)
            videoPanel.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        else
            videoPanel.GetComponent<UnityEngine.Video.VideoPlayer>().Pause();
    }



    public void ShowPanel(string buttonName)
    {
        if (num != 0)
        {
            panels[index].transform.GetChild(0).GetComponent<Text>().text = "\u3000\u3000" + listString[index];
        }
        indexText = 0;
        index = int.Parse(buttonName.Substring(buttonName.Length - 1));
        panels[index].transform.GetChild(0).GetComponent<Text>().text = "\u3000\u3000";
        panels[index].SetActive(true);
        au.clip = audioClips[index];
        au.Play();
        isPrint = true;
        num++;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPrint)
        {
            t += Time.deltaTime;
            if (t > 0.13f)
            {
                t = 0;
                if (indexText == listString[index].Length)
                {
                    isPrint = false;
                    indexText = 0;
                    return;
                }
                panels[index].transform.GetChild(0).GetComponent<Text>().text += listString[index][indexText];
                indexText++;
            }

        }
    }
}
