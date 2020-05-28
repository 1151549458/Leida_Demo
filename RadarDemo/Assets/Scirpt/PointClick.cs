using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerEnterHandler
{
    //这个是鼠标，作用于UI上，如果要挂在模型上的话，模型需要添加碰撞器
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down" + " 坐标 "+eventData.pointerPressRaycast.worldPosition);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter" + " 坐标 " + eventData.pointerPressRaycast.worldPosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("点击抬起");

    }
 
}
