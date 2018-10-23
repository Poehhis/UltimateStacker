using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour {
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public int objNmbr=1;
    Vector3 blkpos;
    public bool first = true;
    CollisionHandler collisionhandler;
    // Use this for initialization
    void Start () {
        object1.transform.position = new Vector3(0, 10, 0);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject block = ObjSelector();
        blkpos = block.transform.position;
        if (block.GetComponent<CollisionHandler>().hit == false)
        {

            //Basic controlls
            if (Input.GetKeyDown("up"))
            {
                //Debug.Log("Up pressed");
                block.transform.position = new Vector3 (blkpos.x, blkpos.y, blkpos.z - 0.5f);
            }
            if (Input.GetKeyDown("down"))
            {
                //Debug.Log("Down pressed");
                block.transform.position = new Vector3(blkpos.x, blkpos.y, blkpos.z + 0.5f);
            }

            if (Input.GetKeyDown("left"))
            {
                //Debug.Log("Left pressed");
                block.transform.position = new Vector3(blkpos.x + 0.5f, blkpos.y, blkpos.z);
            }
            if (Input.GetKeyDown("right"))
            {
                //Debug.Log("Right pressed");
                block.transform.position = new Vector3(blkpos.x - 0.5f, blkpos.y, blkpos.z);
            }

            //Dropping block
            if (Input.GetKeyDown("space"))
            {
                //Debug.Log("Spacebar pressed");
                block.GetComponent<Rigidbody>().useGravity = true;
                first = true;
                objNmbr += 1;
            }

          /*  //cheking that object stays inbound
            if (block.transform.position.z < -4.5f) block.transform.position = new Vector3(blkpos.x, blkpos.y, - 4.5f);
            if (block.transform.position.z > 4.5f) block.transform.position = new Vector3(blkpos.x, blkpos.y, 4.5f);
            if (block.transform.position.x < -4.5f) block.transform.position = new Vector3(-4.5f, blkpos.y, blkpos.z);
            if (block.transform.position.x > 4.5f) block.transform.position = new Vector3(4.5f, blkpos.y, blkpos.z);*/
        }

        //Reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        Debug.Log("obj1 hit: " + object1.GetComponent<CollisionHandler>().hit);
        Debug.Log("first: "+first);
        Debug.Log("obj number: "+objNmbr);
    }
    //Select right object for a situation
    GameObject ObjSelector()
    {

        if (objNmbr == 1)
        {
           /* if (first == true)
            {
                object1.transform.position = new Vector3(0, 10, 0);
                first = false;
            }*/
            return object1;
        }

        if (objNmbr == 2)
        {
            if (first == true && object1.GetComponent<CollisionHandler>().hit == true)
            {
                object2.transform.position = new Vector3(0, 10, 0);
                first = false;
            }
            return object2;
        }

        if (objNmbr == 3)
        {
            if (first == true && object2.GetComponent<CollisionHandler>().hit == true)
            {
                object3.transform.position = new Vector3(0, 10, 0);
                first = false;
            }
            return object3;
        }

        if (objNmbr == 4)
        {
            if (first == true && object3.GetComponent<CollisionHandler>().hit == true)
            {
                object4.transform.position = new Vector3(0, 10, 0);
                first = false;
            }
            return object4;
        }
        if (objNmbr == 5)
        { 
            if (first == true && object4.GetComponent<CollisionHandler>().hit == true)
            {
                object5.transform.position = new Vector3(0, 10, 0);
                first = false;
            }
        }
        return object5;   
    }
}
