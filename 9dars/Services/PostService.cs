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
        var post = new Post();
        foreach (var element in Posts)
        {
            if (post.ViewerNames.Count < element.ViewerNames.Count)
            {
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
        var post = new Post();
        foreach (var element in Posts)
        {
            if (post.Comments.Count < element.Comments.Count)
            {
                post = element;
            }
        }

        return post;
    }
    public List<Post> GetPostsByComment(string comment)
    {
        var sortedPosts = new List<Post>();
        foreach (var post in Posts)
        {
            var getComments = post.Comments;
            if (getComments.Contains(comment) is true)
            {
                sortedPosts.Add(post);
            }
        }

        return sortedPosts;
    }

    public bool AddCommentToPost(Guid postId, string comment)
    {
        var commentAdded = false;
        foreach (var post in Posts)
        {
            if (post.Id == postId)
            {
                post.Comments.Add(comment);
                commentAdded = true;
                break;
            }
        }

        return commentAdded;
    }

    public bool AddLikeToPost(Guid postId)
    {
        var postLiked = false;
        foreach (var post in Posts)
        {
            if (post.Id == postId)
            {
                post.QuantityLikes++;
                postLiked = true;
                break;
            }
        }

        return postLiked;
    }

    public bool AddViewerNameToPost(Guid postId, string viewerName)
    {
        var viewerNameAdded = false;
        foreach (var post in Posts)
        {
            if (post.Id == postId)
            {
                post.ViewerNames.Add(viewerName);
                viewerNameAdded = true;
                break;
            }
        }

        return viewerNameAdded;
    }
}
