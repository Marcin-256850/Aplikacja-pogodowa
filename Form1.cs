using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string APIKey = "9de7947f3c0202dce3008b423a83170f";

        private async void button1_Click(object sender, EventArgs e)
        {
            var json = await downloadData();
            //textBox1.Text = json;
            WeatherInfo.root info = JsonSerializer.Deserialize<WeatherInfo.root>(json);
            pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + info.weather[0].icon + ".png";
            textBox7.Text = info.weather[0].description;
            textBox8.Text = (info.main.temp - 273.5).ToString("n0") + "°C";
            textBox9.Text = info.main.pressure + " hPa";
            textBox10.Text = info.wind.speed.ToString() + " m/s";
        }

        private async Task<string> downloadData() //funkcja asynchroniczna, wymaga zwrocenie obiektu typu task
        {
            string city = textBox_city.Text;
            HttpClient client = new HttpClient();
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&lang={2}", city, APIKey, "pl");
            string json = await client.GetStringAsync(url);
            return json;
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }




    //MOZNA ZROBIC SLOWNIK I DO NIEGO ZAPISYWAC POLA
}