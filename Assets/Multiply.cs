using UnityEngine;

public class Multiply : MonoBehaviour
{
    public int numberOfLines = 3; // Set the desired number of lines in the Unity Inspector
    public int cubesPerLine = 5; // Set the desired number of cubes per line in the Unity Inspector
    public GameObject cubePrefab; // Référence au prefab du cube à créer

    void Start()
    {
        // The Start method will be automatically called when the project runs,
        // but if you want to create cubes manually, you can remove the comment from the line below.
        CreateCubesManually();
    }

    // This method can be called manually to create cubes without starting the project
    public void CreateCubesManually()
    {
        // Vérifier si le prefab du cube est assigné
        if (cubePrefab == null)
        {
            Debug.LogError("Cube prefab is not assigned!");
            return;
        }

        // Get the original cube's renderer to access its size
        Renderer originalCubeRenderer = cubePrefab.GetComponent<Renderer>();

        // Calculate the offset to place cubes next to each other based on the original cube's size
        float offsetX = originalCubeRenderer.bounds.size.x;
        float offsetY = originalCubeRenderer.bounds.size.y;

        for (int i = 0; i < numberOfLines; i++)
        {
            for (int j = 0; j < cubesPerLine; j++)
            {
                // Instantiate a cube from the prefab
                GameObject cube = Instantiate(cubePrefab);

                cube.tag = "cube";
                // Position the new cube in a line, with an offset
                cube.transform.position = transform.position + new Vector3(offsetX * j, offsetY * i, 0);

                // Set a random color for the cube
                cube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);

                // Optionally, you can parent the cube to the script's GameObject for cleaner hierarchy
                cube.transform.parent = transform;
            }
        }
    }
}
