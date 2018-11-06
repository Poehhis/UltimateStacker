using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour {
    public GameObject floor;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public int objNmbr=1;
    public bool first = true;
    Vector3 blkpos;
    CollisionHandler collisionhandler;
    int rotz = 1;
    int rotx = 1;
    private GUIStyle guiStyle = new GUIStyle();
    private float dist;
    private float locDist;
    private float locDist2 = 0.0f;
    

    // Use this for initialization
    void Start () {
        object1.transform.position = new Vector3(0, 5, 0);
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
            //rotate around x-axis
            if (Input.GetKeyDown(KeyCode.X))
            {
                block.transform.rotation = Quaternion.AngleAxis(90 * rotx, Vector3.left);
                if (rotz % 2 == 0) block.transform.Rotate(new Vector3(0f, 0f, 90f));
                rotx++;
            }
            
            //rotate around z-axis
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //if (rotx % 2 == 1) block.transform.rotation = Quaternion.AngleAxis(90 * rotx, Vector3.left);
                block.transform.rotation = Quaternion.AngleAxis(90*rotz, Vector3.forward);
                if (rotx % 2 == 0) block.transform.Rotate(new Vector3(-90f, 0f, 0f));
                rotz++;
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

        //Reload scene with 'R' key
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        /*Debug.Log("obj1 hit: " + object1.GetComponent<CollisionHandler>().hit);
        Debug.Log("first: "+first);
        Debug.Log("obj number: "+objNmbr);*/
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
                dist = HeDist(object1);
                Debug.Log(dist);
                object2.transform.position = new Vector3(0, 5 + dist, 0);
                first = false;
            }
            return object2;
        }

        if (objNmbr == 3)
        {
            
            if (first == true && object2.GetComponent<CollisionHandler>().hit == true)
            {
                dist = HeDist(object2);
                Debug.Log(dist);
                object3.transform.position = new Vector3(0, 5 + dist, 0);
                first = false;
            }
            return object3;
        }

        if (objNmbr == 4)
        {
            
            if (first == true && object3.GetComponent<CollisionHandler>().hit == true)
            {
                dist = HeDist(object3);
                Debug.Log(dist);
                object4.transform.position = new Vector3(0, 5 + dist, 0);
                first = false;
            }
            return object4;
        }

        if (objNmbr == 5)
        {
            
            if (first == true && object4.GetComponent<CollisionHandler>().hit == true)
            {
                dist = HeDist(object4);
 
                Debug.Log(dist);
                object5.transform.position = new Vector3(0, 5 + dist, 0);
                first = false;
            }
            
        }
        //Just for measuring highest point
        if (objNmbr == 6 && object5.GetComponent<CollisionHandler>().hit == true)
        {
            dist = HeDist(object5);
            Debug.Log("Height after 5th block: " + dist);
            first = false;
        }
        
        return object5;   
    }

    void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.stretchHeight = true;
        guiStyle.stretchWidth = true;
        guiStyle.normal.textColor = Color.cyan;

        //GUILayout.BeginArea(new Rect(20, 20, 250, 120));

        GUILayout.Label("Final height: " + dist, guiStyle);
        //GUILayout.EndArea();
    }

    //Measures distance between floor object and highest block
    float HeDist(GameObject block)
    {
        locDist = Vector3.Distance(new Vector3(.0f, floor.transform.localPosition.y + floor.transform.localScale.y / 2, .0f), new Vector3(.0f, block.transform.position.y + (block.transform.localScale.y / 2), .0f));
        if (locDist > locDist2)
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + ((locDist - locDist2)/2), Camera.main.transform.position.z);
            locDist2 = locDist;
        }
        //Debug.Log("height: " + locDist);
        //Debug.Log("MAX height: " + locDist2);
        return locDist2;
    }
}
