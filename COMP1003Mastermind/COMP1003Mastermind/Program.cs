using System;

namespace COMP1003Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
          int N = 0;
          int M = 0;
          bool guess = false;
        
          
          while(true){
          Console.Write("Enter how many positions you would like");
          if(int.TryParse(Console.ReadLine(),out N))
          {
            
              break;
          }
          else  Console.WriteLine("Please only enter numbers!");
          
          }
          while(true){
               Console.Write("Enter how many numbers you would like to choose from");
                if(int.TryParse(Console.ReadLine(),out M))
          {
            
              break;
          }
          else Console.WriteLine("Please only enter numbers!");
          

          }
         
         
          int[] secret = createNewArray(N,M);
          printArray(secret,N);
          while(!guess){
              int[] userGuess = getUserInput(N);
              guess = checkGuess(secret,userGuess,N);

            
          }
          




          

        
          
        }
        static int[] createNewArray(int N, int M){
            int[] array = new int[N];
            Random r = new Random();
            for (int i = 0; i < N; i++){
                array[i] = r.Next(1,M);
            }
            return array;
        }

        static void printArray(int[] array,int N){
            for(int i = 0; i < N; i++){
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }
        
        static int[] getUserInput(int N){
            int[] arr = new int[N];
            for(int i = 0; i < N; i++){
                Console.Write("Enter Guess " + (i+1) + " ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        static bool checkGuess(int[] secret, int[] userGuess,int N){
            
            int black = 0;
            int white = 0;
         
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
                                userGuess[j] = 0;
                            }
                        }
                    }




            }
            Console.Write("Number of Black Pegs: " + black + " ");
            Console.Write("Number of White Pegs: " + white + "\n");
            if(black == N){
                Console.WriteLine("Correct Game Over");
                return true;
            }
            
          Console.WriteLine("Incorrect,try again");
          return false;
        }
        
        }
    }

