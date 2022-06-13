using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CLR.UI;
using CLR.Gameplay;
using DG.Tweening;
namespace  CLR.Animation
{
    public class ButtonAnimation
    {
        private GameView gameView;
        private ColorMenager colorMenager;
        public int size;
        public ButtonAnimation(ColorMenager colorMenager, GameView gameView){
            this.gameView = gameView;
            this.colorMenager = colorMenager;
            
        }        
        public void DecreaseSize(UnityAction onEnd){
                for(int i = 0; i < gameView.NumberOfButtons()-1; i++){
                    gameView.GetTransformButton(i).DOScale(new Vector3(0.01f,0.01f,0.01f),0.3f);
                }
                gameView.GetTransformButton(gameView.NumberOfButtons()-1).DOScale(new Vector3(0.01f,0.01f,0.01f),0.3f).OnComplete(() => IncreaseSize(onEnd));
        }
        public void IncreaseSize(UnityAction onEnd){
            colorMenager.OnCorrectGuess();
            for(int i = 0; i < gameView.NumberOfButtons()-1; i++){
               gameView.GetTransformButton(i).DOScale(Vector3.one,0.2f);
           }
           gameView.GetTransformButton(gameView.NumberOfButtons()-1).DOScale(Vector3.one,0.2f).OnComplete(() => onEnd.Invoke());
        }
    }
    
}
