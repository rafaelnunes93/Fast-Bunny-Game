using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffSet : MonoBehaviour
{
    private Renderer meshRender;
    private Material currentMaterial;

    public  float incrementoOffset;
    public float speed;

    public string sortingLayer;
    public int orderInlayer;

    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        //inicia o MasRender
        meshRender = GetComponent<MeshRenderer>();
        meshRender.sortingLayerName = sortingLayer;
        meshRender.sortingOrder = orderInlayer;

        //Pega o material que esta no Objeto
        currentMaterial = meshRender.material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset += incrementoOffset;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
