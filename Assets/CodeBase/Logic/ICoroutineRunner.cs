using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
    }
}