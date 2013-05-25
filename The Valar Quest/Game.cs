using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
namespace The_Valar_Quest
{
    public enum type_of_challenge {EASY,MEDUM_HARD, HARD, EXTRA_HARD};
    public enum type_of_asset {EXTRA_TIME, SLOWDOWN_TIME, FREEZE_TIME, LIFE};
   
    public partial class Game : Form
    {
        private int height=20;
        private int width=20;
        private Character character;
        private int timepassed;
        private int time;
        private List<Asset> assets;
        private int num_assets;
        private int level; //max 10
        private int starttime = 15;
        private Vertex start;
        private Vertex end;
        private bool paused;
        private Asset asset_in_use;
        private Vertex[][] matrix;
        private Random r = new Random();
        private bool[][] maze;
        private List<Asset> maze_assets;
        private List<Vertex> path;
        private int time_asset;
        private bool use;
        private bool between_level;
        private int time_passed_asset;

        public Game()
        {
            InitializeComponent();

          

        }

        public Game(string ime) {

            InitializeComponent();
            this.DoubleBuffered = true;

            between_level = false;
            use = false;
            maze_assets = new List<Asset>();
            Vertex st= new Vertex(0,0);
           character = new Character(ime,st);
            assets = new List<Asset>();
            num_assets=2;
            
            level = 1;
            setUpLevel();//set up level generira info za maze
            

            if (ime == "Varda")
            {
                ExtraTime et1 = new ExtraTime(5);
                FreezeTime ft = new FreezeTime();
                assets.Add(ft);
                assets.Add(et1);
            }
            else
            {
                SlowdownTime slt = new SlowdownTime();
                ExtraTime et1 = new ExtraTime(10);
                assets.Add(et1);
                assets.Add(slt);
            }
                updategraphics();
        }

        public void setUpLevel(){
            if (character.lives != 0)
            {
                time = starttime + level * 2;
                Maze();
                end=findPath();
                while (end == null)
                {
                    Maze(); end = findPath();
                }
                    Invalidate();
                setAssets();
                timepassed = 0;
                Invalidate();
                timer.Start();
            }
            else {
                this.Close();
                // GAME OVER
            }
        }

       public void Maze() {


           matrix = new Vertex[height][];
           for (int i = 0; i < matrix.Length; i++)
           {
               matrix[i] = new Vertex[width];
           }
           // gen matrica so Vertices

           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   matrix[i][j] = new Vertex(i, j);
                   if (i - 1 >= 0) { matrix[i][j].neighbours[0] = 1; } else { matrix[i][j].neighbours[0] = -1; }
                   if (i + 1 < width) { matrix[i][j].neighbours[1] = 1; } else { matrix[i][j].neighbours[1] = -1; }
                   if (j - 1 >= 0) { matrix[i][j].neighbours[2] = 1; } else { matrix[i][j].neighbours[2] = -1; }
                   if (j + 1 < height) { matrix[i][j].neighbours[3] = 1; } else { matrix[i][j].neighbours[3] = -1; }
               }
           }
           start = matrix[0][0];
           Stack<Vertex> st = new Stack<Vertex>();
           
           Vertex currentBlock = start;

           
          maze = new bool[height][];

           for (int i = 0; i <height; i++)
           {
               maze[i] = new bool[width];
           }

           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   maze[i][j] = false;
               }
           }

           int stack_push = 1;
         while (st.Count!=1) {


             st.Push(start);
              if (this.hasNotMarkedNeighbours(matrix[currentBlock.i][currentBlock.j].neighbours, currentBlock.i, currentBlock.j))
              {
                  // select random direction od neighbours

                  int rand = generateRandomDirection(currentBlock);
                  bool falseBlockFound = false;
                  while (!falseBlockFound)
                  {
                      if (rand == 0)
                      {
                          if (currentBlock.i - 1 >= 0) { if (!maze[currentBlock.i - 1][currentBlock.j]) { break ; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }
                      if (rand == 1)
                      {
                          if (currentBlock.i + 1 < height) { if (!maze[currentBlock.i + 1][currentBlock.j]) { break; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }
                      if (rand == 2)
                      {
                          if (currentBlock.j - 1 >= 0) { if (!maze[currentBlock.i][currentBlock.j - 1]) { break; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }
                      if (rand == 3)
                      {
                          if (currentBlock.j + 1 < width) { if (!maze[currentBlock.i][currentBlock.j + 1]) { break; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }

                  }

                      matrix[currentBlock.i][currentBlock.j].neighbours[rand] = 0;
                    maze[currentBlock.i][currentBlock.j] = true;
                  int pos1 = currentBlock.i; int pos2 = currentBlock.j;
                  switch (rand)
                  {
                      case 0: currentBlock = matrix[pos1 - 1][pos2]; break;
                      case 1: currentBlock = matrix[pos1 + 1][pos2]; break;
                      case 2: currentBlock = matrix[pos1][pos2 - 1]; break;
                      case 3: currentBlock = matrix[pos1][pos2 + 1]; break;
                  }
                  st.Push(currentBlock); stack_push++;
              }
              else {
                  if (maze[currentBlock.i][currentBlock.j] == false) {
                      maze[currentBlock.i][currentBlock.j] = true;
                      for (int i = 0; i < currentBlock.neighbours.Length; i++) {
                          if (currentBlock.neighbours[i] > 0) { currentBlock.neighbours[i] = 0; break; }
                      }
                  }
                  st.Pop();
                  for (int i = 0; i < st.Peek().neighbours.Length; i++) {
                     if (st.Peek().neighbours[i] == 0) { matrix[currentBlock.i][currentBlock.j].neighbours[i] = 0; //MessageBox.Show("execute !"); 
                         break; }
                  }
                      if (st.Count != 0)
                      {
                          currentBlock = nextAvailableVertex(st.Peek());
                      }
                      else break;
                  while (currentBlock == null && st.Count!=1)
                  {
                      
                      st.Pop();
                      Vertex tmp = st.Peek();
                      currentBlock = nextAvailableVertex(tmp);
                  }
               
                  }                             
           }
           
       }
       public Vertex nextAvailableVertex(Vertex v) {
           if (v.neighbours[0] > 0 && v.i - 1 >= 0) { if(!maze[v.i-1][v.j]) return matrix[v.i-1][v.j];}
           if (v.neighbours[1] > 0 && v.i + 1 <height) { if (!maze[v.i + 1][v.j]) return matrix[v.i + 1][v.j]; }
           if (v.neighbours[2] > 0 && v.j - 1 >= 0) { if (!maze[v.i][v.j-1]) return matrix[v.i][v.j-1]; }
           if (v.neighbours[3] > 0 && v.j + 1 <width) { if (!maze[v.i][v.j+1]) return matrix[v.i][v.j+1]; }
           return null;
       }

       public int generateRandomDirection(Vertex currentBlock) {
           int[] rand_num; int it = 0;
           for (int i = 0; i < currentBlock.neighbours.Length; i++)
           {
               if (currentBlock.neighbours[i] > 0) it++;
           }
           rand_num = new int[it]; it = 0;
           for (int i = 0; i < currentBlock.neighbours.Length; i++)
           {
               if (currentBlock.neighbours[i] > 0) rand_num[it++] = i;
           }
           int rand = r.Next(0, rand_num.Length);
           return rand_num[rand];
       }

       public bool hasNotMarkedNeighbours(int [] array, int i, int j) {
           bool b = false;
           if (array[0] > 0) { if(i-1>=0) if (!maze[i - 1][j]) return true; }
           if (array[1] > 0) { if (i+1<height) if (!maze[i + 1][j]) return true; }
           if (array[2] > 0) { if(j-1>=0) if (!maze[i][j-1]) return true; }
           if (array[3] > 0) { if(j+1<width) if (!maze[i][j+1]) return true; }
           return b;
       }

       public bool notAllTrue() {

           bool b = false;
           for (int i = 0; i < height; i++) {
               for (int j = 0; j < width; j++) {
                   if (!maze[i][j]) { b = true; break; }
               }
               if (b) break;
           }
           return b;
       }

       public Vertex findPath() {
           int min_l= 20+level *3;

           bool[][] visited = new bool[height][];
           for (int i = 0; i < height; i++) {
               visited[i] = new bool [width];
           }
           for (int i = 0; i < height; i++) {
               for (int j = 0; j < width; j++) {
                   visited[i][j] = false;
               }
           }

               path = new List<Vertex>();
           Vertex currentBlock = start;
           int dolz = 0; Vertex lastBlock=start;
           
           while (true) {
               path.Add(currentBlock);
               visited[currentBlock.i][currentBlock.j] = true;
               int zero_pos = -1;
               for (int i = 0; i < currentBlock.neighbours.Length; i++) {
                   if (currentBlock.neighbours[i] == 0) {
                       zero_pos = i;
                   }
               }
               dolz++;
               if (zero_pos == 0) {
                   if (visited[currentBlock.i - 1][currentBlock.j]) { lastBlock = currentBlock;  break; }
                   else {
                       currentBlock = matrix[currentBlock.i - 1][currentBlock.j];
                   }
               }
               if (zero_pos == 1)
               {
                   if (visited[currentBlock.i + 1][currentBlock.j]) { lastBlock = currentBlock; break; }
                   else
                   {
                       currentBlock = matrix[currentBlock.i + 1][currentBlock.j];
                   }
               }
               if (zero_pos == 2)
               {
                   if (visited[currentBlock.i][currentBlock.j-1]) { lastBlock = currentBlock; break; }
                   else
                   {
                       currentBlock = matrix[currentBlock.i ][currentBlock.j-1];
                   }
               }
               if (zero_pos == 3)
               {
                   if (visited[currentBlock.i][currentBlock.j + 1]) { lastBlock = currentBlock; break; }
                   else
                   {
                       currentBlock = matrix[currentBlock.i][currentBlock.j + 1];
                   }
               }
           }
           if (dolz > min_l)
               return lastBlock;
           else return null;
       }

       public void setAssets() { 
        //postavi lista maze_assets random
           int rndasset = 4 - num_assets;
           if (rndasset >= 1) {
               int rd = r.Next(0,4);
               if (character.lives == 3) rd = r.Next(0,3);
               Vertex l = pickRandomVertexFromPath();
               if (rd == (int)type_of_asset.EXTRA_TIME) { int rd1 = r.Next(200); int s = 0; if (rd1 % 2 == 0) s = 5; else s = 10; ExtraTime et = new ExtraTime(s); et.location = l; maze_assets.Add(et); }
               if (rd == (int)type_of_asset.SLOWDOWN_TIME) { SlowdownTime slt = new SlowdownTime(); slt.location = l; maze_assets.Add(slt); }
               if (rd == (int)type_of_asset.FREEZE_TIME) { FreezeTime ft = new FreezeTime(); ft.location = l; maze_assets.Add(ft); }
               if (rd == (int)type_of_asset.LIFE) { Life life = new Life(); life.location = l; maze_assets.Add(life); }
           }
           rndasset -= 1;
           for (int i = 0; i < rndasset; i++) {
               int x = r.Next(0,height);
               int y = r.Next(0, width );
               Vertex l = matrix[x][y];
               int rd = r.Next(0, 4); if (character.lives == 3) rd = r.Next(0, 3);
               if (rd == (int)type_of_asset.EXTRA_TIME) { int rd1 = r.Next(200); int s = 0; if (rd1 % 2 == 0) s = 5; else s = 10; ExtraTime et = new ExtraTime(s); et.location = l; maze_assets.Add(et); }
               if (rd == (int)type_of_asset.SLOWDOWN_TIME) { SlowdownTime slt = new SlowdownTime(); slt.location = l; maze_assets.Add(slt); }
               if (rd == (int)type_of_asset.FREEZE_TIME) { FreezeTime ft = new FreezeTime(); ft.location = l; maze_assets.Add(ft); }
               if (rd == (int)type_of_asset.LIFE) { Life life = new Life(); life.location = l; maze_assets.Add(life); }
           }
       }

       public Vertex pickRandomVertexFromPath() {
           return path.ElementAt(r.Next(1,path.Count-2));
       }

       public void checkifkraj() {
           if (character.getLocation().i == end.i && character.getLocation().j == end.j)
           {
               if (level < 15)
               {
                   timer.Stop();
                   MessageBox.Show("Congratulations on passing level" + level + "! You may now proceed to the next level by clicking on the next level button!");
                   maze_assets.Clear();
                   level += 1; button3.Enabled = true; between_level = true; character.changeLocation(matrix[0][0]);
               }
               else
               {
                   timer.Stop();
                   MessageBox.Show("CONGRATULATIONS! YOU WON!"); this.Close();
               }
           }
       }

       public void checkifasset() {
           for (int i = 0; i < maze_assets.Count; i++) {
               if (character.getLocation().i == maze_assets.ElementAt(i).location.i && character.getLocation().j == maze_assets.ElementAt(i).location.j)
               {
                   //open Question form , challenge
                   timer.Stop();
                   if (maze_assets.ElementAt(i).challenge())
                   {


                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.LIFE)
                       {
                           character.lives += 1; updategraphics(); timer.Start(); 
                       }

                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.EXTRA_TIME)
                       {
                           ExtraTime et = (ExtraTime)maze_assets.ElementAt(i);
                           assets.Add(et); updategraphics(); timer.Start(); 
                       }

                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.SLOWDOWN_TIME)
                       {
                           SlowdownTime slt = (SlowdownTime)maze_assets.ElementAt(i);
                           assets.Add(slt); updategraphics(); timer.Start(); 
                       }

                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.FREEZE_TIME)
                       {
                           FreezeTime ft = (FreezeTime)maze_assets.ElementAt(i);
                           assets.Add(ft); updategraphics(); timer.Start();
                       }

                   }
                   else {
                       

                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.EXTRA_TIME)
                       {
                           ExtraTime et = (ExtraTime)maze_assets.ElementAt(i);
                           time -= et.penalty;
                       }

                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.SLOWDOWN_TIME)
                       {
                           time -= 3;
                       }

                       if (maze_assets.ElementAt(i).t_asset == type_of_asset.FREEZE_TIME)
                       {
                           time -= 3;
                       }

                       timer.Start();
                       
                   }

                   Asset tmp = maze_assets.ElementAt(i);
                   maze_assets.Remove(tmp); updategraphics();
               }
           }
       }

       protected override bool ProcessDialogKey(Keys keyData)
       {
           if (keyData == Keys.Left|| keyData==Keys.A)
           {
               if (!paused && !between_level)
               {
                   Vertex loc = character.getLocation();
                   if (loc.j - 1 >= 0)
                   {
                       Vertex levo = matrix[loc.i][loc.j - 1];
                       if (levo.neighbours[3] == 0 || matrix[loc.i][loc.j].neighbours[2] == 0)
                       {
                           character.changeLocation(new Vertex(loc.i, loc.j - 1));
                           Invalidate();
                       }
                   }
                   checkifkraj();
                   checkifasset();
                   //check na levo, ako e pat odi

                   return true;
               }
               else return false;
           }
           else if (keyData == Keys.Right || keyData == Keys.D)
           {
               if (!paused && !between_level)
               {
                   Vertex loc = character.getLocation();
                   if (loc.j + 1 < width)
                   {
                       Vertex desno = matrix[loc.i][loc.j + 1];
                       if (desno.neighbours[2] == 0 || matrix[loc.i][loc.j].neighbours[3] == 0)
                       {
                           character.changeLocation(new Vertex(loc.i, loc.j + 1));
                           Invalidate();
                       }
                   }
                   checkifkraj();
                   checkifasset();
                   //check na desno, ako e pat odi

                   return true;
               }
               else return false;
           }
           else if (keyData == Keys.Up || keyData == Keys.W)
           {
               if (!paused && !between_level)
               {
                   Vertex loc = character.getLocation();
                   if (loc.i - 1 >= 0)
                   {
                       Vertex gore = matrix[loc.i - 1][loc.j];
                       if (gore.neighbours[1] == 0 || matrix[loc.i][loc.j].neighbours[0] == 0)
                       {
                           character.changeLocation(new Vertex(loc.i - 1, loc.j));
                           Invalidate();
                       }
                   }
                   checkifkraj();
                   checkifasset();
                   //check gore, ako e pat odi

                   return true;
               }
               else return false;
           }
           else if (keyData == Keys.Down || keyData == Keys.S)
           {
               if (!paused && !between_level)
               {
                   Vertex loc = character.getLocation();
                   if (loc.i + 1 < height)
                   {
                       Vertex dole = matrix[loc.i + 1][loc.j];
                       if (dole.neighbours[0] == 0 || matrix[loc.i][loc.j].neighbours[1] == 0)
                       {
                           character.changeLocation(new Vertex(loc.i + 1, loc.j));
                           Invalidate();
                       }
                   }
                   checkifkraj();
                   checkifasset();
                   //check dole, ako e pat odi

                   return true;
               }
               else return false;
           }
           else
               return base.ProcessDialogKey(keyData);
       }

       
       private void timer_Tick(object sender, EventArgs e)
       {
           timepassed++;
           if (timepassed == time)
           {
               timer.Stop();
               character.lives -= 1;  updategraphics();
               if (character.lives == 0)
               {
                   //YOU LOST GAME OVER
                   MessageBox.Show("Game over!"); 
                   timer.Stop();
                   this.Close();
               }
               else {
                   maze_assets.Clear();
                   setUpLevel();
                   character.changeLocation(matrix[0][0]);
                }
           }
           else {
               time_left.Text = String.Format("{0}:00", time-timepassed);
               progressBar1.Value = 100*(time - timepassed)/time;
           }
           
       }

       private void updategraphics() { 
        // pomini po assets, postavi assets i postavi lives

           if(character.name=="Varda"){characterpic.Image = The_Valar_Quest.Properties.Resources.Varda1;}
           else characterpic.Image = The_Valar_Quest.Properties.Resources.manwe5;

           if (character.lives == 1) { life1.Image = The_Valar_Quest.Properties.Resources.heart; life2.Visible= life3.Visible= false; }
           else if (character.lives == 2) { life1.Image = life2.Image = The_Valar_Quest.Properties.Resources.heart; life2.Visible = true; life3.Visible = false; }
           else { life1.Image = life2.Image = life3.Image = The_Valar_Quest.Properties.Resources.heart; life2.Visible = true; life3.Visible = true; }

           for (int i = 0; i < assets.Count; i++) {
               if (i == 0) { asset1.Image = getImage(assets.ElementAt(0)); }
               if (i == 1) { asset2.Image = getImage(assets.ElementAt(1)); }
               if (i == 2) { asset3.Image = getImage(assets.ElementAt(2)); }
               if (i == 3) { asset4.Image = getImage(assets.ElementAt(3)); }
            }
           switch (assets.Count) {
               case 0: asset1.Image = asset2.Image = asset3.Image = asset4.Image = null; break;
               case 1: asset2.Image = asset3.Image = asset4.Image = null; break;
               case 2: asset3.Image = asset4.Image = null; break;
               case 3: asset4.Image = null; break;
       }
           
       }
       public Image getImage( Asset a) {
           if (a.t_asset == type_of_asset.EXTRA_TIME)
           {
               ExtraTime et = (ExtraTime)a;
               if (et.seconds == 5) return The_Valar_Quest.Properties.Resources.petsec;
               else return The_Valar_Quest.Properties.Resources.desetsec;
           }
           if (a.t_asset == type_of_asset.FREEZE_TIME) {
               return The_Valar_Quest.Properties.Resources.FreezeTime;
           }
           if (a.t_asset == type_of_asset.SLOWDOWN_TIME) {
               return The_Valar_Quest.Properties.Resources.slow_down_time_assets;
           }
           return null;
       }
       private void button1_Click(object sender, EventArgs e)
       {
           //pause clicked
           if (button1.Text == "Pause")
           {
               timer.Stop();
               paused = true;
               Invalidate();
               button1.Text = "Resume";
           }
           else {
               timer.Start();
               paused = false;
               Invalidate();
               button1.Text = "Pause";
           }
           
       }

       private void useAsset(Asset a, int s) {
           
           if (a.t_asset == type_of_asset.EXTRA_TIME) {
               time += s + 1; assetInUse.Visible = false; use = false;
               assets.Remove(asset_in_use); updategraphics();
           }
           if (a.t_asset == type_of_asset.FREEZE_TIME) {
               timer1.Start(); timer.Stop(); 
           }
           if (a.t_asset == type_of_asset.SLOWDOWN_TIME) {
               timer1.Start(); timer.Interval = 2000; 
           }
       }

       private void timer1_Tick(object sender, EventArgs e)
       {
           if (asset_in_use.t_asset == type_of_asset.FREEZE_TIME) {
               if (time_passed_asset < 4){ 
                   time_passed_asset += 1; 
               }
               else {
                   timer1.Stop();
                   timer.Start();
                   time_passed_asset = 0;
                   assetInUse.Visible = false; use = false;
                   assets.Remove(asset_in_use); updategraphics();

               }
           }
           if (asset_in_use.t_asset == type_of_asset.SLOWDOWN_TIME) {
               if (time_passed_asset < 6)
               {
                   time_passed_asset += 1;
               }
               else {
                   timer1.Stop();
                   timer.Interval= 1000;
                   time_passed_asset = 0;
                   assetInUse.Visible = false;
                   use = false;
                   assets.Remove(asset_in_use); updategraphics();
               }
           }
       }  

       private void asset1_Click(object sender, EventArgs e)
       {
           

               if (assets.Count >= 1 && !use && !between_level)
               {
                   bool b = false;
                   if (!b && assets.ElementAt(0).t_asset == type_of_asset.EXTRA_TIME)
                   {
                       ExtraTime et = (ExtraTime)assets.ElementAt(0);
                       asset_in_use = et;
                       if (et.seconds == 5) { assetInUse.Image = The_Valar_Quest.Properties.Resources.petsec; }
                       else { assetInUse.Image = The_Valar_Quest.Properties.Resources.desetsec; }
                       assetInUse.Visible = true;
                       time_asset = et.seconds;
                       use = true; useAsset(assets.ElementAt(0), time_asset); b = true;
                   }
                   if (!b && assets.Count>0 && assets.ElementAt(0).t_asset == type_of_asset.FREEZE_TIME)
                   {
                       FreezeTime ft = (FreezeTime)assets.ElementAt(0);
                       asset_in_use = ft;
                       assetInUse.Image = The_Valar_Quest.Properties.Resources.FreezeTime;
                       assetInUse.Visible = true;
                       time_asset = ft.interval;
                       use = true; useAsset(assets.ElementAt(0), time_asset); b = true;
                   }
                   if (!b && assets.Count > 0 &&  assets.ElementAt(0).t_asset == type_of_asset.SLOWDOWN_TIME)
                   {
                       SlowdownTime slt = (SlowdownTime)assets.ElementAt(0);
                       asset_in_use = slt;
                       assetInUse.Image = The_Valar_Quest.Properties.Resources.slow_down_time_assets;
                       assetInUse.Visible = true;
                       time_asset = slt.seconds;
                       use = true; useAsset(assets.ElementAt(0), time_asset); b = true;
                   }
               }
       }

       private void asset2_Click(object sender, EventArgs e)
       {
           if (assets.Count>=2 && !use && !between_level)
           {
             
               bool b = false;
             
                   if (!b && assets.Count > 0 && assets.ElementAt(1).t_asset == type_of_asset.EXTRA_TIME)
                   {
                       ExtraTime et = (ExtraTime)assets.ElementAt(1);
                       asset_in_use = et;
                       if (et.seconds == 5) { assetInUse.Image = The_Valar_Quest.Properties.Resources.petsec; }
                       else { assetInUse.Image = The_Valar_Quest.Properties.Resources.desetsec; }
                       assetInUse.Visible = true;
                       time_asset = et.seconds;
                       use = true; useAsset(assets.ElementAt(1), time_asset); b = true;
                   }
                   
                   if (!b &&  assets.Count > 0 && assets.ElementAt(1).t_asset == type_of_asset.FREEZE_TIME)
                   {
                       FreezeTime ft = (FreezeTime)assets.ElementAt(1);
                       asset_in_use = ft;
                       assetInUse.Image = The_Valar_Quest.Properties.Resources.FreezeTime;
                       assetInUse.Visible = true;
                       time_asset = ft.interval;
                       use = true; useAsset(assets.ElementAt(1), time_asset); b = true;
                   }
                   
                   if (!b && assets.Count > 0 && assets.ElementAt(1).t_asset == type_of_asset.SLOWDOWN_TIME)
                   {
                       SlowdownTime slt = (SlowdownTime)assets.ElementAt(1);
                       asset_in_use = slt;
                       assetInUse.Image = The_Valar_Quest.Properties.Resources.slow_down_time_assets;
                       assetInUse.Visible = true;
                       time_asset = slt.seconds;
                       use = true; useAsset(assets.ElementAt(1), time_asset); b = true;
                   }
                   
               
           }
       }

       private void asset3_Click(object sender, EventArgs e)
       {
           bool b = false;
           if (assets.Count >= 3 && !use && !between_level)
           {
               
               if (!b && assets.Count > 0 && assets.ElementAt(2).t_asset == type_of_asset.EXTRA_TIME)
               {
                   ExtraTime et = (ExtraTime)assets.ElementAt(2);
                   asset_in_use = et;
                   if (et.seconds == 5) { assetInUse.Image = The_Valar_Quest.Properties.Resources.petsec; }
                   else { assetInUse.Image = The_Valar_Quest.Properties.Resources.desetsec; }
                   assetInUse.Visible = true;
                   time_asset = et.seconds;
                   use = true; useAsset(assets.ElementAt(2), time_asset); b = true;
               }
               if (!b &&  assets.Count > 0 && assets.ElementAt(2).t_asset == type_of_asset.FREEZE_TIME)
               {
                   FreezeTime ft = (FreezeTime)assets.ElementAt(2);
                   asset_in_use = ft;
                   assetInUse.Image = The_Valar_Quest.Properties.Resources.FreezeTime;
                   assetInUse.Visible = true;
                   time_asset = ft.interval;
                   use = true; useAsset(assets.ElementAt(2), time_asset); b = true;
               }
               if (!b && assets.Count > 0 && assets.ElementAt(2).t_asset == type_of_asset.SLOWDOWN_TIME )
               {
                   SlowdownTime slt = (SlowdownTime)assets.ElementAt(2);
                   asset_in_use = slt;
                   assetInUse.Image = The_Valar_Quest.Properties.Resources.slow_down_time_assets;
                   assetInUse.Visible = true;
                   time_asset = slt.seconds;
                   use = true; useAsset(assets.ElementAt(2), time_asset); b = true;
               }
           }
       }

       private void asset4_Click(object sender, EventArgs e)
       {
           bool b = false;
           if (assets.Count >=4 && !use && !between_level)
           {
               
               if (!b && assets.Count > 0 && assets.ElementAt(3).t_asset == type_of_asset.EXTRA_TIME)
               {
                   ExtraTime et = (ExtraTime)assets.ElementAt(3);
                   asset_in_use = et;
                   if (et.seconds == 5) { assetInUse.Image = The_Valar_Quest.Properties.Resources.petsec; }
                   else { assetInUse.Image = The_Valar_Quest.Properties.Resources.desetsec; }
                   assetInUse.Visible = true;
                   time_asset = et.seconds;
                   use = true; useAsset(assets.ElementAt(3), time_asset);b=true;
               }
               if (!b && assets.Count > 0 && assets.ElementAt(3).t_asset == type_of_asset.FREEZE_TIME)
               {
                   FreezeTime ft = (FreezeTime)assets.ElementAt(3);
                   asset_in_use = ft;
                   assetInUse.Image = The_Valar_Quest.Properties.Resources.FreezeTime;
                   assetInUse.Visible = true;
                   time_asset = ft.interval;
                   use = true; useAsset(assets.ElementAt(3), time_asset);b= true;
               }
               if (!b && assets.Count > 0 && assets.ElementAt(3).t_asset == type_of_asset.SLOWDOWN_TIME)
               {
                   SlowdownTime slt = (SlowdownTime)assets.ElementAt(3);
                   asset_in_use = slt;
                   assetInUse.Image = The_Valar_Quest.Properties.Resources.slow_down_time_assets;
                   assetInUse.Visible = true;
                   time_asset = slt.seconds;
                   use = true; useAsset(assets.ElementAt(3), time_asset); b= true;
               }
           }
       }
       

       private void Game_Paint(object sender, PaintEventArgs e)
       {
           if (!paused)
           {
               Graphics g = e.Graphics;
               g.Clear(Color.White);
               g.FillRectangle(new SolidBrush(Color.ForestGreen), new Rectangle(100, 200, 25 * width, 25 * height));
               for (int i = 0; i < matrix.Length; i++)
               {
                   for (int j = 0; j < matrix[i].Length; j++)
                   {
                       for (int k = 0; k < matrix[i][j].neighbours.Length; k++)
                       {
                           if (k == 0 && matrix[i][j].neighbours[0] > 0) if (matrix[i - 1][j].neighbours[1] != 0) g.DrawLine(new Pen(Color.Black), new Point(100+25 * j, 25 * i + 200), new Point(100+25 * j + 25, 25 * i + 200));
                           if (k == 1 && matrix[i][j].neighbours[1] > 0) if (matrix[i + 1][j].neighbours[0] != 0) g.DrawLine(new Pen(Color.Black), new Point(100+25 * j, 25 * i + 225), new Point(100+25 * j + 25, 25 * i + 225));
                           if (k == 2 && matrix[i][j].neighbours[2] > 0) if (matrix[i][j - 1].neighbours[3] != 0) g.DrawLine(new Pen(Color.Black), new Point(100+25 * j, 25 * i + 200), new Point(100+25 * j, 25 * i + 225));
                           if (k == 3 && matrix[i][j].neighbours[3] > 0) if (matrix[i][j + 1].neighbours[2] != 0) g.DrawLine(new Pen(Color.Black), new Point(100+25 * j + 25, 25 * i + 200), new Point(100+25 * j + 25, 25 * i + 225));
                       }
                   }

               }
               

               g.FillRectangle(new SolidBrush(Color.Red), end.j * 25 + 2+100, end.i * 25 + 200 + 2, 21, 21);

               for (int i = 0; i < maze_assets.Count; i++) {
                   g.DrawImage(getMazeAssetImage(maze_assets.ElementAt(i)),new Point(100+maze_assets.ElementAt(i).location.j*25,maze_assets.ElementAt(i).location.i*25+201));
               }
               character.draw(g);
           }
           else {
               Graphics g = e.Graphics;
               g.Clear(Color.Purple);
           }
       }

       private Image getMazeAssetImage(Asset a) {
           if (a.t_asset == type_of_asset.EXTRA_TIME)
           {
               ExtraTime et 
                   = (ExtraTime)a;
               if (et.seconds == 5) return The_Valar_Quest.Properties.Resources.petsec_maze;
               else return The_Valar_Quest.Properties.Resources.desetsec_maze;
           }
           if (a.t_asset == type_of_asset.FREEZE_TIME)
           {
               return The_Valar_Quest.Properties.Resources.FreezeTime_maze;
           }
           if (a.t_asset == type_of_asset.SLOWDOWN_TIME)
           {
               return The_Valar_Quest.Properties.Resources.slowing_time_maze;
           }
           if (a.t_asset == type_of_asset.LIFE) {
               return The_Valar_Quest.Properties.Resources.heart_maze;
           }
           return null;
       }

       private void button3_Click(object sender, EventArgs e)
       {
           setUpLevel();
           button3.Enabled = false; between_level = false;
       }

       private void button2_Click(object sender, EventArgs e)
       {
           timer.Stop();
           this.Visible = false;
       }
       public void Start() {
           timer.Start();
       }

    }


    public abstract class Asset{
        public string name { get; set; }
        public type_of_challenge type { get; set; }
        public type_of_asset t_asset { get; set; }
        public Vertex location { get; set; }
        public bool challenge(){
             Challenge challenge = new Challenge(type);
            if (challenge.ShowDialog() == DialogResult.OK) { return true; }
            else return false;
        }
}
    public class ExtraTime: Asset {
        public int seconds { get; set; }
        public int penalty { get; set; }

        public ExtraTime(int sec) {
            if (sec == 5) { seconds = sec; penalty = 3; name = "Extra 5s"; type = type_of_challenge.EASY; t_asset = type_of_asset.EXTRA_TIME; }
            else
            {
                seconds = 10; penalty = 5; type = type_of_challenge.MEDUM_HARD;
            }
        }
            
    }
    public class SlowdownTime : Asset {
        public int seconds = 6;
        

        public SlowdownTime() {
            this.name = "Slow down time";
            this.type = type_of_challenge.MEDUM_HARD;
            this.t_asset = type_of_asset.SLOWDOWN_TIME;
        }
    }
    
    public class FreezeTime:Asset{
        public int interval= 500;
        public FreezeTime(){
            this.name = "Freeze time";
            this.type = type_of_challenge.HARD;
            this.t_asset = type_of_asset.FREEZE_TIME;
        }
    }
    public class Life : Asset { 
        public Life(){
            name = "LIFE";
            type= type_of_challenge.EXTRA_HARD;
            this.t_asset = type_of_asset.LIFE;
        }
    }

    public class Character
    {
        public string name { get; set; }
        public int lives { get; set; }
        public const int maxlives = 3;
        private Vertex ch_loc;

        public Character(string name, Vertex start)
        {
            this.name = name;
            lives = 3;
            ch_loc =start ;
        }

        public void changeLocation(Vertex p){ch_loc= p;}
        public Vertex getLocation() { return ch_loc; }
        public void draw(Graphics g)
        {
            g.DrawImage(The_Valar_Quest.Properties.Resources.pin_newpin, new Point(100+ ch_loc.j*25+1, ch_loc.i*25+201));

        }
    }
    public class Edge { 
        public Vertex poc_teme;
        public Vertex kr_teme;
        public int tezina;

        public Edge(Vertex poc_teme, Vertex kr_teme, int tezina){
            this.poc_teme=poc_teme;
            this.kr_teme=kr_teme;
            this.tezina=tezina;
        }
    }
    public class Vertex {
        public int i, j;
        public int [] neighbours;

        public Vertex(int i, int j) { this.i = i; this.j = j;  neighbours = new int[4]; }

    }
}
