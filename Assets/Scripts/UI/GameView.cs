using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace CLR.UI{
    public class GameView : BaseView{
        [SerializeField] private  Image[] buttonImages;
        [SerializeField] private  Button[] buttons;
        [SerializeField] private Image colorIndicator;
        [SerializeField] private Image[] timeIndicators;
        [SerializeField] private TextMeshProUGUI scoreText;
        private IEnumerator flash;
        private bool isFlashing = false;
        
        public Transform GetTransformButton(int index) => buttons[index].transform;
         
        public int NumberOfButtons() => buttonImages.Length;

        public void ChangeTimeColor(Color color){
            timeIndicators[0].color = color;
            timeIndicators[1].color = color;
            StopAllCoroutines();
            isFlashing = false;
        }
        public void ChangeColorIndicatorColor(Color color){
            colorIndicator.color = color;
        }
        public void ChangeButtonColor(Color color, byte index){
            buttonImages[index].color = color;

        }
        public void Flash(Color first, Color second, float intensity){
            if(!isFlashing){
            flash = FlashTimeIndicator(first,second, intensity);
            StartCoroutine(flash);
            isFlashing = true;
            }
        }
        public override void HideView()
        {
            base.HideView();
            foreach(Button button in buttons){
                button.onClick.RemoveAllListeners();
            }
            StopAllCoroutines();
            isFlashing = false;
        }
        public void AddListiners(UnityAction onHit){
            foreach(Button button in buttons){
                button.onClick.AddListener(onHit);
            }
        }
        public IEnumerator FlashTimeIndicator(Color first, Color second, float timeIntensity){
            while(true){
                timeIndicators[0].color = first;
                timeIndicators[1].color = first;
                yield return new WaitForSeconds(timeIntensity);
                timeIndicators[0].color = second;
                timeIndicators[1].color = second;
                yield return new WaitForSeconds(timeIntensity);
            }
        }
        public void ChangeScore(int score){
            scoreText.text = score.ToString();
        }
        
    }
}