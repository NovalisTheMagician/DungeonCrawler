using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Editor
{
    public class TextureCache
    {
        private string baseTexturePath;
        public string BaseTexturePath
        {
            get { return baseTexturePath; }
            set { baseTexturePath = value; ReloadTextures(); }
        }

        private Dictionary<string, Image> textureMap;

        public IReadOnlyList<string> TextureFiles
        {
            get
            {
                return textureMap.Keys.ToList();
            }
        }

        public IReadOnlyDictionary<string, Image> Textures
        {
            get
            {
                return textureMap;
            }
        }

        public TextureCache()
        {
            textureMap = new Dictionary<string, Image>();
        }

        public void ReloadTextures()
        {
            foreach (Image texture in textureMap.Values)
            {
                texture.Dispose();
            }
            textureMap.Clear();

            if (!Directory.Exists(baseTexturePath))
                Directory.CreateDirectory(baseTexturePath);

            string[] files = Directory.GetFiles(baseTexturePath);
            foreach (string file in files)
            {
                if (IsRightExtension(file))
                {
                    Image newTexture = Image.FromFile(file);
                    textureMap.Add(file, new Bitmap(newTexture));
                    newTexture.Dispose();
                }
            }
        }

        public void RefreshTextures()
        {
            foreach (var texmap in textureMap.ToList())
            {
                string file = texmap.Key;
                Image texture = texmap.Value;

                texture.Dispose();

                if (!File.Exists(file))
                {
                    textureMap.Remove(file);
                }
                else
                {
                    // optimize here to only load the images which have been changed since last loaded
                    // (check file last modified date and store the date somewhere)
                    Image newTexture = Image.FromFile(file);
                    textureMap[file] = new Bitmap(newTexture);
                    newTexture.Dispose();
                }
            }
        }

        private bool IsRightExtension(string path)
        {
            return Regex.IsMatch(GetExtension(path), @"\.bmp|\.png|\.tga");
        }

        private string GetExtension(string path)
        {
            return (Path.GetExtension(path) ?? "").ToLower();
        }
    }
}
