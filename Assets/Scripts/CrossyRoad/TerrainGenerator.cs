using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject grassPref;
    public GameObject roadPref;
    public GameObject treePrefab;

    [Header("Settings")]
    private int firstrows = 20;
    public float grassrowdepth = 4f;
    public float roadrowdepth = 6f;
    private float currentZ = 0f;
    public float grassWidth = 200f;

    enum BlockType { Grass, Road }
    private BlockType lastblock = BlockType.Grass;

    private int sameblock = 1;
    private int sameblockmax = 6;
    public int treesPerGrassRow = 5;
    public Transform player;
    private int ahead = 50;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(grassPref, new Vector3(0, 0, currentZ), Quaternion.identity);
            currentZ += grassrowdepth;
        }
        lastblock = BlockType.Grass;
        sameblock = 3;
        for (int i = 0; i < firstrows; i++)
        {
            GenerateRow();
        }
    }

    void Update()
    {
        if (player.transform.position.z + ahead >= currentZ)
        {
            Debug.Log($"Player Z: {player.transform.position.z}, currentZ: {currentZ}, ahead: {ahead}");
            GenerateRow();
        }
    }
    void GenerateRow()
    {
        BlockType chosenType = ChooseNextBlock();
        GameObject prefabToUse;
        float depthToAdd;

        switch (chosenType)
        {
            case BlockType.Grass:
                prefabToUse = grassPref;
                depthToAdd = 4f;
                break;
            case BlockType.Road:
                prefabToUse = roadPref;
                depthToAdd = 6f;
                break;
            default:
                prefabToUse = grassPref;
                depthToAdd = 4f;
                break;
        }
        Instantiate(prefabToUse, new Vector3(0, 0, currentZ), Quaternion.identity);

        if (chosenType == BlockType.Grass)
        {
            SpawnTreesOnGrass(currentZ);
        }
        
        currentZ += depthToAdd;
        if (chosenType == lastblock)
        {
            sameblock++;
        }
        else
        {
            lastblock = chosenType;
            sameblock = 1;
        }
    }

    BlockType ChooseNextBlock()
    {
        if (sameblock >= sameblockmax)
        {
            return DifferentBlock(lastblock);
        }

        int rand = Random.Range(0, 100);
        if (rand < 50)
        {
            return lastblock;
        }
        else
        {
            return DifferentBlock(lastblock);
        }
    }
    BlockType DifferentBlock(BlockType exclude)
    {
        BlockType[] allTypes = { BlockType.Grass, BlockType.Road };
        BlockType choice;
        do
        {
            choice = allTypes[Random.Range(0, allTypes.Length)];
        }
        while (choice == exclude);
        return choice;
    }
    
    void SpawnTreesOnGrass(float zPos)
    {
        for (int i = 0; i < treesPerGrassRow; i++)
        {
            float x = Random.Range(-grassWidth / 2f + 2f, grassWidth / 2f - 2f); 
            float y = 0f; 
            float z = zPos + grassrowdepth / 2f; 

            Vector3 treePos = new Vector3(x, y, z);
            Instantiate(treePrefab, treePos, Quaternion.identity);
        }
    }
}
