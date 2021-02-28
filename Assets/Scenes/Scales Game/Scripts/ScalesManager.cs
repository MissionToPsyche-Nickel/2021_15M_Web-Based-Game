using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScalesManager : MonoBehaviour
{
    public RectTransform field; // where unassigned weights live
    public RectTransform leftScale;
    public RectTransform rightScale;
    public ScaleWeightScript templateWeight;

    private Sprite[] weightSprites;
    private ScaleWeightScript selectedWeight = null;

    // Start is called before the first frame update
    void Start()
    {
        weightSprites = new Sprite[5];
        for (int i = 0; i < 5; i++)
        {
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Scenes/Scales Game/Art/" + (i + 1) + "kg.png");
            weightSprites[i] = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        GenerateWeights(new int[] {2, 2, 4});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLeftScale()
    {
        if (selectedWeight != null)
        {
            selectedWeight.transform.SetParent(leftScale, false);
            selectedWeight = null;
            RefreshPositions(field, -100);
            RefreshPositions(leftScale, 0);
        }
    }

    public void SelectRightScale()
    {
        if (selectedWeight != null)
        {
            selectedWeight.transform.SetParent(rightScale, false);
            selectedWeight = null;
            RefreshPositions(field, -100);
            RefreshPositions(rightScale, 0);
        }
    }

    private void SelectWeight(ScaleWeightScript weight)
    {
        if (selectedWeight != null)
        {
            selectedWeight.transform.localPosition -= new Vector3(0, 25);
        }
        selectedWeight = weight;
        weight.transform.localPosition += new Vector3(0, 25);
    }

    private void RefreshPositions(Transform parent, float offset)
    {
        int children = parent.childCount;
        float delta = (children - 1) * -50 / 2;
        for (int i = 0; i < children; i++)
        {
            parent.GetChild(i).transform.localPosition = new Vector3(i * 50 + delta, offset);
        }
    }

    private void GenerateWeights(int[] weights)
    {
        float offset = (weights.Length - 1) * -50 / 2;
        for (int i = 0; i < weights.Length; i++)
        {
            int weight = weights[i];
            var obj = Instantiate(templateWeight, field, true);
            obj.weight = weight;
            obj.transform.localPosition = new Vector2(i * 50 + offset, -100);
            obj.GetComponent<Image>().sprite = weightSprites[weight-1];
            obj.GetComponent<Button>().onClick.AddListener(() => SelectWeight(obj));
        }
    }
}
