using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class Cube8MeshGenerator : MonoBehaviour
{
    [SerializeField] private float largeur = 2;

    private void Awake()
    {
        Mesh m = new Mesh();
        float halfWidth = largeur / 2;
        Vector3[] vertices = new[]
        {
            new Vector3(-halfWidth,halfWidth,-halfWidth),
            new Vector3(halfWidth,halfWidth,-halfWidth),
            new Vector3(halfWidth,-halfWidth,-halfWidth),
            new Vector3(-halfWidth,-halfWidth,-halfWidth),
            new Vector3(-halfWidth,halfWidth,halfWidth),
            new Vector3(halfWidth,halfWidth,halfWidth),
            new Vector3(halfWidth,-halfWidth,halfWidth),
            new Vector3(-halfWidth,-halfWidth,halfWidth),
            
        };

        int[] tris = new[]
        {
            // 1ere face
            0,1,2,
            2,3,0,
            // 2eme face
            1,5,6,
            6,2,1,
            // 3eme face
            4,5,1,
            1,0,4,
            // 4eme face
            4,0,3,
            3,7,4,
            // 5eme face
            5,4,7,
            7,6,5,
            // 6ème face
            2,6,7,
            7,3,2
            
        };
        GetComponent<MeshFilter>().mesh = m;
        m.vertices = vertices;
        m.triangles = tris;
        // Les normales sont cruciales pour calculer les ombres et les couleurs. Avec cette version de 8 sommets les normales ne serons pas bons.
        // C'est pourquoi il faut utiliser 24 sommets pour avoir les bonnes normales. Puisque chacun aurait sa propre face ce qui ferait des vecteurs perpendiculaire à chaque face.
        m.RecalculateNormals();
    }
}
