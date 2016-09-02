﻿using BLL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace BLL.Servises
{
    public class PostService : IPostService
    {
        private IUnitOfWork _uow;
        private IUserService _userService;

        public PostService(IUnitOfWork uow, IUserService userService)
        {
            _uow = uow;
            _userService = userService;
        }

        public async Task CreatePost(Post post)
        {
            _uow.Posts.Create(post);
            await _uow.SaveAsync();
        }

        public Task DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int postId)
        {
            var post = _uow.Posts.GetAll()
                .Where(p => p.Id == postId)
                .FirstOrDefault();

            return post;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _uow.Posts.GetAll().ToArray();
        }

        public IEnumerable<Post> GetPostsFromCategory(int categoryId)
        {
            var posts = from p in _uow.Posts.GetAll()
                        where p.CategoryId == categoryId
                        select p;

            return posts;
        }

        public IEnumerable<Post> GetUserPosts(string userId)
        {
            var posts = from p in _uow.Posts.GetAll()
                        where p.UserId == userId
                        select p;

            return posts.ToArray();
        }

        public async Task PutLike(int id)
        {
            var post = GetPostById(id);
            post.Likes++;
            _uow.Posts.Update(post);
            await _uow.SaveAsync();
        }

        public Task UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}