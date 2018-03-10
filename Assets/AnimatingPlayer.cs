using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingPlayer : MonoBehaviour {


    Animator anim;

	void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	

	void Update () {
		
	}

    void Animating()
    {
       // bool walking = h != 0.0f || v != 0.0f;
      //  anim.SetBool("IsWalking", walking);
    }
}
