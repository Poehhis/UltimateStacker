using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    GameControls gamecontrols;
    // Use this for initialization
    public bool hit = false;
	void Start () {
        //gamecontrols = GetComponent<GameControls>();
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided");
        hit = true;   
    }

    // Update is called once per frame
    void Update () {
		
	}
}
