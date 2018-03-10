using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyafteranimation : MonoBehaviour {
    private int timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer > 70)
        {
            Destroy(gameObject);
        }
	}
}
