using UnityEngine;
using System.Collections;

public class BoxSize : MonoBehaviour {


	private Vector3[] newVertices = new [] { new Vector3(0.5f, 0.5f, 0.5f), 
									 new Vector3(-0.5f, 0.5f, 0.5f), 
									 new Vector3(-0.5f, 0.5f, -0.5f), 
									 new Vector3(0.5f, 0.5f, -0.5f), 
									 new Vector3(0.5f, 0.5f, 0.5f), 
									 new Vector3(-0.5f, -0.5f, 0.5f), 
									 new Vector3(-0.5f, -0.5f, -0.5f), 
									 new Vector3(0.5f, -0.5f, -0.5f)};
		
	Vector2[] newUV = new Vector2[] 
		{
			new Vector2 (0,1),
			new Vector2 (0,0),
			new Vector2 (1,1),
			new Vector2 (1,0),

			new Vector2 (0,1),
			new Vector2 (0,0),
			new Vector2 (1,1),
			new Vector2 (1,0)
		};

	int[] newTriangles = new int[] 
		{
			3,1,0,
			2,1,3,

			6,2,3,
			7,6,3
		};
		
	public float width =  1;
	public float height = 1;
	public float depth =  1;

	void Start()
	{
		Mesh mesh = new Mesh();
		MeshFilter mf = GetComponent<MeshFilter> ();
		mf.mesh = mesh;

		for (int i =0; i < newVertices.Length;) {
			newVertices[i] = Vector3.Scale(newVertices[i++], new Vector3 (width, height, depth));
		} 
		mesh.vertices = newVertices;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;
		mesh.Optimize();
		mesh.RecalculateNormals();
	}

	// Update is called once per frame
	void Update () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;

		for (var i = 0; i < vertices.Length; i++)
		{
			//vertices[i] += normals[i] * Mathf.Sin(Time.time);
		}

		mesh.vertices = vertices;
	}
}
