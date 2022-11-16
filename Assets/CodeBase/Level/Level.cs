using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Level
{
    public class Level : MonoBehaviour
    {
        private const string InitialPointTag = "InitialPoint";

        public async Task<GameObject> CreateHero()
        {
            Vector3 pos = GameObject.FindWithTag(InitialPointTag).transform.position;
            GameObject heroGameObject = await Addressables.InstantiateAsync(AddressablePaths.Hero, pos, Quaternion.identity).Task;
            return heroGameObject;
        }

        public void Destroy() =>
            Destroy(gameObject);
    }
}