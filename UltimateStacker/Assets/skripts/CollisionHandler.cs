using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    GameControls gamecontrols;
    // Use this for initialization
    public bool hit = false;
	void Start () {
        //gamecontrols = GetComponent<GameControls>();
        
        //Set object scale
        gameObject.transform.localScale = new Vector3(Random.Range(0.2f,3.0f), Random.Range(0.3f, 3.0f), Random.Range(0.2f, 3.0f));

        //Set material color
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);
        
        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        hit = true;   
    }

    // Update is called once per frame
    void Update () {
		
	}
}
