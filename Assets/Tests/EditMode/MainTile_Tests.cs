using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MainTile_Tests
    {
        MainTile tile;

        private Sprite image;

        /**
        [SetUp]
        public void SetupGameObject()
        {
            GameObject obj = new GameObject("MainTile");
            tile = obj.AddComponent<MainTile>();
            GetComponent<SpriteRenderer>().sprite = image;
        }
        */

        [Test]
        public void TestSetId()
        {

            tile.ChangeSprite(1,image);

            int testId = tile.id;

            Assert.AreEqual(1, testId);
        }
    }
}
