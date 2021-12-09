using AutoMapper;

namespace TaskNote.Entity.Mapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<TaskEntity, TaskModel>();
            CreateMap<TaskModel, TaskEntity>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
        }
    }
}
