using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start()
    {
        Mesh cube = GetComponent<MeshFilter>().mesh;
        int i = 0;
        foreach (Vector3 vertex in cube.vertices)
        {
            Transform cubeTransform = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            cubeTransform.name = i + " - " + vertex.ToString();
            cubeTransform.position = vertex + transform.position;
            cubeTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            i++;
        }
        print("TRIANGLES");
        for (i = 0;  i < cube.triangles.Length; i += 3)
        {
            print(cube.triangles[i] + ", " + cube.triangles[i + 1] + ", " + cube.triangles[i + 2]);
        }
        print("NORMALS");
        i = 0;
        foreach (Vector3 normal in cube.normals)
        {
            print(i + " - " + normal);
            i++;
        }
        Mesh mesh = new()
        {
            vertices = cube.vertices,
            triangles = cube.triangles,
            normals = cube.normals,
        };
        GameObject meshGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        meshGameObject.GetComponent<MeshFilter>().mesh = mesh;
    }
}
