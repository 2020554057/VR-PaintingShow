using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    //  public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        //第一种生成
        //GameObject obj= Instantiate(cube);
        // obj.transform.position = Vector3.zero;
        //第二种生成
        //Object obj=  Resources.Load("Cube");//加载对应路径物体信息，类似于外部拖拽效果
        //                                    //  GameObject cube= (GameObject)Instantiate(obj);
        //GameObject cube = Instantiate(obj) as GameObject;
        //cube.transform.position = Vector3.zero;
        //  Instantiate(Resources.Load<GameObject>("Cube")).transform.position=Vector3.zero;

        //第三种生成
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = Vector3.zero;
        //第四种生成
        GameObject obj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
