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
                int x = i + j * boardSize;
                boardState[i][j] = 0;
                Transform display = Instantiate(prefabTile);
                boardDisplay[i][j] = display;
                display.SetParent(transform);
                display.GetComponent<Button>().onClick.AddListener(() => TrySpinTile(x));
            }
        }
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
}
