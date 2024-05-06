using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BrickBreaker
{
    public class Block
    {
        public bool vines { get; set;}
        public int hp { get; set; }
        public Rectangle hitBox { get; set;}
        public List<Image> textures { get; set;}
        public Image texture { get; set; }

        public static Random rand = new Random();

        public int texturetype { get; set; }

        public Block(int _x, int _y, int _width, int _hight, int _hp, bool _vines, List<Image> _textures)
        {
            hitBox = new Rectangle(_x, _y, _width, _hight);
            hp = _hp;
            vines = _vines;
            textures = _textures;
            texture = _textures[0];

            //byte[] imageBytes = Convert.FromBase64String(image);
            //
            //// Create a memory stream from the byte array
            //using (MemoryStream ms = new MemoryStream(imageBytes))
            //{
            //    // Create an image from the memory stream
            //    texture.Image = Image.FromStream(ms);
            //}
        }

        static public List<Block> BlockListCreator (XmlDocument level)
        {
            List<Block> bricks = new List<Block>();
            List<List<Image>> textureApendix = TextureApendixCreator(level);
            XmlNodeList blockStrings = level.SelectNodes("//brick");
            foreach (XmlNode brickInfo in blockStrings)
            {
                XmlNode brickRecatnagle = brickInfo.SelectSingleNode("//rectangle");
                int x = Convert.ToInt32(brickRecatnagle.SelectSingleNode("x").InnerText);
                int y = Convert.ToInt32(brickRecatnagle.SelectSingleNode("y").InnerText);
                int width = Convert.ToInt32(brickRecatnagle.SelectSingleNode("width").InnerText);
                int hight = Convert.ToInt32(brickRecatnagle.SelectSingleNode("hight").InnerText);
                int hp = Convert.ToInt32(brickInfo.SelectSingleNode("hp").InnerText);
                int type = Convert.ToInt32(brickInfo.SelectSingleNode("brickType").InnerText);
                bool vines = Convert.ToBoolean(brickInfo.SelectSingleNode("vines").InnerText);
                bricks.Add(new Block(x, y, width, hight, hp, vines, textureApendix[type]));
            }
            return bricks;
        }

        static public List<List<Image>> TextureApendixCreator (XmlDocument level)
        {
            List<List<Image>> TextureApendix = new List<List<Image>>();
            XmlNodeList textureNodeListOfLists = level.SelectNodes("//textures");
            foreach (XmlNode textureListNode in textureNodeListOfLists)
            {
                List<Image> textureList = new List<Image>();
                XmlNodeList textureNodeList = textureListNode.SelectNodes("//texture");
                foreach (XmlNode texture in textureNodeList)
                {
                    textureList.Add(String64ToImage(texture.InnerText));
                }
            }
            return TextureApendix;
        }

        static public Image String64ToImage (string imageString64)
        {
            byte[] imageBytes = Convert.FromBase64String(imageString64);
            
            Image finalImage;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                finalImage = Image.FromStream(ms);
            
            }
            return (finalImage);
        }

        static public List<Block> LoadLevel(string levelName)
        {
            XmlDocument loadedLevel = new XmlDocument();
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string parent1 = Directory.GetParent(currentDirectory).FullName;
            string parent2 = Directory.GetParent(parent1).FullName;
            string parent3 = Directory.GetParent(parent2).FullName;

            string fullPath = Path.Combine(parent3, "Resources", levelName + ".xml");
            loadedLevel.Load(fullPath);
            List<Block> blockList = BlockListCreator(loadedLevel);

            return blockList;
        }

        static void PaintBlocks(Graphics e, List<Block> blockList)
        {
            foreach(Block block in blockList)
            {
                e.DrawImage(block.texture, new PointF(block.hitBox.X, block.hitBox.Y));
            }
        }
    }
}
