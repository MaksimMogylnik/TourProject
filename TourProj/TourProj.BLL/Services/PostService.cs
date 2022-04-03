using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProj.BLL.DTO;
using TourProj.DAL.Context;
using TourProj.DAL.Repositories;

namespace TourProj.BLL.Services
{
    public class PostService
    {
        IRepository<Post> postRepository;
        IMapper mapper;
        public PostService(IRepository<Post> repository)
        {
            postRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Post, PostDTO>()
                    .ForMember(y => y.PostID, y => y.MapFrom(prop => prop.PostID))
                    .ForMember(y => y.PostName, y => y.MapFrom(prop => prop.PostName));
                x.CreateMap<PostDTO, Post>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<PostDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(postRepository.GetAll());
        }

        public PostDTO Get(int postId)
        {
            Post post = postRepository.GetByOneIndex(postId);
            return mapper.Map<Post, PostDTO>(post);
        }

        public PostDTO Delete(PostDTO postDTO)
        {
            Post postToRemove = postRepository.GetByOneIndex(postDTO.PostID);
            postRepository.Delete(postToRemove);
            postRepository.SaveChanges();
            return postDTO;
        }

        public void CreateOrUpdate(PostDTO postDTO)
        {
            Post postTour = mapper.Map<PostDTO, Post>(postDTO);
            postRepository.CreateOrUpdate(postTour);
            postRepository.SaveChanges();
        }
    }
}
