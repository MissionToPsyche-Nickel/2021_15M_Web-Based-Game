using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SliderPuzzleManager : MonoBehaviour
{
    public int boardSize = 4;
    public RectTransform prefabTile;

    private int[][] boardState;
    private Transform[][] boardDisplay;

    // Start is called before the first frame update
    void Start()
    {
        boardState = new int[boardSize][];
        boardDisplay = new Transform[boardSize][];
        for (int i = 0; i < boardSize; i++)
        {
            boardState[i] = new int[boardSize];
            boardDisplay[i] = new Transform[boardSize];
        }

        float delta = 128.0f / boardSize;
        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                int x = i + j * boardSize;
                boardState[i][j] = 0;
                RectTransform display = Instantiate(prefabTile);
                display.offsetMin = new Vector2(-delta, -delta);
                display.offsetMax = new Vector2(delta, delta);
                boardDisplay[i][j] = display;
                display.SetParent(transform);
                display.GetComponent<Button>().onClick.AddListener(() => TrySpinTile(x));
            }
        }
        ShuffleBoard();
        RefreshPositions();
        LoadTexture(AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Scenes/Sliding Puzzle/Possible Images/sun.jpg"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleBoard()
    {
        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                boardState[i][j] = Random.Range(0, 4);
            }
        }
    }

    void RefreshPositions()
    {
        float gap = 256 / boardSize;
        float offset = (gap % 2 == 1) ? 0 : -gap / 2; // If the board size is odd, offset is 0. If it's even, offset is a half-step left.
        int dt = (boardSize - 1) / 2;
        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                Transform display = boardDisplay[i][j];
                if (display)
                {
                    float x = (i - dt) * gap + offset;
                    float y = (j - dt) * gap + offset;
                    display.localPosition = new Vector3(x, y);
                    display.localEulerAngles = new Vector3(0, 0, boardState[i][j] * -90);
                }
            }
        }
    }

    bool VerifyCompleted()
    {
        return false;
    }

    void TrySpinTile(int id)
    {
        int x = id % boardSize;
        int y = id / boardSize;

        // increment then modulo 4, since 0-3 is the set of rotations
        boardState[x][y]++;
        boardState[x][y] %= 4;

        RefreshPositions();
    }

    public void LoadTexture(Texture2D texture)
    {
        int width = texture.width / boardSize;
        int height = texture.height / boardSize;

        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                Texture2D tex = new Texture2D(width, height);
                tex.SetPixels(texture.GetPixels(width * i, height * j, width, height));
                tex.Apply();
                boardDisplay[i][j].GetComponent<RawImage>().texture = tex;
            }
        }
    }
}
