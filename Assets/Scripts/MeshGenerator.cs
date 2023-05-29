using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    [SerializeField] public int xSize = 20;
    [SerializeField] public int zSize = 20;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    /*
    Vector3[] CreateVertices()
    {
        Vector3[] vertices = new Vector3[(size.x + 1) * (size.y + 1)];

        for (int z = 0, i = 0; z <= size.y; z++)
        {
            for (int x = 0; x < size.x; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        return vertices;
    }   */
    /*
    int[] CreateTriangles()
    {
        int[] triangles = new int[(size.x) * (size.y) * 6];

        for (int z = 0, shiftVertices = 0, shiftTriangles = 0; z < size.x; z++)
        {
            for (int x = 0; x < size.y; x++)
            {
                triangles[shiftTriangles + 0] = shiftVertices + 0;
                triangles[shiftTriangles + 1] = shiftVertices + (size.x + 1);
                triangles[shiftTriangles + 2] = shiftVertices + 1;
                triangles[shiftTriangles + 3] = shiftVertices + 1;
                triangles[shiftTriangles + 4] = shiftVertices + (size.x + 1);
                triangles[shiftTriangles + 5] = shiftVertices + (size.x + 2);

                shiftVertices++;
                shiftTriangles += 6;
            }
            shiftVertices++;
        }

        return triangles;
    }
    */
    
    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        int i = 0;
        for (int z = 0; z <= zSize ; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x + .5f, z + .5f)  * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        //öylsine

        triangles = new int[xSize * zSize * 6];
        int shiftVertices = 0;
        int shiftTriangles = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[shiftTriangles + 0] = shiftVertices + 0;
                triangles[shiftTriangles + 1] = shiftVertices + (xSize + 1);
                triangles[shiftTriangles + 2] = shiftVertices + 1;
                triangles[shiftTriangles + 3] = shiftVertices + 1;
                triangles[shiftTriangles + 4] = shiftVertices + (xSize + 1);
                triangles[shiftTriangles + 5] = shiftVertices + (xSize + 2);

                shiftVertices++;
                shiftTriangles += 6;
            }
            shiftVertices++;
        }
        
    }
    
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
