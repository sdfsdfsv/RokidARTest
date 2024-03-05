// using System;
// using System.Drawing;
// using System.Drawing.Imaging;
// using Aspose.Slides;
// using System.IO;
// using UnityEngine;
// using UnityEngine.UI;

// public class PPTCtrl 
// {
   
//     public static Sprite getPPTPage(Presentation presentation, int num){
//         if (num < presentation.Slides.Count)
//         {
//             var Content = presentation.Slides[num];
//             var BM = Content.GetThumbnail(1f, 1f);
//             //获取高宽
//             int width = BM.Width;
//             int height = BM.Height;
//             byte[] bytes = GetBitMapBytes(BM);
//             Texture2D tex = new Texture2D(width, height); 
//             tex.LoadImage(bytes);  //创建贴图
//             Sprite sp = Sprite.Create(tex, new Rect(0, 0, width, height), Vector2.zero);//创建精灵
//             return sp;
//         }
//         return null;
//     }


//     private static byte[] GetBitMapBytes(Bitmap bm)
//     {
//         try
//         {
//             using (MemoryStream ms = new MemoryStream())
//             {
//                 bm.Save(ms, ImageFormat.Png);
//                 byte[] datas = new byte[ms.Length];
//                 ms.Seek(0, SeekOrigin.Begin);
//                 ms.Read(datas, 0, Convert.ToInt32(ms.Length));
//                 return datas;
//             }
//         }
//         catch (Exception e)
//         {
//             Debug.LogWarning("Get Bytes faile:" + e.ToString());
//             return null;
//         }
//     }

   
// }
