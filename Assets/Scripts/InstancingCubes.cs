using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class InstancingCubes : MonoBehaviour
{
    [SerializeField] private int size = 10;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;

    //private Matrix4x4[] matrices;

    private void Update()
    {
        //matrices = new Matrix4x4[size * size * size];
        List<List<Matrix4x4>> matrices = new List<List<Matrix4x4>>();

        List<Matrix4x4> newMatricesList = new List<Matrix4x4>();
        matrices.Add(newMatricesList);

        //int i = 0;
        int batch = 0;
        for (int x=0; x < size; x++)
        {
            for (int z=0; z < size; z++)
            {
                matrices[batch].Add(Matrix4x4.TRS(new Vector3(x * 2, Mathf.Sin(Time.time + x + z), z * 2), Quaternion.identity, Vector3.one));
                if (matrices[batch].Count > 1000)
                {
                    batch++;

                    List<Matrix4x4> newMatricesList1 = new List<Matrix4x4>();
                    matrices.Add(newMatricesList1);
                }

            }
        }

        for (int i=0; i <= batch; i++)
        {
            Graphics.DrawMeshInstanced(mesh, 0, material, matrices[i]);
        }
        
    }
}

