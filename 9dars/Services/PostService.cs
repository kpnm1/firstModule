using _9dars.Models;

namespace _9dars.Services;

public class PostService
{
    private List<Post> Posts;
    public PostService()
    {
        Posts = new List<Post>();
    }

    public Post AddPost(Post post)
    {
        post.Id = Guid.NewGuid();
        Posts.Add(post);

        return post;
    }

    public bool DeletePost(Guid postId)
    {
        var contains = false;
        foreach (var post in Posts)
        {
            if (post.Id == postId)
            {
                contains = true;
                Posts.Remove(post);
                break;
            }
        }

        return contains;
    }

    public bool EditPost(Post post)
    {
        var edited = false;
        for (var i = 0; i < Posts.Count(); i++)
        {
            if (post.Id == Posts[i].Id)
            {
                edited = true;
                Posts[i] = post;
                break;
            }
        }

        return edited;
    }

    public List<Post> GetPosts()
    {
        return Posts;
    }

    public Post GetPost(Guid postId)
    {
        foreach (var post in Posts)
        {
            if (post.Id == postId)
            {
                return post;
            }
        }

        return null;
    }

    public Post GetMostViewedPost()
    {
        var mostViewedPost = Posts[0].ViewerNames.Count;
        var post = Posts[0];
        foreach (var element in Posts)
        {
            if (mostViewedPost < element.ViewerNames.Count)
            {
                mostViewedPost = element.ViewerNames.Count;
                post = element;
            }
        }

        return post;
    }

    public Post GetMostLikedPost()
    {
        var postLikesCount = Posts[0].QuantityLikes;
        var post = Posts[0];
        foreach (var element in Posts)
        {
            if (postLikesCount < element.QuantityLikes)
            {
                postLikesCount = element.QuantityLikes;
                post = element;
            }
        }

        return post;
    }

    public Post GetMostCommentedPost()
    {
        var postCommentsCount = Posts[0].Comments.Count;
        var post = Posts[0];
        foreach (var element in Posts)
        {
            if (postCommentsCount < element.Comments.Count)
            {
                postCommentsCount = element.Comments.Count;
                post = element;
            }
        }

        return post;
    }
    public List<Post> GetPostsByComment(string comment)
    {
        var sortedPosts = new List<Post>();
        for (var i = 0; i < Posts.Count(); i++)
        {
            for (var j = 0; j < Posts[i].Comments.Count(); j++)
            {
                var getComment = Posts[i].Comments[j];

                if (getComment == comment)
                {
                    sortedPosts.Add(Posts[i]);
                }
            }
        }

        return sortedPosts;
    }


}
