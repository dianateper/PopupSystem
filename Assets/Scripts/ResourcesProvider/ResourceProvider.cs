using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ResourcesProvider
{
   public class ResourceProvider
   {
      public async UniTask LoadTextureAsync(ResourceData resourceData, UnityWebRequest webRequest)
      { 
         await webRequest.SendWebRequest();
         var texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
         SetImageSprite(resourceData, texture);
      }
   
      private void SetImageSprite(ResourceData resourceData, Texture2D texture)
      {
         Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
         resourceData.Image.sprite = sprite;
         resourceData.Image.SetNativeSize();
      }
   }
}
