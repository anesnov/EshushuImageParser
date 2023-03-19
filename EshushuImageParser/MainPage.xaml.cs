namespace EshushuImageParser;
using HtmlAgilityPack;
using System.Net;

public partial class MainPage : ContentPage
{
	string path = "Q:\\pikchi\\Eshushu";


    public MainPage()
	{
		InitializeComponent();
	}

	private void Govno(object sender, EventArgs e)
	{
        WebClient webClient = new WebClient();        

        HtmlWeb web = new HtmlWeb();

        int page = 1;
        int count = 0;

        while (true)
        {
            var html = $"https://e-shuushuu.net/search/results/?page={page}&tags=75954";
            var htmlDoc = web.Load(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div/a[contains(@class, 'thumb_image')]");

            if (nodes == null)
                break;

            foreach (var node in nodes)
            {
                var image = node.Attributes["href"].Value;
                webClient.DownloadFile("https://e-shuushuu.net" + image, path + image.Substring(7));

                //TestImage.Source = ImageSource.FromUri(new Uri("https://e-shuushuu.net" + image));
            }

            count += nodes.Count();
            page++;
        }

        Liba.Text = "Всего скачано: " + count;
    }

	private void ImageCounter(object sender, EventArgs e)
	{
		int page = 1;
		int count = 0;        
        HtmlWeb web = new HtmlWeb();

        while (true) 
		{
            var html = $"https://e-shuushuu.net/search/results/?page={page}&tags=75954";
            var htmlDoc = web.Load(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div/a[contains(@class, 'thumb_image')]");
            if (nodes == null)
                break;
            count += nodes.Count();
            page++;
        }

        Counted.Text = "Total images: " + count;
    }
}

