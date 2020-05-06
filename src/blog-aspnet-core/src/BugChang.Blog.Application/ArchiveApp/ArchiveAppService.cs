using System.Collections.Generic;
using AutoMapper;
using BugChang.Blog.Application.ArchiveApp.Dto;
using BugChang.Blog.Domain.Interface;

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
    }
}
