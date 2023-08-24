using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private int terrainWidth = 100;
    [SerializeField] private int terrainLength = 100;
    [SerializeField] private float terrainScale = 1f;
    [SerializeField] private int terrainHeight = 10;
    [SerializeField] private float noiseScale = 0.1f;
    [SerializeField] private int seed;

    private void Start()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        if (seed == 0) seed = Random.Range(int.MinValue, int.MaxValue);

        for (int x = 0; x < terrainWidth; x++)
        {
            for (int z = 0; z < terrainLength; z++)
            {
                int y = CalculateTerrainHeight(x, z);
                for (int i = 0; i <= y; i++)
                {
                    Vector3 blockPosition = new Vector3(x * terrainScale, i * terrainScale, z * terrainScale);
                    Instantiate(blockPrefab, blockPosition, Quaternion.identity);
                }
            }
        }
    }

    private int CalculateTerrainHeight(int x, int z)
    {
        float noiseX = (seed + x) * noiseScale;
        float noiseZ = (seed + z) * noiseScale;

        float height = Mathf.PerlinNoise(noiseX, noiseZ);
        return Mathf.RoundToInt(height * terrainHeight);
    }
}
