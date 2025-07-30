using System;
using System.Threading.Tasks;
using PrimeTween;
using UnityEngine;

namespace Examples.PrimeTweenExample.Scripts
{
    public class TweenTestController : MonoBehaviour
    {
        [SerializeField] private Transform tr1;
        [SerializeField] private Transform tr2;
        
        private async void Start()
        {
            await Wait();
            
            var settings = new TweenSettings(3, Ease.InOutBounce);
            await Tween.Position(tr1, new Vector3(2, 0, 0), new Vector3(-2, 0, 0), settings);

            var sequence = Sequence.Create(5, CycleMode.Yoyo)
                .Chain(Tween.PositionY(tr2, 3, 1));
            
            Debug.Log($"Elapsed time {sequence.elapsedTime}");
        }

        private async Task Wait()
        {
            var settings = new TweenSettings(3, Ease.InOutBounce);
            await Tween.Position(tr1, new Vector3(-2, 0, 0), new Vector3(2, 0, 0), settings);
        }
    }
}