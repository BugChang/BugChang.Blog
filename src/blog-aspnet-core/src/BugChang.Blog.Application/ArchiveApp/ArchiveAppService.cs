using System.Collections.Generic;
using AutoMapper;
using BugChang.Blog.Application.ArchiveApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.ArchiveApp
{
    public class ArchiveAppService : IArchiveAppService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public ArchiveAppService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IEnumerable<ArchiveDto> GetArchives()
        {
            var archives = _postRepository.GetArchives();
            return _mapper.Map<IEnumerable<ArchiveDto>>(archives);
        }

        public PageSearchOutput<PostPreviewDto> GetPosts(int year, int month,PageSearchInput pageSearchInput)
        {
            PageSearchOutput<PostPreviewDto> pageSearchOutput = new PageSearchOutput<PostPreviewDto>(pageSearchInput);
            var queryable = _postRepository.GetQueryable(p => p.CreateTime.Year == year &&p.CreateTime.Month==month && p.IsPublish, pageSearchInput, out int total);
            pageSearchOutput.Total = total;
            pageSearchOutput.Records = _mapper.ProjectTo<PostPreviewDto>(queryable);
            return pageSearchOutput;
        }
    }
}
