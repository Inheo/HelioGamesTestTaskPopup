using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CustomAnimation
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private Coroutine _current;

        public CustomAnimation(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Play(Action<float> action, float duration, Action fallBack = null)
        {
            if (_current != null)
                _coroutineRunner.StopCoroutine(_current);

            _current = _coroutineRunner.StartCoroutine(PlayTo(action, duration, fallBack));
        }

        private IEnumerator PlayTo(Action<float> action, float duration, Action fallBack = null)
        {
            float lostTime = 0;

            while (lostTime < 1)
            {
                lostTime += Time.deltaTime / duration;
                action?.Invoke(lostTime);
                yield return null;
            }

            fallBack?.Invoke();
        }
    }
}