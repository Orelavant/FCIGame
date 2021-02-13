using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Card references and traits
    public GameObject card;
    private float cardLength = 1f;
    private float cardHeight = 1f;

    // Grid traits
    public int gridWidth;
    public int gridHeight;
    public float gridSpacing;

    // Start is called before the first frame update
    void Start() {
        VisualizeGrid(gridWidth, gridHeight, gridSpacing);
    }

    private void VisualizeGrid(int width, int height, float spacing) {
        Grid grid = new Grid(width, height);
        float addX = 0;
        float addY = 0;

        // Iterate through grid and create it on screen.
        for (int x=0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Instantiate(card, new Vector3(addX, addY, 0), Quaternion.identity);
                addY += cardHeight + spacing;
            }
            addY = 0;
            addX += cardLength + spacing;
        }
    }
}
