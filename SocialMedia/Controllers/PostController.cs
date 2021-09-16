﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController( IPostRepository postRepository, IMapper mapper )
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() 
        {
            var posts = await _postRepository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new Response<IEnumerable<PostDto>>(postsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost( int id )
        {
            var post = await _postRepository.GetPost( id );
            var postDto = _mapper.Map<PostDto>(post);
            var response = new Response<PostDto>(postDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post( PostDto postDto )
        {
            
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.InsertPost( post );
            postDto = _mapper.Map<PostDto>(post);
            var response = new Response<PostDto>(postDto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            var result = await _postRepository.UpdatePost(post);
            var response = new Response<bool>( result );

            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            var result  = await _postRepository.DeletePost(post.PostId);
            var response = new Response<bool>( result );

            return Ok(result);
        }

    }
}
