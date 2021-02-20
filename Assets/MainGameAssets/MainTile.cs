using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTile : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject Tile_Back;

   public void OnMouseDown() 
   {
       if (Tile_Back.activeSelf) 
       {
           Tile_Back.SetActive(false);
           controller.TileRevealed(this);
       }
   }

   private int _id;

   public int id 
   {
       get { return _id; }
   }

   public void ChangeSprite(int id, Sprite image)
   {
       _id = id;
       GetComponent<SpriteRenderer>().sprite = image;
   }

   public void Unreveal()
   {
       Tile_Back.SetActive(true);
   }
}
