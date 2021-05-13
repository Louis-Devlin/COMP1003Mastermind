using System;

namespace COMP1003Mastermind
{
    class Queue {
        //Defines a Queue data structure with jagged array for data store
        public int back = -1;
        public int[][] history = new int[50][]; 
        /*
         Having the history a fixed size creates an overhead in memory 
        but makes it unlikely to need to deal with removing elelemnts from the queue
        */
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Setup the game and  variables
          int N = 0;
          int M = 0;
          
       bool running = true;
       
        //Main Loop
          while(running)
          {
              setup(ref N, ref M);
              int[] secret = createNewArray(N,N);
              //printArray(secret,N);
              //The line commented out above prints the secret array and was used to test the program
              gameLoop(secret,N);
              running = replay();
          }
          
        }
        //Creates a random array for user to guess 
        static int[] createNewArray(int N, int M){
            int[] array = new int[N];
            Random r = new Random();
            for (int i = 0; i < N; i++){
                array[i] = r.Next(1,M+1);
            }
            return array;
        }

        //Prints out arrays to show the secret array (Testing Feature)
        static void printArray(int[] array,int N){
            for(int i = 0; i < N; i++){
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }
        //Takes in user input and places it into an array
        static int[] getUserInput(int N){
            int[] arr = new int[N];
            for(int i = 0; i < N; i++){
                Console.Write("Enter Guess " + (i+1) + " ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }
        //Adds the user input to the queue 
        static void addToQueue( ref Queue q, int[] array,int N){
            q.back += 1;
            q.history[q.back] = new int[N];
            for (int i=0; i<N;i++){
                
                q.history[q.back][i] = array[i];
            }

        }
        //Prints out queue
        static void printQueue(Queue q, int N){
            
            if(q.back == -1){
                
            }
            else{
               for (int i = 0; i <= q.back; i++)
                {
                    Console.Write("Guess " + (i + 1) + ": ");
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write(q.history[i][j]+" ");
                    }
                    Console.Write("\n");
                }
                
            }
        }
        //Checks the user guess and compares it with the secret answer
        static bool checkGuess(int[] secret, int[] userGuess,int N,  ref Queue q){
            int[] guessArray = cloneArray(userGuess,N);
            int black = 0;
            int white = 0;
            //Loops through array to get black peg 
            for(int i = 0; i<N; i++){
               
                    if (secret[i] == userGuess[i])
                    {
                        black++;
                    }
                    else
                    {
                        for(int j = 0; j < N; j++)
                        {
                            if(secret[i] == userGuess[j])
                            {
                                white++;
                                userGuess[j] = 0; //If white peg is found, mark the postion as 0 so it cant count for another number later in the array
                                break;
                                
                            }
                        }
                    }




            }
            Console.Write("Number of Black Pegs: " + black + " ");
            Console.Write("Number of White Pegs: " + white + "\n");
            if(black == N){
                
                Console.WriteLine("Correct Game Over");
                Console.WriteLine("GUESSES \n _________");
                addToQueue(ref q, guessArray, N);
                printQueue(q, N);
                return true;
            }
            
          Console.WriteLine("Incorrect,try again");
          addToQueue(ref q,guessArray,N);
          printQueue(q, N);
          return false;
        }


        //Creates a copy of an array as making a shallow copy means changes affect both
        static int[] cloneArray(int[] userGuess, int N)
        {
            int[] clone = new int[N];
            for(int i= 0; i<N; i++)
            {
                clone[i] = userGuess[i];
            }
            return clone;
        }

        //Setting up the game (Number of positions and numbers to chose from)
        static void setup(ref int N, ref int M)
        {
    while(true){
          Console.Write("Enter how many positions you would like: ");
          if(int.TryParse(Console.ReadLine(),out N))
          {
            
              break;
          }
          else 
          { 
              Console.WriteLine("Please only enter numbers!");
          }
          }
          while(true){
               Console.Write("Enter how many numbers you would like to choose from \n(Please enter a number between 1 and 9): ");
                if(int.TryParse(Console.ReadLine(),out M))
          {
              if(M>9){
                 Console.WriteLine("Please only enter a number between 1 and 9");
              }
              else 
              { 
                  break;
              }
            
              
          }
          else {
              Console.WriteLine("Please only enter numbers!");
          }

          }
          
        }
        // Game Loop
        static void gameLoop(int[] secret,int N){
            Queue queue = new Queue();
            bool guess = false;
             while(!guess){
              int[] userGuess = getUserInput(N);
              guess = checkGuess(secret,userGuess,N,ref queue);

            
          }
        }
        //Asks if user wants to replay
        static bool replay(){
            Console.WriteLine("Would you like to replay? Enter y/n: ");
          string uReplay = Console.ReadLine();
          if(uReplay == "y") {
              return true;
          }
          else {
              return false;
              }
        }
    }
    }

