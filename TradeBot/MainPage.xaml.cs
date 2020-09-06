using System;
using System.ComponentModel;
using Xamarin.Forms;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace TradeBot
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Analytics analytics = new Analytics();
            analytics = JsonConvert.DeserializeObject<Analytics>(analytics.Content);
            label1.Text = analytics.ProfProb;
            label2.Text = "Average Profit: " + analytics.Profits;

            Portfolio portfolio = new Portfolio();
            portfolio = JsonConvert.DeserializeObject<Portfolio>(portfolio.Content);

            List<string> TickerList = portfolio.TickerList.ToList();
            TickerListView.ItemsSource = TickerList;

            ListHeader.Text = "Portfolio Size: " + TickerList.Count;
        }

        void Analytics_Clicked(System.Object sender, System.EventArgs e)
        {
            Analytics analytics = new Analytics();
            analytics = JsonConvert.DeserializeObject<Analytics>(analytics.Content);
            label1.Text = analytics.ProfProb;
            label2.Text = "Average Profit: " + analytics.Profits;

            Portfolio portfolio = new Portfolio();
            portfolio = JsonConvert.DeserializeObject<Portfolio>(portfolio.Content);

            List<string> TickerList = portfolio.TickerList.ToList();
            TickerListView.ItemsSource = TickerList;

            ListHeader.Text = "Portfolio Size: " + TickerList.Count;
        }

    }

    class Analytics
    {
        public string ProfProb { get; set; }
        public string Profits { get; set; }
        public string Content;

        public Analytics()
        {
            RestClient client = new RestClient("http://24.107.73.103:8000/analytics");
            var request = new RestRequest(Method.GET);
            Content = client.Execute(request).Content;
        }
    }

    class Portfolio
    {
        public string[] TickerList { get; set; }
        public string Content;

        public Portfolio()
        {
            RestClient client = new RestClient("http://24.107.73.103:8000/portfolio");
            var request = new RestRequest(Method.GET);
            Content = client.Execute(request).Content;
        }
    }
}
