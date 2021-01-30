using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;

namespace Tests
{   
    public class TestSuite
    {
        //create a unit testing case for loading texture
        [UnityTest]
        public IEnumerator TestLoadTexture()
        {// expected result to compare in test
            LoadTexture expected = new LoadTexture(AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/MainGameAssets/SpaceFront.png"));
            // Create a load texture function and load the same picture
            LoadTexture test= new  LoadTexture(AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/MainGameAssets/SpaceFront.png"));
            // now use an assert testing function to see if two objects are equal
            Assert.AreEqual(test, expected);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        }

    }
}
