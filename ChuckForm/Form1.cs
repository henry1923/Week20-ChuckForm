using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuckForm
{
    public partial class Form1 : Form
    {
        public static object JsonConvert { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jokebox.Text = GetJokes();
        }

        public static string GetJokes()
        {
            string url = "https://api.icndb.com/jokes/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Joke joke = JsonConvert.DeserializeObject<Joke>(response);
                
                Console.WriteLine(joke.value.joke);
                Console.WriteLine(response);

                return joke.value.joke;

            }
        }
    }
}
