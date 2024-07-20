using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapTilemapGenerator : MonoBehaviour
{
    public Tilemap sourceTilemap; // The original wall tilemap
    public Tilemap minimapTilemap; // The tilemap for the minimap
    public Tile solidColorTile; // The solid color tile to use in the minimap

    void Start()
    {
        GenerateMinimapTilemap();
    }

    void GenerateMinimapTilemap()
    {
        if (sourceTilemap == null || minimapTilemap == null || solidColorTile == null)
        {
            Debug.LogError("Please assign all required references in the inspector.");
            return;
        }

        minimapTilemap.ClearAllTiles();

        BoundsInt bounds = sourceTilemap.cellBounds;
        TileBase[] allTiles = sourceTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    minimapTilemap.SetTile(new Vector3Int(x + bounds.xMin, y + bounds.yMin, 0), solidColorTile);
                }
            }
        }

        Debug.Log("Minimap tilemap generated.");
    }
}