using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class GenerateCube : MonoBehaviour
{
       [SerializeField] private float edgeSize;
       [SerializeField] private int nbOfVertex;
       private void Awake()
       {
              // Définir la dimension du Cube
              float halfEdgeSize = edgeSize / 2;
              
              Mesh cubeMesh = new Mesh();
              
              // Set Vertices d'une face
              Vector3[] vertices = new Vector3[]
              {
                     // new Vector3(-halfEdgeSize, halfEdgeSize),
                     // new Vector3(-halfEdgeSize, -halfEdgeSize),
                     // new Vector3(halfEdgeSize, -halfEdgeSize),
                     // new Vector3(halfEdgeSize, halfEdgeSize),
                     new Vector3(halfEdgeSize,halfEdgeSize,halfEdgeSize),
                     new Vector3(halfEdgeSize,-halfEdgeSize,halfEdgeSize),
                     new Vector3(-halfEdgeSize,-halfEdgeSize,halfEdgeSize),
                     new Vector3(-halfEdgeSize,halfEdgeSize,halfEdgeSize),
                     
                     
                     
                     
              };
              Vector3[] rotations = new Vector3[]
              {
                     new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(90,0,0),new Vector3(-90,0,0)
              };
              
              Vector3[] verticesTemp = new Vector3[nbOfVertex];
              for (int i = 0; i < nbOfVertex; i++)
              {
                      // Créer chaque vertex
                      if (i < 4)
                      {
                             verticesTemp[i] = vertices[i];
                      }
                      else
                      {
                             verticesTemp[i] =  Quaternion.Euler(rotations[i % 4]) * vertices[i % 4];
                      }
                     
              }
              cubeMesh.vertices = verticesTemp;
              //cubeMesh.triangles = new int[] {0,1,2,0,2,3};
         
              GetComponent<MeshFilter>().mesh = cubeMesh;

       }
}
