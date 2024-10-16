using Mapster;
using Merzigo.ContentService.Application.Contents.Commands.CreateContent;
using Merzigo.ContentService.Application.Contents.Commands.UpdateContent;
using Merzigo.ContentService.Domain.Entities;

namespace Merzigo.ContentService.Application.Common.Mappings
{
    public static class MappingProfile
    {
        public static void Map()
        {
            TypeAdapterConfig<CreateContentCommand, Content>.NewConfig();
            TypeAdapterConfig<UpdateContentCommand, Content>.NewConfig();

            TypeAdapterConfig<Content, Contents.Queries.GetContent.ContentDto>.NewConfig();
            TypeAdapterConfig<Content, Contents.Queries.GetContents.ContentDto>.NewConfig();
        }
    }
}
