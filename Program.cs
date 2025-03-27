using System.Linq;
using System.Net.Http.Headers;
class SayaTubeUser
{
    private int id;
    private string Username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string Username)
    {
        Random random = new Random();
        this.id = random.Next(10000, 999999);
        this.Username = Username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        return uploadedVideos.Sum(video => video.playCount);
    }

    public void AddVideo(SayaTubeVideo video)
    {
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount()
    {
        Console.WriteLine($"User: {Username}");
        for (int i = 1; i <uploadedVideos.Count; i++)
        {
            Console.WriteLine($"Video{i + 1} judul: {uploadedVideos[i].ToString}");
        }
    }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    public int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Judul tidak boleh kosong");
        }

        if(title.Length > 200)
        {
            throw new ArgumentException("Judul tdak boleh dari 200 karakter");
        }
        Random random = new Random();
        this.id = random.Next(10000, 999999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Play count tidak boleh negatif");
        }

        if (count > 25000000)
        {
            throw new ArgumentException("Play count tidak boleh lebih dari 25 juta");
        }

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            throw new OverflowException("Jumlah ccount tidak boleh lebih dari batas maksimum");
        }
        playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class Program
{
    public void Main()
    {
        SayaTubeUser user = new SayaTubeUser("Zaky");

        SayaTubeVideo video1 = new SayaTubeVideo("Review Ice Age oleh Zaky");
        SayaTubeVideo video2 = new SayaTubeVideo("Review Pamali 1 oleh Zaky");
        SayaTubeVideo video3 = new SayaTubeVideo("Review Pamali 2 oleh Zaky");
        SayaTubeVideo video4 = new SayaTubeVideo("Review KKN Desa Penari oleh Zaky");
        SayaTubeVideo video5 = new SayaTubeVideo("Review Makmum oleh Zaky");
        SayaTubeVideo video6 = new SayaTubeVideo("Review Fast Furious 6 oleh Zaky");
        SayaTubeVideo video7 = new SayaTubeVideo("Review Fast Furious 7 oleh Zaky");
        SayaTubeVideo video8 = new SayaTubeVideo("Review Fast Furious 8 oleh Zaky");
        SayaTubeVideo video9 = new SayaTubeVideo("Review Fast Furious 9 oleh Zaky");
        SayaTubeVideo video10 = new SayaTubeVideo("Review Fast Furious 10 oleh Zaky");

        user.AddVideo(video1);
        user.AddVideo(video2);
        user.AddVideo(video3);
        user.AddVideo(video4);
        user.AddVideo(video5);
        user.AddVideo(video6);
        user.AddVideo(video7);
        user.AddVideo(video8);
        user.AddVideo(video9);
        user.AddVideo(video10);

        video1.IncreasePlayCount(10);
        video1.IncreasePlayCount(5);
        video1.IncreasePlayCount(20);
        video1.IncreasePlayCount(15);
        video1.IncreasePlayCount(30);
        video1.IncreasePlayCount(25);
        video1.IncreasePlayCount(40);
        video1.IncreasePlayCount(35);
        video1.IncreasePlayCount(50);
        video1.IncreasePlayCount(45);

        user.PrintAllVideoPlayCount();

    }
}