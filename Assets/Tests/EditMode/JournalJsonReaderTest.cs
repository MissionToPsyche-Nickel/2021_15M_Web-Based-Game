using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JournalJsonReaderTest
    {
        JournalJsonReader jsonReader;
        
        [SetUp]
        public void SetUp()
        {
            jsonReader = new GameObject().AddComponent<JournalJsonReader>();
            jsonReader.jsonFile = Resources.Load("Journal/journal") as TextAsset;
        }

        [Test]
        public void JournalJsonReaderClassExists()
        {
            //Object exists
            Assert.IsNotNull(jsonReader);
            //Object has the correct json file attached
            Assert.IsNotNull(jsonReader.jsonFile);
        }

        [UnityTest]
        public IEnumerator TestStart()
        {
            Assert.Pass("Ignore stack trace");
            yield return null;
        }

        [Test]
        public void JournalFileParsesTest()
        {
            Pages pageList = jsonReader.LoadPagesFromFile();
            
            Assert.IsNotNull(pageList);
        }
        
    }
}
