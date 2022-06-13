using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;

namespace CLR.UI{
    public class EndView : BaseView{
        public Button buttonRestart;
        public Button buttonMenu;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private TextMeshProUGUI scoreMax;
        public void AddListiners(UnityAction restart, UnityAction menu){
            buttonMenu.onClick.AddListener(menu);
            buttonRestart.onClick.AddListener(restart);
        }
        public void RemoveListiners(){
            buttonMenu.onClick.RemoveAllListeners();
            buttonRestart.onClick.RemoveAllListeners();
        }

        internal void SetScore(int score, int highScore)
        {
            this.score.text = "Score: " +score.ToString();
            this.scoreMax.text = "Best Score: " + highScore.ToString();
        }
    }
    
}
