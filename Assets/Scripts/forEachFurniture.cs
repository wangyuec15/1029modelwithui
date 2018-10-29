using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class forEachFurniture : MonoBehaviour {
    //材质
    public Material outline;
    public Material normal;
    public Material red;


    private Vector3 lins;
    private bool push = false;

    private Vector3 targetScreenPoint;

    private Vector3 offset;
    private Vector3 pos;

    public bool choosing = false;

    private GameObject collect;

    private GameObject deleteButton;

    void Start()
    {
        deleteButton = GameObject.Find("Canvas").transform.Find("delete").gameObject;
       // deleteButton.SetActive(false);
    }





    void OnMouseDown()
    {

        deleteButton.SetActive(true);


        choosing = true;



        if (gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture != null)
        {
            gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture.GetComponent<Renderer>().sharedMaterial.SetColor("_OutlineColor", Color.blue);

            gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture.GetComponent<Renderer>().material = normal;

        }

        gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture = null;

        gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture = gameObject;
        deleteButton.SetActive(true);


        gameObject.GetComponent<Renderer>().material=outline;//当鼠标滑过时改变物体颜色为蓝色  
        targetScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));


       

    }

    void OnMouseDrag(){


        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

        gameObject.transform.position = new Vector3(pos.x + offset.x, pos.y + offset.y, 0);
    }


    void OnMouseUp()
    {
        choosing = false;

    }




    void OnCollisionEnter(Collision collision)
    {
            gameObject.GetComponent<Renderer  >().sharedMaterial.SetColor("_OutlineColor", Color.red);

        lins = gameObject .transform.position;
            push = true;

        if (push)
        {
            gameObject.transform.position=lins;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        
        if (push)
        {
            gameObject.transform.position=lins;
        }
    }

    //不相交了换成普通描边
    void OnCollisionExit(Collision collision)
    {
        //if (isSelected )
        //{
        gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_OutlineColor", Color.blue);
        //}
        push = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {



                if (choosing == false)
                {
                    Debug.Log("xuankonrg");

                    gameObject.GetComponent<Renderer>().material = normal;

                if (deleteButton.GetComponent<delete>().goingtodelete == true)
                {
                    gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture.GetComponent<Renderer>().sharedMaterial.SetColor("_OutlineColor", Color.blue);

                    Destroy(gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture);
                    deleteButton.GetComponent<delete>().goingtodelete = false;
                }




                    deleteButton.SetActive(false);
                }

                else
                {
                    deleteButton.SetActive(true);

                    Debug.Log("xuanzhong");
                    gameObject.GetComponent<Renderer>().material = outline;
                }



        }

        if(choosing==true){
            deleteButton.SetActive(true);

        }

      


    }

}
