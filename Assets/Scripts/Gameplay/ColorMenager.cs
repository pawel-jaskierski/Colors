using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLR.UI;

namespace CLR.Gameplay{
    public class ColorMenager{
        private List<Color> colors;
        private List<Color> usedColors = new List<Color>();
        private GameView gameView;
        private Color currentColor;
        public Color CurrentColor() => currentColor;

        public ColorMenager(GameView gameView, List<Color> colors){
            this.gameView = gameView;
            this.colors = colors;
        }

        public void OnCorrectGuess(){
            int correctIndexColor = Random.Range(0,colors.Count);
            currentColor = colors[correctIndexColor];
            gameView.ChangeColorIndicatorColor(TakeColorOut(correctIndexColor));
            int correctIndexButton = Random.Range(0,gameView.NumberOfButtons());
            for(byte i = 0; i <gameView.NumberOfButtons(); i++){
                if(correctIndexButton != i){
                gameView.ChangeButtonColor(TakeColorOut(Random.Range(0,colors.Count)),i);
                }
                else gameView.ChangeButtonColor(currentColor,i);
            }
            ReturnColors();
        }
        public Color TakeColorOut(int index){
            Color colorToRemove = colors[index];
            usedColors.Add(colorToRemove);
            colors.RemoveAt(index);
            return colorToRemove;
        }
        public void ReturnColors(){
            foreach(Color color in usedColors){
                colors.Add(color);
            }
            usedColors = new List<Color>();
        }
        public bool ColorCheck(Color color){
            return color == currentColor;
        } 
    }
}