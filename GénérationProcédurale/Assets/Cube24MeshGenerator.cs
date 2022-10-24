using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class Cube24MeshGenerator : MonoBehaviour
{
    [SerializeField] private float largeur = 1;
    private static Vector3[] baseVertices = new []
    {
        new Vector3(-.5f,.5f,-.5f),
        new Vector3(.5f,.5f,-.5f),
        new Vector3(.5f,-.5f,-.5f),
        new Vector3(-.5f,-.5f,-.5f),
    };
    private static Matrix4x4[] rotations = new []
    {
     Matrix4x4.Rotate(Quaternion.identity),   
        
     Matrix4x4.Rotate(Quaternion.Euler(0,90,0)),   
     Matrix4x4.Rotate(Quaternion.Euler(0,180,0)),   
     Matrix4x4.Rotate(Quaternion.Euler(0,270,0)),   
     
     Matrix4x4.Rotate(Quaternion.Euler(90,0,0)),
     Matrix4x4.Rotate(Quaternion.Euler(270,0,0)),
     
    };
    private static int[] baseTris = new[]
    {
        0,1,2,2,3,0
    };
    
    private void Awake()
    {
        
        Mesh m = new Mesh();
        
        // MÉTHODE À LA MAIN NON ALGORITHMIQUE. PAS MEILLEURE MÉTHODE
        // int[] tris = new int[]
        // {
        //     // 1ere face
        //     0, 1, 2, 
        //     2, 3, 0,
        //     // 2eme face
        //     4,5,6,
        //     6,7,4,
        //     // 3eme face
        //     8,9,10,
        //     10,11,8,
        //     // 4eme face
        //     12,13,14,
        //     14,15,12,
        //     // 5eme face
        //     16,17,18,
        //     18,19,16,
        //     // 6eme face
        //     20,21,22,
        //     22,23,20
        //     
        // };
        // ATTENTION: IL FAUT BIEN METTRE M.VERTICES AVANT M.TRIANGLES
        GetComponent<MeshFilter>().mesh = m;
        m.vertices = GenerateVertices();
        m.triangles = GenerateTris();
        m.RecalculateNormals();
        
    }

    private Vector3[] GenerateVertices()
    {
        // Générer les sommets
        // Comment?
        // Créer les 4 premiers sommets et additionner la
        // rotation de ces sommets autour de l'origine du cube
        Vector3[] vertices = new Vector3[24];

        int currentVertex = 0;
        // Pour chaque rotation je veux créer un nouveau sommet 4 fois avec cette rotation
        // Pour chque rotation...
        for (int i = 0; i < rotations.Length; ++i)
        {
            // Pour chaque base vertex...
            for (int j = 0; j < baseVertices.Length; ++j)
            {
                vertices[currentVertex++] = rotations[i].MultiplyPoint(baseVertices[j]*largeur);
                //++currentVertex;
            }
        }

        return vertices;
    }

    private int[] GenerateTris()
    {
        int[] tris = new int[36];

        int currentTriIndex = 0;
        
        // Pour chaque face du cube...
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < baseTris.Length; j++)
            {
                tris[currentTriIndex++] = baseTris[j] + (4 * i);
            }
        }

        return tris;
    }
}
