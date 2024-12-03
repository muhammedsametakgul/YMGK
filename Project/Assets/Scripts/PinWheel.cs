using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PinWheel : MonoBehaviour
{
    public GameObject windmillPrefab;
    public List<Material> materialsList = new List<Material>();
    public List<Transform> spawnPoints;

    public GameObject[] windmills;

    public int sameMaterialIndex1; 
    public int sameMaterialIndex2; 

    void Start()
    {
        if (spawnPoints.Count != 6)
        {
            Debug.LogError("Please assign exactly 6 spawn points.");
            return;
        }

        windmills = new GameObject[6];

        CreateWindmills();
    }

    public void CreateWindmills()
    {
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        foreach (var windmill in windmills)
        {
            if (windmill != null)
                Destroy(windmill);
        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            GameObject windmill = Instantiate(windmillPrefab, spawnPoints[i].position, rotation, spawnPoints[i]);
            windmill.transform.localScale = Vector3.one * 0.8f;
            windmills[i] = windmill;

            TextMeshProUGUI textMeshPro = windmill.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = (i + 1).ToString();
            }
            else
            {
                Debug.LogWarning("TextMeshPro component not found in windmill prefab's Canvas.");
            }
        }

        if (materialsList.Count < 3)
        {
            Debug.LogError("Please assign at least 3 materials in the materialsList.");
            return;
        }

        sameMaterialIndex1 = Random.Range(0, windmills.Length);
        do
        {
            sameMaterialIndex2 = Random.Range(0, windmills.Length);
        } while (sameMaterialIndex2 == sameMaterialIndex1);

        Material sharedMaterial = materialsList[0];
        SetChildMaterial(windmills[sameMaterialIndex1], sharedMaterial);
        SetChildMaterial(windmills[sameMaterialIndex2], sharedMaterial);

        int materialIndex = 1;
        for (int i = 0; i < windmills.Length; i++)
        {
            if (i != sameMaterialIndex1 && i != sameMaterialIndex2)
            {
                SetChildMaterial(windmills[i], materialsList[materialIndex]);
                materialIndex++;
            }
        }
    }

    void SetChildMaterial(GameObject windmill, Material material)
    {
        Transform childTransform = windmill.transform.GetChild(0);
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
