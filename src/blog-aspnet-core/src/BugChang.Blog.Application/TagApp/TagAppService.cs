using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.TagApp
{
   public class TagAppService:ITagAppService
   {
       private readonly IPostRepository _postRepository;
       private readonly IMapper _mapper;

       public TagAppService(IPostRepository postRepository, IMapper mapper)
       {
           _postRepository = postRepository;
           _mapper = mapper;
       }

       public PageSearchOutput<PostPreviewDto> GetPosts(string tagName, PageSearchInput pageSearchInput)
       {
           PageSearchOutput<PostPreviewDto> pageSearchOutput = new PageSearchOutput<PostPreviewDto>(pageSearchInput);
           var queryable = _postRepository.GetQueryable(p => p.IsPublish && p.Tags.Contains(tagName),pageSearchInput,out int total);
            pageSearchOutput.Total = total;
           pageSearchOutput.Records = _mapper.ProjectTo<PostPreviewDto>(queryable);
           return pageSearchOutput;
         
       }

        public IEnumerable<string> GetTags()
        {
            var list= _postRepository.GetQueryable(p=>p.IsPublish&&!string.IsNullOrWhiteSpace(p.Tags)).Select(p=>p.Tags).ToList();
            var str= string.Join(",", list);
            return str.Split(',').Distinct();
        }
    }
}
