using System;
using System.Collections.Generic;
#region Video and Comment Classes
namespace YouTubeVideoTracker
{
        public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        private List<Comment> comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }

    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }
#endregion
#region Main Program
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("Protogen Chronicals Trailer", "Dr. Hare Studios", 75);
            video1.AddComment(new Comment("Alice", "*sniff* ... *cough* ... *sniff*"));
            video1.AddComment(new Comment("Bob_TheUnmoving", "The graphics look way better than I thought they were going to be."));
            video1.AddComment(new Comment("CharlieBarly", "I can't wait to play this game!"));
            videos.Add(video1);

            Video video2 = new Video("DevLog 0", "Dr. Hare Studios", 900);
            video2.AddComment(new Comment("DanaTheExplorer", "Def gunna pre-order fr fr!"));
            video2.AddComment(new Comment("Eccles_justin_the_hole_digger", "Can you add a hole digging mechanic?"));
            video2.AddComment(new Comment("Lank", "Exciting."));
            videos.Add(video2);

            Video video3 = new Video("DevLog 01", "Dr. Hare Studios", 1200);
            video3.AddComment(new Comment("Gracius_Grace", "Your characters are so beautiful!"));
            video3.AddComment(new Comment("HankLeTank093", "Having renditions really helped me picture the idea in my mind."));
            video3.AddComment(new Comment("09PoisonIvy90", "What game engine are you going to use?"));
            videos.Add(video3);

            Video video4 = new Video("DevLog 02", "Dr. Hare Studios", 1600);
            video4.AddComment(new Comment("Chathanyell0984", "bro u suck."));
            video4.AddComment(new Comment("KarKaroneeightyfour", "Some advice might be to seperate the difficulty class from the charicter creation."));
            video4.AddComment(new Comment("LeonTheStarry", "Impressive, I might do this for my own game."));
            videos.Add(video4);

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
#endregion