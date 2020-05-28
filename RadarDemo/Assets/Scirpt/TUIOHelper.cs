/**
 *Copyright(C) 2018 by #COMPANY#
 *All rights reserved.
 *FileName:     #SCRIPTFULLNAME#
 *Author:       #AUTHOR#
 *Version:      #VERSION#
 *UnityVersion��#UNITYVERSION#
 *Date:         #DATE#
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using TouchScript;
using UnityEngine;

public class TUIOHelper : MonoBehaviour
{   /// <summary>
    /// 软件扫描的频率
    /// </summary>
    public float Rate = 30;
    private float time;
    /// <summary>
    /// 用来发射射线的摄像机
    /// </summary>    
    public Camera EventCamera;
    void Awake()
    {
        time = 1 / Rate;
        StartCoroutine(Spawner());
        Screen.SetResolution(2048, 768, true);
        Screen.fullScreen = true;  //设置成全屏,

    }
    IEnumerator Spawner()
    {
        while (true)
        {
            ///时间间隔小于Time.deltaTime没有意义
            if (time < Time.deltaTime)
            {
                time = Time.deltaTime;
            }
            Check();
            yield return new WaitForSeconds(time);
        }
    }
    private void Check()
    {
        ///遍历所有按下状态的指针
        IList<TouchScript.Pointers.Pointer> PressedPointers = TouchManager.Instance.PressedPointers;
        foreach (TouchScript.Pointers.Pointer pointer in PressedPointers)
        {
            ///向每个指针发送射线
            ToRay(pointer.Position); 
        }
    }
    /// <summary>
    /// 根据点击屏幕的位置发送射线
    /// </summary>
    /// <param name="position"></param>
    private void ToRay(Vector2 position)
    {
        Ray ray = EventCamera.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            ///不要重复生成
            ///
            ///这里可以做一下比较，看一下点中（踩中）的是什么，看你的逻辑
            if (hit.collider.name == "Image")
            {
               
                Debug.Log("点击到");
            }
           
            if (hit.collider.tag == "AnswerTwo")
            {
                 
            }
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("射线");
        }
        else
        {
            Debug.Log("不射线");

            //Vector3 spawnerPos = EventCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, 50));
            //GameObject go = Instantiate(FlowerPerfab);//这里为了方便演示直接实例化了，建议用池子
            //go.transform.position = spawnerPos;
        }
    }
}
