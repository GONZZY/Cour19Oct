using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class QuadMeshGenerator : MonoBehaviour
{
     [SerializeField] private float height =1;
     [SerializeField] private float width = 1;

     private void Awake()
     {
          Mesh m = new Mesh();
          float halfHeight = height / 2;
          float halfWidth = width / 2;
          m.vertices = new[]
          {
               new Vector3(-halfWidth, halfHeight),
               new Vector3(halfWidth, halfHeight),
               // new Vector3(halfWidth, 0),
               // new Vector3(-halfWidth, 0),
               
               new Vector3(halfWidth, -halfHeight),
               new Vector3(-halfWidth, -halfHeight),
               // new Vector3(halfWidth, -halfHeight),
               // new Vector3(-halfWidth, -halfHeight),
          };
          m.triangles = new[]
          {
               0, 1, 2, 
               2, 3, 0,
               // 3,2,5,
               // 5,4,3,
               //6,7,4
          };
          // uv a la position 0 est associé avec le sommet 0
          // uv a la position 1 est associé avec le sommet 1
          // ainsi de suite...
          
          
          // Les UV peuvent dépassé 1 si on veut qu'ils se dupliquent
          // Les UV peuvent être négatifs si l'on veut flipper la figure(symétrie)
          // Les UV peuvent être des nombres a virgules par exemple 0.5f pour montrer que la moitié du matériel
          // 
          
          m.uv = new Vector2[]
          {
               new Vector2(0, 1),
               new Vector2(1, 1),
               new Vector2(1, 0),
               new Vector2(0, 0),
               
               // new Vector2(0, 1),
               // new Vector2(1, 1),
               // new Vector2(0, 0),
               // new Vector2(1, 0),
               
          };
          GetComponent<MeshFilter>().mesh = m;
          m.RecalculateNormals();
     }
}
