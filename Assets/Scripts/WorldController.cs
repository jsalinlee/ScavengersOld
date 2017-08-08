using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class WorldController : MonoBehaviour {

	public int width = 64;
	public int height = 64;
    public float tileSize = 1.0f;
	
	World world;

	// Use this for initialization
	void Start () {
        world = new World();
        for (int x = 0; x < world.Width; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                GameObject chunk = new GameObject();
                chunk.name = "Chunk_" + x + "_" + y;
            }
        }
    }
	

}


	//public void BuildMesh(){

 //       int vwidth = width + 1;
 //       int vheight = height + 1;
 //       int numVerts = vwidth * vheight;

 //       int numTiles = width * height;
 //       int numTris = numTiles * 2;

	//	Vector3[] vertices = new Vector3[numVerts];
	//	Vector3[] normals = new Vector3[numVerts];
	//	Vector2[] uv = new Vector2[numVerts];

 //       int x, y;

	//	int[] triangles = new int[numTris * 3];
        
 //       for (y = 0; y < vheight; y++)
 //       {
 //           for (x = 0; x < vwidth; x++)
 //           {
 //               vertices[y * vwidth + x] = new Vector3(x * tileSize, y * tileSize, 0);
 //               normals[y * vwidth + x] = Vector3.up;
 //               uv[y * vwidth + x] = new Vector2((float)x / vwidth, (float)y / vheight);
 //           }
 //       }

 //       for (y = 0; y < height; y++)
 //       {
 //           for (x = 0; x < width; x++)
 //           {
 //               int triOffset = (y * width + x) * 6;
 //               triangles[triOffset + 0] = y * vwidth + x + 0;
 //               triangles[triOffset + 1] = y * vwidth + x + vwidth;
 //               triangles[triOffset + 2] = y * vwidth + x + vwidth + 1;

 //               triangles[triOffset + 3] = y * vwidth + x + 0;
 //               triangles[triOffset + 4] = y * vwidth + x + vwidth + 1;
 //               triangles[triOffset + 5] = y * vwidth + x + 1;
 //           }
 //       }

	//	Mesh mesh = new Mesh();
	//	mesh.vertices = vertices;
	//	mesh.triangles = triangles;
	//	mesh.normals = normals;
	//	mesh.uv = uv;

	//	MeshFilter mesh_filter = GetComponent<MeshFilter>();
	//	MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
	//	MeshCollider mesh_collider = GetComponent<MeshCollider>();

	//	mesh_filter.mesh = mesh;
	//}