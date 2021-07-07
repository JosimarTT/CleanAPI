﻿using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Repositories
{
    public class PostRepository:IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var post = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Description {x}",
                Date = DateTime.Now,
                Image = $"https://misapis.com/{x}",
                UserId = x * 2
            });
            await Task.Delay(5);
            return post;
        }
    }
}