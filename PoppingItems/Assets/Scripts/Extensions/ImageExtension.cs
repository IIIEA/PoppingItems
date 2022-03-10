using UnityEngine;
using UnityEngine.UI;

namespace Test.Extension
{
    public static class ImageExtension
    {
        public static void SetSprite(this Image image, Sprite sprite)
        {
            image.sprite = sprite;
            image.rectTransform.localScale = Vector3.one;
            image.SetNativeSize();
        }
    }
}