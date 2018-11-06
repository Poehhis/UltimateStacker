using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    Objects obj;
    private string objName1;
    private string objName2;
    private string objName3;
    private string objName4;
    private string objName5;

    private Vector3 obj1cord;
    private Vector3 obj2cord;
    private Vector3 obj3cord;
    private Vector3 obj4cord;
    private Vector3 obj5cord;
   
    int tier = 0;
    private int times = 1;
    // Use this for initialization
    void Start () {

        obj = GetComponent<Objects>();

        objName1 = obj.name1;
        objName2 = obj.name2;
        objName3 = obj.name3;
        objName4 = obj.name4;
        objName5 = obj.name5;

        //Debug.Log(obj.kps1);

        obj1cord = obj.kps1;
        obj2cord = obj.kps2;
        obj3cord = obj.kps3;
        obj4cord = obj.kps4;
        obj5cord = obj.kps5;

        tier = ObjTier(objName1);
        ObjInit(object1);

        tier = ObjTier(objName2);
        ObjInit(object2);

        tier = ObjTier(objName3);
        ObjInit(object3);

        tier = ObjTier(objName4);
        ObjInit(object4);

        tier = ObjTier(objName5);
        ObjInit(object5);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //initialize object
     void ObjInit(GameObject iniObj)
    {
        iniObj.transform.localScale = ScaleForObj();

        ColorSelect(tier, iniObj);           
    }

    //extract tier from the name
    int ObjTier(string name)
    {
        //Debug.Log("name: " + name);

        char[] word = name.ToCharArray();

        //Debug.Log("Letter 1: " + word[];
       

        for (int i = 0; i <= word.Length -1 ; i++)
        {
            //Debug.Log("Letter "+ i +": " + word[i]);
            if (word[i].Equals('T'))
            {
                

                if (word[i + 1].Equals('i') && word[i + 2].Equals('e') && word[i + 3].Equals('r'))
                {
                    //Debug.Log(word[i + 4].ToString());
                    return (int)(word[i + 4] - '0');
                   
                }

            }
        }
        return 1;
    }

    //Change object scale
    Vector3 ScaleForObj()
    {
        Vector3 vec = Vector3.one;
        if (times == 1) vec = new Vector3(obj1cord.x, obj1cord.y, obj1cord.z);
        if (times == 2) vec = new Vector3(obj2cord.x, obj2cord.y, obj2cord.z);
        if (times == 3) vec = new Vector3(obj3cord.x, obj3cord.y, obj3cord.z);
        if (times == 4) vec = new Vector3(obj4cord.x, obj4cord.y, obj4cord.z);
        if (times == 5) vec = new Vector3(obj5cord.x, obj5cord.y, obj5cord.z);
        Debug.Log("times: " + times);
        times++;
        Debug.Log("vector: " + vec);
        return vec;
    }
    
    //Select color for object based on tier in name
    void ColorSelect(int tier, GameObject iniObj)
    {
        if (tier == 1)
        {
            //Set material color
            //Fetch the Renderer from the GameObject
            Renderer rend = iniObj.GetComponent<Renderer>();

            //Set the main Color of the Material to blue
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.blue);

            //Find the Specular shader and change its Color to red
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.red);
        }
        if (tier == 2)
        {
            //setting scale for whole object
            //gameObject.transform.localScale = new Vector3(obj1cord.x, py, sz);
            //Set material color
            //Fetch the Renderer from the GameObject
            Renderer rend2 = iniObj.GetComponent<Renderer>();

            //Set the main Color of the Material to green
            rend2.material.shader = Shader.Find("_Color");
            rend2.material.SetColor("_Color", Color.green);

            //Find the Specular shader and change its Color to red
            rend2.material.shader = Shader.Find("Specular");
            rend2.material.SetColor("_SpecColor", Color.red);
        }
        if (tier == 3)
        {
            //setting scale for whole object
            //gameObject.transform.localScale = new Vector3(kx, py, sz);
            
            //Set material color
            //Fetch the Renderer from the GameObject
            Renderer rend3 = iniObj.GetComponent<Renderer>();

            //Set the main Color of the Material to black
            rend3.material.shader = Shader.Find("_Color");
            rend3.material.SetColor("_Color", Color.black);

            //Find the Specular shader and change its Color to blue
            rend3.material.shader = Shader.Find("Specular");
            rend3.material.SetColor("_SpecColor", Color.blue);
        }

    }
}
