using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiObjeto : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("ApagaObjeto", 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        
		
	}

    void ApagaObjeto()
    {
        Destroy(this.gameObject);
    }
}
