using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPuzzleManager : MonoBehaviour
{
    public int boardSize = 4;
    public Transform prefabTile;

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

        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                int x = i + j * boardSize + 1;
                if (x != boardSize * boardSize) // leave the last square with no transform
                {
                    boardState[i][j] = x;
                    Transform display = Instantiate(prefabTile);
                    display.GetComponentInChildren<Text>().text = x.ToString();
                    boardDisplay[i][j] = display;
                    display.SetParent(transform);
                    display.GetComponent<Button>().onClick.AddListener(() => TryMoveTile(x));
                }
            }
        }
        boardState[boardSize - 1][boardSize - 1] = 0; // last spot needs to have a 0 to prevent undefined behavior
        RefreshPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    display.localPosition = new Vector3(x, -y);
                }
            }
        }
    }

    bool VerifyCompleted()
    {
        return false;
    }

    void TryMoveTile(int id)
    {
        Vector2Int location = FindValue(id);
        Vector2Int empty = FindValue(0);
        if ((empty - location).sqrMagnitude == 1) // this determines if the tile and hole are next to each other
        {
            Swap(location, empty);
            RefreshPositions();
            VerifyCompleted();
        }
    }
    
    Vector2Int FindValue(int id)
    {
        if (id < 0 || id >= boardSize * boardSize)
        {
            return new Vector2Int(-1, -1);
        }
        bool nil = id == 0;
        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (boardState[i][j] == id)
                {
                    return new Vector2Int(i, j);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    void Swap(Vector2Int a, Vector2Int b)
    {
        int tempId = boardState[a.x][a.y];
        Transform tempTrans = boardDisplay[a.x][a.y];
        boardState[a.x][a.y] = boardState[b.x][b.y];
        boardDisplay[a.x][a.y] = boardDisplay[b.x][b.y];
        boardState[b.x][b.y] = tempId;
        boardDisplay[b.x][b.y] = tempTrans;
    }
}
