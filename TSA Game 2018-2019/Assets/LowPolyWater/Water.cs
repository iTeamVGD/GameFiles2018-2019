﻿using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour 
{
    public float scale = 7.0f;
    public float heightScale = 1.0f;
    private Vector2 v2SampleStart = new Vector2(0f, 0f);
    public float speed = 0.5f;

	// Update is called once per frame
	void Update () 
    {
        float time = Time.time * speed;
        MeshFilter mf = GetComponent<MeshFilter>();
        Vector3[] vertices = mf.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = heightScale * Mathf.PerlinNoise(time + (vertices[i].x * scale), time + (vertices[i].z * scale));
        }
        mf.mesh.vertices = vertices;
	}
}
