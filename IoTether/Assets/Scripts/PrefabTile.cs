using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Prefab Tile", menuName = "Tiles/Prefab Tile")]
public class PrefabTile : Tile
{
    public GameObject prefab;

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        if (go == null && prefab != null)
        {
            // Get the Tilemap component from the tilemap GameObject
            Tilemap map = tilemap.GetComponent<Tilemap>();
            if (map != null)
            {
                Vector3 worldPosition = map.CellToWorld(position) + map.tileAnchor;
                go = Instantiate(prefab, worldPosition, Quaternion.identity);
                go.transform.parent = map.transform;
            }
        }
        return true;
    }
}
