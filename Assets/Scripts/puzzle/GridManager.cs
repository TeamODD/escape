// using UnityEngine;
//
// public class GridManager : MonoBehaviour
// {
//     public int width = 4;
//     public int height = 4;
//     public float cellSize = 1f;
//     public Sprite[,] tileSprites;
//     public Sprite[] tileSpritesArray;
//     
//     public Sprite floorSprite;
//     public Sprite wallSprite;
//     public Sprite goalSprite;
//     
//     private Grid grid;
//
//     private void Start()
//     {
//         grid = new Grid(
//             width,
//             height,
//             cellSize,
//             Vector3.zero,
//             floorSprite,
//             wallSprite,
//             goalSprite
//         );
//         
//     }
//
//     private void AssignSpritesToEachTile()
//     {
//         for (int y = 0; y < height; y++)
//         {
//             for (int x = 0; x < width; x++)
//             {
//                 int index = x+y*width;
//                 if (index < tileSpritesArray.Length)
//                 {
//                     grid.SetTileSprite(x,y,tileSpritesArray[index]);
//                 }
//             }
//         }
//     }
// }
