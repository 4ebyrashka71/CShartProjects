using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        class Graph
        {
            private int V; // No. of vertices

            // Array of lists for
            // Adjacency List Representation
            private List<int>[] adj;

            // Constructor
            public Graph(int v)
            {
                V = v;
                adj = new List<int>[v];
                for (int i = 0; i < v; ++i)
                    adj[i] = new List<int>();
            }

            // Function to Add an edge into the graph
            void AddEdge(int v, int w)
            {
                adj[v].Add(w); // Add w to v's list.
            }

            // A function used by DFS
            void DFSUtil(int v, bool[] visited)
            {
                // Mark the current node as visited
                // and print it
                visited[v] = true;
                //Console.Write(v + " ");

                // Recur for all the vertices
                // adjacent to this vertex
                List<int> vList = adj[v];
                foreach (var n in vList)
                {
                    if (!visited[n])
                        DFSUtil(n, visited);
                }
            }

            // The function to do DFS traversal.
            // It uses recursive DFSUtil()
            bool DFS(int v, int sfind)
            {
                // Mark all the vertices as not visited
                // (set as false by default in c#)
                bool[] visited = new bool[sfind+1];

                // Call the recursive helper function
                // to print DFS traversal
                DFSUtil(v, visited);
                if (visited[sfind] == true)
                {
                    return true;
                }
                else return false;
            }


            public bool createGraph(int size, List<Tuple<int, int>> tuples)
            {
                Graph g = new Graph(size+1);
                foreach (var el in tuples)
                {
                    g.AddEdge(el.Item1, el.Item2);
                }
                if (g.DFS(0, size))
                {
                    return true;
                }
                else return false;
                
            }
        }
        public static List<string> foundWords = new List<string>();
        public int c;
        public string[] words;
        public int counter = 0;
        public bool flag = false;
        public string inputlb;
        /// <summary>
        /// Creates two listviews, sets the gridlines
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView2.View = View.Details;
            listView2.GridLines = true;
            inputlb = inputLabel.Text;
            findButton.Enabled = false;

        }

        /// <summary>
        /// Checks if it the first click on the button, if not -> clear everything and adds Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showButton_Click(object sender, EventArgs e)
        {
            try {
                if (flag == true)
                {
                    listView2.Clear();
                    listView1.Clear();
                    c = int.Parse(amountBox.Text);
                    words = new string[c];
                    counter = 0;
                    listView1.Columns.Add("Entered words", 570);

                }
                else
                {
                    c = int.Parse(amountBox.Text);
                    words = new string[c];
                    flag = true;
                    listView1.Columns.Add("Entered words", 570);
                }
            }
            catch { MessageBox.Show("Error!"); }
            inputLabel.Text = inputlb + Convert.ToString(counter + 1);
            findButton.Enabled = false;

        }

        /// <summary>
        /// This button read the text from input and sets it to the array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                string word = inputBox.Text;
                word = word.Replace(" ", "");
                inputLabel.Text = inputlb + Convert.ToString(counter+2);
                words[counter] = word;
                counter++;
                if(counter == words.Length)
                {
                    findButton.Enabled = true;
                }
                ListViewItem itm;
                itm = new ListViewItem(word);
                listView1.Items.Add(itm);
                inputBox.Clear();
                

            }
            catch { MessageBox.Show("Error!"); }
        }

        /// <summary>
        /// Creates a list for function IndexOf, adds all of the elements of array
        /// creates list of pair, finds indexes and adds them to the list
        /// after that we align graph, call function createGraph and use DFS
        /// in DFS we check if the size of the string was visited,
        /// if yes -> sets this word as found and add it to the foundList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findButton_Click(object sender, EventArgs e)
        {
            var listWords = new List<string>();
            for (int i = 0; i < words.Length; ++i)
            {
                listWords.Add(words[i]);
            }
            var data = new List<Tuple<int, int>>();
            int counterList = 1;
            //label2.Text = (words.Length - counterList).ToString();
            while (words.Length - counterList > 0)
            {
                data.Clear();
                int wordsSize = words.Length - counterList;
                int max = -1, min = 0x3f3f3f;
                //label2.Text = "sss ";
                for (int i = 0; i < wordsSize; ++i)
                {
                    int x = listWords[wordsSize].IndexOf(words[i]);
                    //Array.IndexOf(words)
                    if (x == -1) continue;
                    while(x != -1)
                    {
                        data.Add(new Tuple<int, int>(x, x + words[i].Length));
                        if (max < x + words[i].Length)
                        {
                            max = x + words[i].Length;
                        }
                        if (min > x)
                        {
                            min = x;
                        }
                        x = listWords[wordsSize].IndexOf(words[i], x + 1);
                    }

                }
                counterList++;
                if (min == 0 && max == words[wordsSize].Length)
                {
                    Graph g = new Graph(words[wordsSize].Length);

                    if (g.createGraph(words[wordsSize].Length, data))
                    {

                        foundWords.Add(words[wordsSize]);
                    }
                    
                    listView2.Clear();
                    listView2.Columns.Add("Found words", 570);
                    ListViewItem itm;
                    foreach (var wooord in foundWords)
                    {
                        itm = new ListViewItem(wooord);
                        listView2.Items.Add(itm);
                    }
                    
                }
            }
            foundWords.Clear();
        }
    }
}