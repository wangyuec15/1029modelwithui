using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class forFurnitureCollect : MonoBehaviour
{

    public int n;
    public GameObject curFurniture;


    //材质
    public Material outline;
    public Material normal;
    public Material red;


    private Vector3 lins;
    private bool push = false;

    private Vector3 targetScreenPoint;

    private Vector3 offset;
    private Vector3 pos;
     
    public GameObject deleteButton;


    void Start()
    {
        deleteButton = GameObject.Find("Canvas").transform.Find("delete").gameObject;

    }





    void OnCollisionEnter(Collision collision)
    {

        curFurniture.GetComponent<Renderer>().material = red;

        //记一下刚接触的位置
        lins = curFurniture.transform.position;
        push = true;

        if (push)
        {
            //记录刚碰撞的位置
            curFurniture.transform.position = lins;
        }
    }

    //有相交的时候把正在移动的物体推出来变成相邻的
    void OnCollisionStay(Collision collision)
    {

        if (push)
        {
            curFurniture.transform.position = lins;
        }
    }

    //不相交了换成普通描边
    void OnCollisionExit(Collision collision)
    {
        
        curFurniture.GetComponent<Renderer>().material = outline;

        push = false;
    }

    void Update()
    {

        ////////单选作用
        if (Input.GetMouseButtonDown(0))
        {
            if (curFurniture != null)
            {
                targetScreenPoint = Camera.main.WorldToScreenPoint(curFurniture.transform.position);
                deleteButton.SetActive(true);

            }
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

            if (pos.x > 100)
            {
                curFurniture = null;
            }

            if (curFurniture != null)
            {
                deleteButton.SetActive(true);

                curFurniture.GetComponent<Renderer>().material = outline;
                targetScreenPoint = Camera.main.WorldToScreenPoint(curFurniture.transform.position);

                offset = curFurniture.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
            }
        }


    }
    private void OnDestroy()
    {
        offset = Vector3.zero;
        pos = Vector3.zero;
    }

}
