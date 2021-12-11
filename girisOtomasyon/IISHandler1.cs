using System;
using System.Web;

namespace cbu
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// Web.config dosyanızda bu işleyiciyi yapılandırmanız
        /// ve kullanabilmek için IIS'de kaydettirmeniz gerekecektir. Daha fazla bilgi için
        /// şu bağlantıya gidin: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Üyeleri

        public bool IsReusable
        {
            // Yönetilen İşleyiciniz başka bir istek için yeniden kullanılamıyorsa false değerini döndürür.
            // Her istek için ayrılmış bazı durum bilgileriniz olduğunda bu genellikle false olur.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //işleyici uygulamanızı buraya yazın.
        }

        #endregion
    }
}
