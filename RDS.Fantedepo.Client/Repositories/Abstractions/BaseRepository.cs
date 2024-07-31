using RDS.Fantedepo.Client.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions
{
    public class BaseRepository
    {
        private Context context;
        protected HttpClient client;

        public BaseRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            client = new HttpClient();
        }
    }
}
