using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCharge : MonoBehaviour {


    public float scrollSpeed;
    private Vector2 savedOffset;
    Material m_Material;



	// Use this for initialization
	void Start () {
        m_Material = GetComponent<Renderer>().material;
        savedOffset = m_Material.GetTextureOffset("_MKGlowTex");
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        m_Material.SetTextureOffset("_MKGlowTex", offset);
	}
}
