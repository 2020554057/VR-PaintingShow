using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public struct RayClickedArgs//射线碰撞到的物体信息
{
    public WVR_DeviceType device;
    public float padx, pady;
    public Vector3 hitpos;
    public Transform target;
}
public struct RayPointerArgs//射线信息
{
    public WVR_DeviceType device;
    public int flag;
    public float distance;
    public Transform target;
}
public class WaveVR_RayEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
