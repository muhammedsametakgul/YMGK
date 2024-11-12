using UnityEngine;
using System.Collections.Generic;

public class WindmillSpawner : MonoBehaviour
{
    // Windmill prefab
    public GameObject windmillPrefab;

    // List of materials to assign
    public List<Material> materialsList = new List<Material>();

    // Array to store the created windmills
    private GameObject[] windmills;

    // List of predefined spawn points for windmills
    public List<Transform> spawnPoints;

    void Start()
    {
        // Check if there are exactly 6 spawn points
        if (spawnPoints.Count != 6)
        {
            Debug.LogError("Please assign exactly 6 spawn points.");
            return;
        }

        // Initialize the array to store 6 windmills
        windmills = new GameObject[6];

        // Define the 180-degree rotation on the Y-axis
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        // Instantiate windmills at each predefined spawn point
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            // Instantiate windmill with 180 degrees rotation on the Y-axis
            GameObject windmill = Instantiate(windmillPrefab, spawnPoints[i].position, rotation, spawnPoints[i]);
            windmill.transform.localScale = Vector3.one * 0.8f; // Adjust scale as needed

            windmills[i] = windmill;
        }

        // Check if there are enough materials to assign
        if (materialsList.Count < 3)
        {
            Debug.LogError("Please assign at least 3 materials in the materialsList.");
            return;
        }

        // Randomly select two windmills to assign the same material
        int firstIndex = Random.Range(0, windmills.Length);
        int secondIndex;
        do
        {
            secondIndex = Random.Range(0, windmills.Length);
        } while (secondIndex == firstIndex); // Ensure they are different

        // Assign the same material to the selected windmills' child objects
        Material sharedMaterial = materialsList[0];
        SetChildMaterial(windmills[firstIndex], sharedMaterial);
        SetChildMaterial(windmills[secondIndex], sharedMaterial);

        // Assign different materials to the remaining windmills' child objects
        int materialIndex = 1;
        for (int i = 0; i < windmills.Length; i++)
        {
            if (i != firstIndex && i != secondIndex)
            {
                SetChildMaterial(windmills[i], materialsList[materialIndex]);
                materialIndex++;
            }
        }
    }

    // Helper method to set the material of a child object's renderer
    void SetChildMaterial(GameObject windmill, Material material)
    {
        // Assuming the child has a specific name or is the first child
        Transform childTransform = windmill.transform.GetChild(0); // Get the first child
        if (childTransform != null)
        {
            Renderer childRenderer = childTransform.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material = material;
            }
            else
            {
                Debug.LogWarning("Renderer not found on child object.");
            }
        }
        else
        {
            Debug.LogWarning("Child object not found.");
        }
    }
}
