## The Valar Quest ##

**The Valar Quest** is a brain teaser type of game which requires you to find your way around in a randomly generated maze before the time is up. The assets are the items you have the chance to win by answering a certain challenge (the time to find the way is stopped). List of assets (maximum four):

- Extra Time - Adds additional 5 or 10 seconds, with a penalty of 3 and 5 seconds correspondingly
- Slow down Time - Slows downs time for 6 seconds, with a penalty of 3 seconds
- Freeze Time- Freezes time for 4 seconds, with a penalty of 3 seconds
- Life- One more life , no penalty 

Depending on the character you choose there are some assets you automatically acquire.  

The challenges have 4 different levels of difficulty depending on the value of the asset in question:

- Easy- 30 seconds to solve
- Medium-hard- 40 seconds to solve
- Hard - 50 seconds to solve
- Extra hard- 60 seconds to solve

If you answer correctly the asset is added to the list of assets you can use.
Otherwise you receive a penalty by pressing the I give up button (if you want to know the correct answer) or by not answering in time, or by selecting the wrong answer. 

There are 15 levels you have to pass in order to win the game. You have 3 lives. If the time is up before you get to the marked destination you lose a life. Also if you pause the game the maze disappears. 

The characters you can choose from are the leaders of the group of Valar (high elves , half gods -LOTR) that has to fight the evil of Melcor, their ultimate enemy. This game represents their trip to Valinor the city where they settle and build their home. 

### Implementation  ###

The main form that contains all the other forms is the Main Menu form. It contains an instance of the Choose Character form which in turn contains an instance of the Game form instantiated depending on the character which is chosen.

![](http://farm8.staticflickr.com/7450/8806507403_c6f35c0cc1.jpg)

 This form contains an instance of the Character class, which contains information about the name of the character, the lives and the location of the character. The location is an instance of the Vertex class which contains information about the x and the y coordinate and a list of four numbers indicating whether there exists a neighbouring cell(1 - there exists , -1- doesn't exist):

- first element- up (the y or i coordinate)
- second element-down (the y or i coordinate)
- third element- left (the x or j coordinate)
- fourth element- right (the x or j coordinate)

The maze is represented by a matrix of 400 vertices with height=width=20. The matrix is initialized in the beginning of the Maze() function.

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
    
The starting vertex from which the maze is generated and the character is always set in the beginning is the top left vertex. The current block or vertex is set to the starting vertex. 

Another  auxiliary matrix with boolean values for each vertex of equal size is also initialized. The generation of the random maze is made by selecting  one side of the vertex on which there exists another vertex and setting the neighbouring value to 0 thereby creating a path between them. The maze value with the same coordinates as the current block is set to true. The process continues with the the new accessible vertex by choosing another vertex and so on until the current block has taken the value of all the vertices in the matrix. This is done by using a stack and pushing the current block in every iteration so that it is assured that whenever a dead end is encountered vertices are popped until a vertex which has a neighbouring vertex that hasn't been selected (or marked) is found and the that vertex is set as the current value. 

    while (st.Count!=1) {


             st.Push(start);

			// the condition makes sure that the vertex has a non marked neighbour or a neighbour that doesnt have a true value in the maze list
              if (this.hasNotMarkedNeighbors(matrix[currentBlock.i][currentBlock.j].neighbours, currentBlock.i, currentBlock.j))
              {
                  // select random direction od neighbours

                  int rand = generateRandomDirection(currentBlock);
                  bool falseBlockFound = false;

                  while (!falseBlockFound)
                  {
				
					//check if the vertex has a neighbour above with a wall between them or 1 as the first element in the neighbour list 
                      if (rand == 0)
                      {
                          if (currentBlock.i - 1 >= 0) { if (!maze[currentBlock.i - 1][currentBlock.j]) { break ; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }
					//check if the vertex has a neighbour below with a wall between them or 1 as the second element in the neighbour list 
                      if (rand == 1)
                      {
                          if (currentBlock.i + 1 < height) { if (!maze[currentBlock.i + 1][currentBlock.j]) { break; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }

					//check if the vertex has a neighbour on the left with a wall between them or 1 as the third element in the neighbour list 
                      if (rand == 2)
                      {
                          if (currentBlock.j - 1 >= 0) { if (!maze[currentBlock.i][currentBlock.j - 1]) { break; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }

					//check if the vertex has a neighbour on the right with a wall between	them or 1 as the fourth element in the neighbour list 
                      if (rand == 3)
                      {
                          if (currentBlock.j + 1 < width) { if (!maze[currentBlock.i][currentBlock.j + 1]) { break; } else { rand = generateRandomDirection(currentBlock); continue; } }
                      }

                  }
					
					
                      matrix[currentBlock.i][currentBlock.j].neighbours[rand] = 0;
                    maze[currentBlock.i][currentBlock.j] = true;
				

				// setting up the next currentBlock as the vertex which has been connected 
				with the currentBlock by asigning the value in the neighbours list =0
                  int pos1 = currentBlock.i; int pos2 = currentBlock.j;
                  switch (rand)
                  {
						//above vertex
                      case 0: currentBlock = matrix[pos1 - 1][pos2]; break;
						// below vertex
				      case 1: currentBlock = matrix[pos1 + 1][pos2]; break;
                      	// left vertex
					  case 2: currentBlock = matrix[pos1][pos2 - 1]; break;
                 		//right vertex
				      case 3: currentBlock = matrix[pos1][pos2 + 1]; break;
                  }
                  st.Push(currentBlock); stack_push++;
              }
              else {

				// in case there are no unmarked neighbours that can be selected
				// if it hasn t been marked, update maze with a true value and if there is a wall that can be destroyed destroy it and connect it
				//	without doing this some cell might have four walls around them which makes them completely inaccessible
                  if (maze[currentBlock.i][currentBlock.j] == false) {
                      maze[currentBlock.i][currentBlock.j] = true;
                      for (int i = 0; i < currentBlock.neighbours.Length; i++) {
                          if (currentBlock.neighbours[i] > 0) { currentBlock.neighbours[i] = 0; break; }
                      }
                  }
                  st.Pop();
                  for (int i = 0; i < st.Peek().neighbours.Length; i++) {
                     if (st.Peek().neighbours[i] == 0) { matrix[currentBlock.i][currentBlock.j].neighbours[i] = 0; 
                         break; }
                  }
			// currentblock takes up the value of the first nonmarked vertex that can be found backtracking, going through the vertices in the stack while the currentblock is null
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

The generation of the maze is based on the Prim's algorithm with a few adjustments in order to create a maze where it is not always possible to start from any point in the maze and be able to get to every other point.

After the maze is created another function FindPath() is called to check if there exists at least one path with length of 20 + level *3. This function serves as measure to control the difficulty of finding the right path although sometimes there might exist a shorter path to the destination. This function returns the destination vertex if there exists such a path starting from the top left vertex to the farthest point that can be reached without forming a cycle and going through the vertices by following the trail of zeros starting from the starting vertex.Otherwise null value is returned and Maze() and FindPath() are called as many times as needed to generate a maze that contains at least one path with a satisfactory length. This is not only algorithm that can be used to find such a path. It can also be done by choosing an alternative path if such exists (if the vertex is connected with two or more neighbours). 

     public Vertex findPath() {
           int min_l= 20+level *3;

		//auxiliary matrix to check if a cycle is formed
           bool[][] visited = new bool[height][];
           for (int i = 0; i < height; i++) {
               visited[i] = new bool [width];
           }
           for (int i = 0; i < height; i++) {
               for (int j = 0; j < width; j++) {
                   visited[i][j] = false;
               }
           }
			//the path starting from the starting point
               path = new List<Vertex>();
           Vertex currentBlock = start;
           int dolz = 0; Vertex lastBlock=start;
           
           while (true) {
               path.Add(currentBlock);
               visited[currentBlock.i][currentBlock.j] = true;
               int zero_pos = -1;
			// find the zero in the least or the path
               for (int i = 0; i < currentBlock.neighbours.Length; i++) {
                   if (currentBlock.neighbours[i] == 0) {
                       zero_pos = i;
                   }
               }
               dolz++;
               if (zero_pos == 0) {
					// above -first neighbour
                   if (visited[currentBlock.i - 1][currentBlock.j]) { lastBlock = currentBlock;  break; }
                   else {
                       currentBlock = matrix[currentBlock.i - 1][currentBlock.j];
                   }
               }
               if (zero_pos == 1)
               {
					// above -second neighbour
                   if (visited[currentBlock.i + 1][currentBlock.j]) { lastBlock = currentBlock; break; }
                   else
                   {
                       currentBlock = matrix[currentBlock.i + 1][currentBlock.j];
                   }
               }
               if (zero_pos == 2)
               {
					// left- third neighbour
                   if (visited[currentBlock.i][currentBlock.j-1]) { lastBlock = currentBlock; break; }
                   else
                   {
                       currentBlock = matrix[currentBlock.i ][currentBlock.j-1];
                   }
               }
               if (zero_pos == 3)
               {
					// right -fourth neighbour
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

All the assets are derived from the Assets abstract class. This class contains the location in the maze and is randomly initialized, the name, the type of the asset, and the type of the challenge associated with the asset.
Each asset in the list corresponds to the asset list shown in the top right corner  from left to right (from 0 to 3). In the click event of the picture box controls a function is called to check what kind of asset is clicked and a second timer is activated in case of freeze time, the interval of the first timer is changed in case of slow down time or extra time is added.   

![](http://farm8.staticflickr.com/7337/8808563313_57dc90c189_n.jpg)

The question class is a class which contains information about the difficulty, the question, the answers and the correct answer. The template class is derived from the question class in order to be able to generate the same question with different numbers and corresponding different answers so two additional int variables are added and the % sign is replaced with this numbers by calling the GenerateQuestion () function. 

![](http://farm6.staticflickr.com/5453/8819267924_5f9724473f_m.jpg)
### How to play ###

Your character is represented by the pin icon that always appears on the top left corner of the maze. You can move the character by using the following keys on your keypad:

![](http://farm8.staticflickr.com/7448/8806085205_41d785660e_m.jpg)


![](http://farm4.staticflickr.com/3829/8816670498_928f924893_m.jpg)

If you want to use some of the assets you posses you have to select the asset you want to use by left-clicking its icon on the top right side list. 

If you choose to pause the game the time is stopped and the maze disappears. 

Concerning the challenge if you click I give up the correct answer is shown but you still receive the penalty associated with the asset you are trying to acquire. 

Click Next Level to go to next level.

