using Xunit;
using blogapp.Controllers;
using blogapp.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using blogapp.Data;

namespace blogapp.tests;

public class PostControllerTests
{
    private readonly Mock<IPostRepository> _repo;
    private readonly PostController _controller;

    public PostControllerTests()
    {
        _repo = new Mock<IPostRepository>();
        _controller = new PostController(_repo.Object);
    }

    [Fact]
    public void ReturnViewFromPostIndex()
    {
        var result = _controller.Index();
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void ReturnModelWith2PostsWhenIndexCalled()
    {
        _repo.Setup(r => r.GetAll())
            .Returns(new List<Post>() { new Post(), new Post() });

        var result = _controller.Index();
        var viewResult = Assert.IsType<ViewResult>(result);

        var model = Assert.IsType<List<Post>>(viewResult.Model);

        Assert.Equal(model.Count, 2);
    }
}