using System;
using System.IO;
using System.Diagnostics;

namespace Assignment1
{


    public class DirWalker
    {
        int total_rows = 0;
        int skipped_counter = 0;
        int good_rows = 0;

        public void walk(String path)
        {
            //int good_rows = 0;

            string[] list = Directory.GetDirectories(path);
           


            if (list == null) return;

            foreach (string dirpath in list)
            // foreach (String f : list)
            {

                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    //Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {

                //Console.WriteLine("File:" + filepath);

                string line;
                int good_rows = 0;
                int bad_rows = 0;

                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);
                    //int flag = 0; //row is good
                    // total_rows++;
                    good_rows++;
                    string[] words = line.Split(',');
                    int flag = 0;

                    foreach (var word in words)
                    {
                        //System.Console.WriteLine($"<{word}>");
                        

                        if (string.IsNullOrEmpty(word))
                        {
                            //skipped_counter++;
                            bad_rows++;
                            flag = 1;
                            break;
                        }
                       

                    }
                     if(flag == 1)
                    {
                        continue;

                    }

                    else
                    {
                        System.IO.File.AppendAllText(@"C:\Users\raghav\Documents\GitHub\MCDA5510_Assignments\Assignment1\Assignment1\Output.csv", line + "\n");
                    }
                }

                this.skipped_counter += bad_rows;
                this.good_rows = this.good_rows + (good_rows - bad_rows);
                file.Close();


            }
            //System.Console.WriteLine(total_rows);
            //int good_rows = total_rows - skipped_counter;
            
        }




               public static void Main(String[] args)
                {
            
                     // int total_rows = 0;
                     // int skipped_counter = 0;
                      
                      Stopwatch stopwatch = Stopwatch.StartNew();
                      DirWalker fw = new DirWalker();
                      fw.walk(@"C:\Users\raghav\Documents\GitHub\MCDA5510_Assignments\Assignment1\Assignment1\Sample_Directory");
                      stopwatch.Stop();
                     // Console.WriteLine("Total Time in Milliseconds : " + stopwatch.ElapsedMilliseconds.ToString());
                      //good_rows = total_rows - skipped_counter;
                      //System.Console.WriteLine("Total good rows : " + good_rows);
                      //System.Console.WriteLine("Total bad rows : " + skipped_counter);
                      System.IO.File.AppendAllText(@"C:\Users\raghav\Documents\GitHub\MCDA5510_Assignments\Assignment1\Assignment1\Log.txt", "Total Time in Milliseconds : " + stopwatch.ElapsedMilliseconds.ToString() + "\n");
                      //System.Console.WriteLine("Total good rows : " + fw.good_rows);
                      //System.Console.WriteLine("Total bad rows : " + fw.skipped_counter);
                      System.IO.File.AppendAllText(@"C:\Users\raghav\Documents\GitHub\MCDA5510_Assignments\Assignment1\Assignment1\Log.txt", "Good rows: " + fw.good_rows + "\n");
                      System.IO.File.AppendAllText(@"C:\Users\raghav\Documents\GitHub\MCDA5510_Assignments\Assignment1\Assignment1\Log.txt", "Bad Rows: " + fw.skipped_counter + "\n");



        }

    }


}
