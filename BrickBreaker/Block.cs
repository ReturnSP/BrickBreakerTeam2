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
        public int currentTexture { get; set; }

        public static Random rand = new Random();

        public int texturetype { get; set; }

        public Block(int _x, int _y, int _width, int _height, int _hp, bool _vines, List<Image> _textures)
        {
            hitBox = new Rectangle(_x, _y, _width, _height);
            hp = _hp;
            vines = _vines;
            textures = _textures;
            texture = _textures[textures.Count() - _hp];
            currentTexture = textures.Count() - _hp;
            //byte[] imageBytes = Convert.FromBase64String(image);
            //
            //// Create a memory stream from the byte array
            //using (MemoryStream ms = new MemoryStream(imageBytes))
            //{
            //    // Create an image from the memory stream
            //    texture.Image = Image.FromStream(ms);
            //}
        }

        static public List<Block> BlockListCreator (XmlDocument level, Size screenSize, int levelNumb)
        {
            List<Block> bricks = new List<Block>();
            List<List<Image>> textureApendix = TextureApendixCreator(level, levelNumb);


            XmlNodeList blockStrings = level.SelectNodes("//brick");
            XmlNodeList hitboxStrings = level.SelectNodes("//rectangle");
            List<Rectangle> hitboxes = new List<Rectangle>(); 
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            foreach (XmlNode hitboxInfo in hitboxStrings)
            {
                x = Convert.ToInt32(hitboxInfo.SelectSingleNode("x").InnerText);
                y = Convert.ToInt32(hitboxInfo.SelectSingleNode("y").InnerText);
                width = Convert.ToInt32(hitboxInfo.SelectSingleNode("width").InnerText);
                height = Convert.ToInt32(hitboxInfo.SelectSingleNode("hight").InnerText);

                hitboxes.Add(new Rectangle (x, y, width, height));
            }

            int index = 0;
            foreach (XmlNode brickInfo in blockStrings)
            {
                int hp = Convert.ToInt32(brickInfo.SelectSingleNode("hp").InnerText);
                int type = Convert.ToInt32(brickInfo.SelectSingleNode("brickType").InnerText);
                bool vines = Convert.ToBoolean(brickInfo.SelectSingleNode("vines").InnerText);
                Block scaledBlock = ScaleLevel(screenSize, new Block(hitboxes[index].X, hitboxes[index].Y, hitboxes[index].Width,
                hitboxes[index].Height, hp, vines, textureApendix[type]));

                bricks.Add(scaledBlock);
                index++;
            }
            return bricks;
        }

        static public List<List<Image>> TextureApendixCreator (XmlDocument level, int levelNumb)
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
                if (levelNumb >= 2 && levelNumb != 11)
                {
                    textureList.Reverse();
                }
                TextureApendix.Add(textureList);
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

        static public List<Block> LoadLevel(string levelName, Size screenSize, int levelNumb)
        {
            XmlDocument loadedLevel = new XmlDocument();
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string parent1 = Directory.GetParent(currentDirectory).FullName;
            string parent2 = Directory.GetParent(parent1).FullName;
            string parent3 = Directory.GetParent(parent2).FullName;

            string fullPath = Path.Combine(parent3, "Resources", levelName + ".xml");
            loadedLevel.Load(fullPath);
            List<Block> blockList = BlockListCreator(loadedLevel, screenSize, levelNumb);


            return blockList;
        }


        public static void PaintBlocks(Graphics e, List<Block> blockList)
        {
            foreach(Block block in blockList)
            {
                Rectangle hitbox = block.hitBox;
                Bitmap displayImage = new Bitmap(block.texture);

                Bitmap resizedBitmap = new Bitmap(displayImage, hitbox.Width, hitbox.Height);
                if (hitbox.X > 10000000 || hitbox.Y > 10000000 || hitbox.Y < -100000000 || hitbox.X < -1000000000)
                {

                }
                else
                {
                    e.DrawImage(resizedBitmap, new Point(hitbox.X, hitbox.Y));
                }
                
                displayImage.Dispose();
                resizedBitmap.Dispose();
            }
        }
        
        static public Block ScaleLevel(Size screenSize, Block block)
        {
            Size ogSize = new Size(1366, 768);

            float percentDiffWidth = (float)block.hitBox.Width / (float)ogSize.Width;
            float percentDiffHeight = (float)block.hitBox.Height / (float)ogSize.Height;
            float percentDiffX = (float)block.hitBox.X / (float)ogSize.Width;
            float percentDiffY = (float)block.hitBox.Y / (float)ogSize.Height;



            Block scaledBlock = new Block((int)((float)(screenSize.Width * percentDiffX) + 150), (int)((float)screenSize.Height * percentDiffY), (int)((float)screenSize.Width * percentDiffWidth), (int)((float)screenSize.Height * percentDiffHeight), block.hp, block.vines, block.textures);

            return scaledBlock;
        }
        public static PointF RotatePoint(PointF point, PointF pivot, double radians)
        {
            var cosTheta = Math.Cos(radians);
            var sinTheta = Math.Sin(radians);

            var x = (cosTheta * (point.X - pivot.X) - sinTheta * (point.Y - pivot.Y) + pivot.X);
            var y = (sinTheta * (point.X - pivot.X) + cosTheta * (point.Y - pivot.Y) + pivot.Y);

            return new PointF((float)x, (float)y);
        }
        public static PointF LineScaler(PointF startPoint, PointF endPoint, float fixedLineLength)
        {
            float dx = endPoint.X - startPoint.X;
            float dy = endPoint.Y - startPoint.Y;
            float length = (float)Math.Sqrt(dx * dx + dy * dy);

            float normalizedDx = dx / length;
            float normalizedDy = dy / length;

            // Calculate the scaled end point to achieve the fixed line length
            float scaledEndX = startPoint.X + normalizedDx * fixedLineLength;
            float scaledEndY = startPoint.Y + normalizedDy * fixedLineLength;
            return new PointF(scaledEndX, scaledEndY);
        }

        public static List<Block> LevelChanger(int levelNumber, Size screenSize)
        {
            return LoadLevel("level" + levelNumber, screenSize, levelNumber);
        }

    }
}
