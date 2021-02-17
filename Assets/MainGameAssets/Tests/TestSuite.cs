/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;*/

using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace Tests
{
    public class TestSuite
    {
        /*        [SetUp]
                public void ResetScene()
                {

                    EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

                }*/
        [Test]
        public void BasicTest()
        {

            bool isActive = false;

            Assert.AreEqual(false, isActive);

        }


        [Test]
        public void testLoadtexture()
        {

        }
    }
}
