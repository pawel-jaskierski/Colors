using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace CLR.UI{

    public class MenuView : BaseView{
        [SerializeField] private Button startButton;
        public void AddOnStartButton(UnityAction onStartButton){
            startButton.onClick.AddListener(onStartButton);
        }
        public void RemoveLisitners(){
            startButton.onClick.RemoveAllListeners();
        }
    }
}