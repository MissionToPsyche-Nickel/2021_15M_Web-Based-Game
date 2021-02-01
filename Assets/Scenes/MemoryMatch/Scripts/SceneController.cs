using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 3;
    public const int gridCols = 4;
    public const float offsetX = 3.5f;
    public const float offsetY = 2.5f;

    [SerializeField] private MainTile originalTile;
    [SerializeField] private Sprite[] images;

    /** This sets up the game board */
    private void Start()
    {
        //This is a reference for the position of the first tile and builds other positions based off of it.
        Vector3 startPos = originalTile.transform.position;

        int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++) {
            for (int j = 0; j < gridRows; j++) {
                MainTile tile;
                if (i == 0 && j == 0) {
                    tile = originalTile;
                } else {
                    tile = Instantiate(originalTile) as MainTile;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                tile.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                tile.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    /** This shuffles the tiles so they are randomized each play */
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++) {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    /** Control for game logic */
    private MainTile _firstRevealed;
    private MainTile _secondRevealed;
    private int _numMatches = 0;
    [SerializeField] private TextMesh scoreLabel;
    [SerializeField] private TextMesh promptLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void TileRevealed(MainTile tile)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = tile;
        }
        else
        {
            _secondRevealed = tile;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _numMatches++;
            scoreLabel.text = "Matches Found: " + _numMatches;

            //check if the game is won
            if (_numMatches == images.Length)
            {
                promptLabel.text = "You Won!";
                yield return new WaitForSeconds(1.5f);
                GameWon();
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    //This transitions to the main game scene after the player has won this game
    public void GameWon()
    {
        SceneManager.LoadScene("Main");
    }
}
