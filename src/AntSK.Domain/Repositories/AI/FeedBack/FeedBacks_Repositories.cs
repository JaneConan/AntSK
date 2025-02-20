using AntSK.Domain.Common.DependencyInjection;
using AntSK.Domain.Repositories.Base;

namespace AntSK.Domain.Repositories
{
    [ServiceDescription(typeof(IFeedBacks_Repositories), ServiceLifetime.Scoped)]
    public class FeedBacks_Repositories : Repository<FeedBacks>, IFeedBacks_Repositories
    {
    }
}
