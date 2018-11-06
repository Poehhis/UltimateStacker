using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    public string name1 ="aa (Tier2) ";
    public string name2 = "aab (Tier3)";
    public string name3 = "a (Tier1) ";
    public string name4 = "aa (Tier2) ";
    public string name5 = "b (Tier1)";

    public float k1, k2, k3, k4, k5;
    public float p1, p2, p3, p4, p5;
    public float s1, s2, s3, s4, s5;

    public Vector3 kps1;
    public Vector3 kps2;
    public Vector3 kps3;
    public Vector3 kps4;
    public Vector3 kps5;

    // Use this for initialization
    void Start () {
    k1 = Random.Range(.3f, 3.0f);
    k2 = Random.Range(.3f, 3.0f);
    k3 = Random.Range(.3f, 3.0f);
    k4 = Random.Range(.3f, 3.0f);
    k5 = Random.Range(.3f, 3.0f);

    p1 = Random.Range(0.3f, 3.0f);
    p2 = Random.Range(0.3f, 3.0f);
    p3 = Random.Range(0.3f, 3.0f);
    p4 = Random.Range(0.3f, 3.0f);
    p5 = Random.Range(0.3f, 3.0f);

    s1 = Random.Range(0.3f, 3.0f);
    s2 = Random.Range(0.3f, 3.0f);
    s3 = Random.Range(0.3f, 3.0f);
    s4 = Random.Range(0.3f, 3.0f);
    s5 = Random.Range(0.3f, 3.0f);
   
    kps1 = new Vector3(k1, p1, s1);
        //Debug.Log("Object kps1: " + kps1);
    kps2 = new Vector3(k2, p2, s2);
    kps3 = new Vector3(k3, p3, s3);
    kps4 = new Vector3(k4, p4, s4);
    kps5 = new Vector3(k5, p5, s5);

    }
	


	// Update is called once per frame
	void Update () {
		
	}
}
