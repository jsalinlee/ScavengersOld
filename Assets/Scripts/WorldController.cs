using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class WorldController : MonoBehaviour {

	int width = 64;
	int height = 64;
	
	World world;

	// Use this for initialization
	void Start () {
		BuildMesh();
		world = new World();
		for (int x = 0; x < world.Width; x++) {
			for (int y = 0; y < world.Height; y++) {
				GameObject chunk = new GameObject();
				chunk.name = "Chunk_" + x + "_" + y;
			}
		}
	}
	
	void BuildMesh(){
		Vector3[] vertices = new Vector3[4];
		int[] triangles = new int[2 * 3];
		Vector3[] normals = new Vector3[4];
		Vector2[] uv = new Vector2[4];

		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;

		MeshFilter mesh_filter = GetComponent<MeshFilter>();
		MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
		MeshCollider mesh_collider = GetComponent<MeshCollider>();

		mesh_filter.mesh = mesh;
	}
}
